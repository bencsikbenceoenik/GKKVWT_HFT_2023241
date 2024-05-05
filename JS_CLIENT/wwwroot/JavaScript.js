let artists = [];
let labels = [];
let songs = [];
let noncruddata = [];
let connection = null;
let songartistToUpdate = null;
let songlabelToUpdate = null;
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

async function noncrudgetdata(url) {
    await fetch(url)
        .then(x => x.json())
        .then(y => {
            noncruddata = y;
            display();
        });
}
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

    document.getElementById('noncrudarea').innerHTML = "";
    noncruddata.forEach(t => {
        document.getElementById('noncrudarea').innerHTML += `<tr>
                <td>${t.songId}</td>
                <td>${t.songTitle}</td>
                <td>${t.duration}</td>
                <td>${t.releaseDate}</td>
                <td>${t.language}</td>
                <td>${(t.songType)}</td>
                <td>${(t.artist != null ? t.artist.artistName : ' ')}</td>
                <td>${t.label != null ? t.label.labelName : ' '}</td>
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
            document.getElementById('labelidtoupdate').value = labels.find(t => t['labelId'] == id)['labelId'];
            document.getElementById('labelnametoupdate').value = labels.find(t => t['labelId'] == id)['labelName'];
            document.getElementById('labelvaluetoupdate').value = labels.find(t => t['labelId'] == id)['labelValue'];
            document.getElementById('labelbasedintoupdate').value = labels.find(t => t['labelId'] == id)['basedIn'];
            document.getElementById('labelfoundmentdatetoupdate').value = labels.find(t => t['labelId'] == id)['foundmentDate'];
            document.getElementById('labeltypefoundertoupdate').value = labels.find(t => t['labelId'] == id)['founder'];
            document.getElementById('updatedformdiv2').style.display = 'flex';
            labelToUpdate = labels.find(t => t['labelId'] == id);
            break;
        case 3:
            document.getElementById('songidtoupdate').value = songs.find(t => t['songId'] == id)['songId'];
            document.getElementById('songtitletoupdate').value = songs.find(t => t['songId'] == id)['songTitle'];
            document.getElementById('songtypetoupdate').value = songs.find(t => t['songId'] == id)['songType'];
            document.getElementById('songreleasedatetoupdate').value = songs.find(t => t['songId'] == id)['releaseDate'];
            document.getElementById('songdurationtoupdate').value = songs.find(t => t['songId'] == id)['duration'];
            document.getElementById('songlanguagetoupdate').value = songs.find(t => t['songId'] == id)['language'];
            document.getElementById('updatedformdiv3').style.display = 'flex';
            songartistToUpdate = songs.find(t => t['songId'] == id).artist;
            songlabelToUpdate = songs.find(t => t['songId'] == id).label;
            break;
        default:
            break;
    }
}

function update(num) {
    switch (num) {
        case 1:
            document.getElementById('updatedformdiv').style.display = "none";
            fetch('http://localhost:40338/artist', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        artistName: document.getElementById('artistnametoupdate').value,
                        artistId: document.getElementById('artistidtoupdate').value,
                        age: document.getElementById('artistagetoupdate').value,
                        debutYear: document.getElementById('artistdebutYeartoupdate').value,
                        gender: document.getElementById('artistgendertoupdate').value,
                        type: Number(document.getElementById('artisttypetoupdate').value),
                        nationality: document.getElementById('artistnationalitytoupdate').value
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(1); })
                .catch((error) => { console.error('Error:', error); });
            break;
        case 2:
            document.getElementById('updatedformdiv2').style.display = "none";
            fetch('http://localhost:40338/label', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        labelId: document.getElementById('labelidtoupdate').value,
                        labelName: document.getElementById('labelnametoupdate').value,
                        labelValue: document.getElementById('labelvaluetoupdate').value,
                        basedIn: document.getElementById('labelbasedintoupdate').value,
                        foundmentDate: document.getElementById('labelfoundmentdatetoupdate').value,
                        founder: document.getElementById('labeltypefoundertoupdate').value
                    }),
            })
                .then(response => response)
                .then(data => { console.log('Success:', data); getdata(2); })
                .catch((error) => { console.error('Error:', error); });
            break;
        case 3:
            document.getElementById('updatedformdiv3').style.display = "none";
            fetch('http://localhost:40338/song', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify(
                    {
                        songId: document.getElementById('songidtoupdate').value,
                        songTitle: document.getElementById('songtitletoupdate').value,
                        songType: document.getElementById('songtypetoupdate').value,
                        releaseDate: document.getElementById('songreleasedatetoupdate').value,
                        duration: document.getElementById('songdurationtoupdate').value,
                        language: document.getElementById('songlanguagetoupdate').value,
                        artistId: songartistToUpdate.artistId,
                        artist: songartistToUpdate,
                        labelId: songlabelToUpdate.labelId,
                        label: songlabelToUpdate
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
            <button type="button" onclick="noncrud(1)">Send GetSongsByDurationAndArtistGender</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 2:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>debutYearThreshold</label>
            <input type="text" id="input1" />
            <button type="button" onclick="noncrud(2)">Send GetSongsByArtistsDebutedAfterYear</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 3:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>thresholdValue</label>
            <input type="text" id="input1" />
            <button type="button" onclick="noncrud(3)">Send GetSongsByLabelValueGreaterThan</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 4:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>releaseYear</label>
            <input type="text" id="input1" />
            <label>nationality</label>
            <input type="text" id="input2" />
            <button type="button" onclick="noncrud(4)">Send GetSongsReleasedAfterYearByNationality</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        case 5:
            document.getElementById('noncrudformdiv').innerHTML = `
            <label>artistName</label>
            <input type="text" id="input1" />
            <label>labelName</label>
            <input type="text" id="input2" />
            <button type="button" onclick="noncrud(5)">Send GetSongsByArtistAndLabel</button>`;
            document.getElementById('noncrudformdiv').style.display = "flex"
            break;
        default:
            break;
    }
}

function noncrud(num) {
    let input1;
    let input2;
    switch (num) {
        case 1:
            input1 = document.getElementById('input1').value;
            input2 = document.getElementById('input2').value;
            noncrudgetdata(`http://localhost:40338/Stat/GetSongsByDurationAndArtistGender?durationThreshold=${input1}&artistGender=${input2}`);
            break;
        case 2:
            input1 = document.getElementById('input1').value;
            noncrudgetdata(`http://localhost:40338/Stat/GetSongsByArtistsDebutedAfterYear?debutYearThreshold=${input1}`);
            break;
        case 3:
            input1 = document.getElementById('input1').value;
            noncrudgetdata(`http://localhost:40338/Stat/GetSongsByLabelValueGreaterThan?thresholdValue=${input1}`);
            break;
        case 4:
            input1 = document.getElementById('input1').value;
            input2 = document.getElementById('input2').value;
            noncrudgetdata(`http://localhost:40338/Stat/GetSongsReleasedAfterYearByNationality?releaseYear=${input1}&nationality=${input2}`);
            break;
        case 5:
            input1 = document.getElementById('input1').value;
            input2 = document.getElementById('input2').value;
            noncrudgetdata(`http://localhost:40338/Stat/GetSongsByArtistAndLabel?artistName=${input1}&labelName=${input2}`);
            break;
        default:
    }
}