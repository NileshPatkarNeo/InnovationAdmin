document.addEventListener("DOMContentLoaded", function () {
    var form = document.querySelector("form");

    form.addEventListener("submit", function (event) {
        var isValid = true;

        // Validate Note
        var note = document.querySelector("#Note").value;
        var noteError = document.querySelector("#noteError");
        if (note.trim() === "") {
            noteError.textContent = "Note is required.";
            isValid = false;
        } else if (note.length < 2) {
            noteError.textContent = "Note should be at least 2 characters.";
            isValid = false;
        } else if (note.length > 100) {
            noteError.textContent = "Note should be at most 100 characters.";
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
});
