let artists = [];
let labels = [];
let songs = [];
let connection = null;
let artistToUpdate = null;
let labelToUpdate = null;
let songToUpdate = null;
getdata(1);
getdata(2);
getdata(3);
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:40338/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata(1);
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata(1);
    });

    connection.on("ArtistUpdated", (user, message) => {
        getdata(1);
    });

    connection.on("LabelCreated", (user, message) => {
        getdata(2);
    });

    connection.on("LabelDeleted", (user, message) => {
        getdata(2);
    });
    
    connection.on("LabelUpdated", (user, message) => {
        getdata(2);
    });

    connection.on("SongCreated", (user, message) => {
        getdata(3);
    });

    connection.on("SongDeleted", (user, message) => {
        getdata(3);
    });
    
    connection.on("SongUpdated", (user, message) => {
        getdata(3);
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

async function getdata(num) {
    switch (num) {
        case 1:
            await fetch('http://localhost:40338/artist')
                .then(x => x.json())
                .then(y => {
                    artists = y;
                    display();
                });
            break;
        case 2:
            await fetch('http://localhost:40338/label')
                .then(x => x.json())
                .then(y => {
                    labels = y;
                    display();
                });
            break;
        case 3:
            await fetch('http://localhost:40338/song')
                .then(x => x.json())
                .then(y => {
                    songs = y;
                    display();
                });
            break;
        default:
            break;
    }
    await fetch('http://localhost:40338/artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML += `<tr>
                <td>${t.artistId}</td>
                <td>${(t.age == 0 ? '-' : t.age)}</td>
                <td>${t.artistName}</td>
                <td>${t.debutYear}</td>
                <td>${t.gender}</td>
                <td>${t.nationality}</td>
                <td>${t.type}</td>
                <td><button type="button" onclick="remove1('${t.artistId}')">Delete</button>
                <button type="button" onclick="showupdate(${t.artistId},1)">Update</button></td>
            </tr>`;
    });

    document.getElementById('resultarea2').innerHTML = "";
    labels.forEach(t => {
        document.getElementById('resultarea2').innerHTML += `<tr>
                <td>${t.labelId}</td>
                <td>${t.labelName}</td>
                <td>${t.labelValue}</td>
                <td>${t.basedIn}</td>
                <td>${t.foundmentDate}</td>
                <td>${(t.founder)}</td>
                <td><button type="button" onclick="remove2('${t.labelId}')">Delete</button>
                <button type="button" onclick="showupdate(${t.labelId},2)">Update</button></td>
            </tr>`;
    });

    document.getElementById('resultarea3').innerHTML = "";
    songs.forEach(t => {
        document.getElementById('resultarea3').innerHTML += `<tr>
                <td>${t.songId}</td>
                <td>${t.songTitle}</td>
                <td>${t.duration}</td>
                <td>${t.releaseDate}</td>
                <td>${t.language}</td>
                <td>${(t.songType)}</td>
                <td>${(t.artist != null ? t.artist.artistName : ' ')}</td>
                <td>${t.label != null ? t.label.labelName : ' '}</td>
                <td><button type="button" onclick="remove3('${t.songId}')">Delete</button>
                <button type="button" onclick="showupdate(${t.songId},3)">Update</button></td>
            </tr>`;
    });
}

function showupdate(id, num) {
    switch (num) {
        case 1:
            document.getElementById('artistnametoupdate').value = artists.find(t => t['artistId'] == id)['artistName'];
            document.getElementById('artistidtoupdate').value = artists.find(t => t['artistId'] == id)['artistId'];
            document.getElementById('artistagetoupdate').value = artists.find(t => t['artistId'] == id)['age'];
            document.getElementById('artistdebutYeartoupdate').value = artists.find(t => t['artistId'] == id)['debutYear'];
            document.getElementById('artistgendertoupdate').value = artists.find(t => t['artistId'] == id)['gender'];
            document.getElementById('artisttypetoupdate').value = artists.find(t => t['artistId'] == id)['type'];
            document.getElementById('artistnationalitytoupdate').value = artists.find(t => t['artistId'] == id)['nationality'];
            document.getElementById('updatedformdiv').style.display = 'flex';
            artistToUpdate = artists.find(t => t['artistId'] == id);
            break;
        case 2:
            document.getElementById('labelnametoupdate').value = labels.find(t => t['labelId'] == id)['labelName'];
            //document.getElementById('artistnametoupdate').value = artists.find(t => t['artistId'] == id)['artistName'];
            //document.getElementById('artistidtoupdate').value = artists.find(t => t['artistId'] == id)['artistId'];
            //document.getElementById('artistagetoupdate').value = artists.find(t => t['artistId'] == id)['age'];
            //document.getElementById('artistdebutYeartoupdate').value = artists.find(t => t['artistId'] == id)['debutYear'];
            //document.getElementById('artistgendertoupdate').value = artists.find(t => t['artistId'] == id)['gender'];
            //document.getElementById('artisttypetoupdate').value = artists.find(t => t['artistId'] == id)['type'];
            //document.getElementById('artistnationalitytoupdate').value = artists.find(t => t['artistId'] == id)['nationality'];
            document.getElementById('updatedformdiv2').style.display = 'flex';
            labelToUpdate = labels.find(t => t['labelId'] == id);
            break;
        case 3:
            document.getElementById('songtitletoupdate').value = songs.find(t => t['songId'] == id)['songTitle'];
            //document.getElementById('artistnametoupdate').value = artists.find(t => t['artistId'] == id)['artistName'];
            //document.getElementById('artistidtoupdate').value = artists.find(t => t['artistId'] == id)['artistId'];
            //document.getElementById('artistagetoupdate').value = artists.find(t => t['artistId'] == id)['age'];
            //document.getElementById('artistdebutYeartoupdate').value = artists.find(t => t['artistId'] == id)['debutYear'];
            //document.getElementById('artistgendertoupdate').value = artists.find(t => t['artistId'] == id)['gender'];
            //document.getElementById('artisttypetoupdate').value = artists.find(t => t['artistId'] == id)['type'];
            //document.getElementById('artistnationalitytoupdate').value = artists.find(t => t['artistId'] == id)['nationality'];
            document.getElementById('updatedformdiv3').style.display = 'flex';
            songToUpdate = songs.find(t => t['songId'] == id);
            break;
        default:
            break;
    }
}

function update(num) {
    let name;
    switch (num) {
        case 1:
            name = document.getElementById('artistnametoupdate').value;
            fetch('http://localhost:40338/artist', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        artistName: /*name*/document.getElementById('artistnametoupdate').value,
                        artistId: /*artistToUpdate.artistId*/document.getElementById('artistidtoupdate').value,
                        age: /*artistToUpdate.age*/document.getElementById('artistagetoupdate').value,
                        debutYear: /*artistToUpdate.debutYear*/document.getElementById('artistdebutYeartoupdate').value,
                        gender: /*artistToUpdate.gender*/document.getElementById('artistgendertoupdate').value,
                        type: /*artistToUpdate.type*/Number(document.getElementById('artisttypetoupdate').value),
                        nationality: /*artistToUpdate.nationality*/document.getElementById('artistnationalitytoupdate').value
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(1); })
                .catch((error) => { console.error('Error:', error); });
            break;
        case 2:
            name = document.getElementById('labelnametoupdate').value;
            fetch('http://localhost:40338/label', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        labelName: name,
                        labelId: labelIdToUpdate
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(2); })
                .catch((error) => { console.error('Error:', error); });
            break;
        case 3:
            name = document.getElementById('songtitletoupdate').value;
            fetch('http://localhost:40338/song', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        songTitle: name,
                        songId: songIdToUpdate
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(3); })
                .catch((error) => { console.error('Error:', error); });
            break;
        default:
            break;
    }
}
function create(num) {
    let name;
    switch (num) {
        case 1:
            name = document.getElementById('artistname').value;
            fetch('http://localhost:40338/artist', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        artistName: name
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(1); })
                .catch((error) => { console.error('Error:', error); });
            break;
        case 2:
            name = document.getElementById('labelname').value;
            fetch('http://localhost:40338/label', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        labelName: name
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(2); })
                .catch((error) => { console.error('Error:', error); });
            break;
        case 3:
            name = document.getElementById('songtitle').value;
            fetch('http://localhost:40338/song', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        songTitle: name
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(3); })
                .catch((error) => { console.error('Error:', error); });
            break;
        default:
            break;
    }
}

function remove1(id) {
    let name = document.getElementById('artistname').value;
    fetch('http://localhost:40338/artist/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(1); })
        .catch((error) => { console.error('Error:', error); });
}
function remove2(id) {
    let name = document.getElementById('labelname').value;
    fetch('http://localhost:40338/label/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(2); })
        .catch((error) => { console.error('Error:', error); });
}
function remove3(id) {
    let name = document.getElementById('songtitle').value;
    fetch('http://localhost:40338/song/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(3); })
        .catch((error) => { console.error('Error:', error); });
}

function shownoncrud(num) {
    switch (num) {
        case 1:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>durationThreshold</label>
            <input type="text" id="input1" />
            <label>artistGender</label>
            <input type="text" id="input2" />
            <button type="button" onclick="noncrud()">Send GetSongsByDurationAndArtistGender</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 2:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>debutYearThreshold</label>
            <input type="text" id="input1" />
            <button type="button" onclick="noncrud()">Send GetSongsByArtistsDebutedAfterYear</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 3:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>thresholdValue</label>
            <input type="text" id="input1" />
            <button type="button" onclick="noncrud()">Send GetSongsByLabelValueGreaterThan</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 4:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>releaseYear</label>
            <input type="text" id="input1" />
            <label>nationality</label>
            <input type="text" id="input2" />
            <button type="button" onclick="noncrud()">Send GetSongsReleasedAfterYearByNationality</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 5:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>artistName</label>
            <input type="text" id="input1" />
            <label>labelName</label>
            <input type="text" id="input2" />
            <button type="button" onclick="noncrud()">Send GetSongsByArtistAndLabel</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        default:
            break;
    }
}