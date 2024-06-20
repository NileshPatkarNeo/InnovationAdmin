document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("createCorrespondenceNoteForm");

    form.addEventListener("submit", function (event) {
        var isValid = true;

        var note = document.getElementById("Note").value;
        var noteError = document.getElementById("noteError");
        if (note.trim() === "") {
            noteError.textContent = "Note is required.";
            isValid = false;
        } else if (note.length < 2) {
            noteError.textContent = "Note should be at least 2 characters.";
            isValid = false;
        } else if (note.length > 50) {
            noteError.textContent = "Note cannot exceed 50 characters.";
            isValid = false;
        } else if (!/^[a-zA-Z\s]*$/.test(note)) {
            noteError.textContent = "Note can only contain alphabet characters and spaces.";
            isValid = false;
        } else {
            noteError.textContent = "";
        }

        if (!isValid) {
            event.preventDefault();
        }
    });
    //document.getElementById("Note").addEventListener("input", function () {
    //    document.getElementById("nameError").textContent = "";
    //});
});
