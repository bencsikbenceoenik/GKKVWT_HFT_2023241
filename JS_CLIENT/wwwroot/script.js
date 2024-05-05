let artists = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:40338/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:40338/artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            display();
        });
}

function display() {
    document.getElementById('asd').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('asd').innerHTML += `<tr>
                <td>${t.artistId}</td>
                <td>${(t.age == 0 ? '-' : t.age)}</td>
                <td>${t.artistName}</td>
                <td>${t.debutYear}</td>
                <td>${t.gender}</td>
                <td>${t.nationality}</td>
                <td>${(t.type == 0 ? 'Group' : 'Soloist')}</td>
                <td><button type="button" onclick="remove('${t.artistId}')">Delete</button></td>
            </tr>`;
    });
}

function create() {
    let name = document.getElementById('artistname').value;
    fetch('http://localhost:40338/artist', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                artistName: name
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    let name = document.getElementById('artistname').value;
    fetch('http://localhost:40338/artist/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}