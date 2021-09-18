let getAllBtn = document.getElementById("btn1");
let addNoteBtn = document.getElementById("btn3");
let addNoteInput1 = document.getElementById("input31");
let addNoteInput2 = document.getElementById("input32");
let addNoteInput3 = document.getElementById("input33");

let port = "34209";
let getAllNotes = async () => {
    let url = "http://localhost:" + port + "/api/notestags";

    let response = await fetch(url);
    let data = await response.json();
    console.log(data);
};

let addNote = async () => {
    let url = "http://localhost:" + port + "/api/notestags";
    let getTags = (str) => {
        //we enetr the tags in the input field separated by comma
        let tags = str.split(",");
        let tagObjects = [];
        for (tag of tags) {
            tagObjects.push({ name: tag.split("-")[0], color: tag.split("-")[1] });

        }
        return tagObjects;
    }
    //the note we want to add
    let note = { text: addNoteInput1.value, color: addNoteInput2.value, tags: getTags(addNoteInput3.value) }
    var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(note) //convert it to json
    });
    console.log(response);
}

getAllBtn.addEventListener("click", getAllNotes);
addNoteBtn.addEventListener("click", addNote);