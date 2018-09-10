var url = 'https://localhost:44317/api/verbrecher';
var selectFld = document.getElementById("selectFld");
selectFld.addEventListener('change', getVerbrecherId);

getData(url, createOptions)


function createOptions(data) {
    for (var i = 0; i < data.length; i++) {
        var option = document.createElement("option");
        option.value = data[i].verbrecherId;
        option.text = data[i].vorname + " " + data[i].nachname;
        selectFld.add(option,null);
    }
}

function getVerbrecherId() {
    var verbrecherId = this.options[this.selectedIndex].value;
    var vergehenUrl = "https://localhost:44317/api/verbrecher/" + verbrecherId + "/vergehen";
    getData(vergehenUrl, fillTable);

}


function fillTable(data) {
    var tb = document.getElementById('tb');
    tb.innerHTML = "";
    console.log(data[1]);
    for (var i = 0; i < data.length; i++) {
        var row = document.createElement("tr")
        var beschreibungColumn = document.createElement('td');
        beschreibungColumn.innerText = data[i].bezeichnung;
        row.appendChild(beschreibungColumn);
        var tatZeitpunktColumn = document.createElement('td');
        tatZeitpunktColumn.innerText = data[i].tatZeitpunkt;
        row.appendChild(tatZeitpunktColumn);
        var st�rkeColumn = document.createElement('td');
        st�rkeColumn.innerText = data[i].st�rke;
        row.appendChild(st�rkeColumn)
        tb.appendChild(row)
    }
}

function getData(url, callback) {
    fetch(url)
        .then(function (response) {
            return response.json();
        }).then(data => callback(data))
}


