document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("createRemittanceTypeForm");

    form.addEventListener("submit", function (event) {
        var isValid = true;

        // Validate Name
        var name = document.getElementById("Name").value;
        var nameError = document.getElementById("nameError");
        if (name.trim() === "") {
            nameError.textContent = "Name is required.";
            isValid = false;
        } else if (name.length < 2) {
            nameError.textContent = "Name should be at least 2 characters.";
            isValid = false;
        } else if (name.length > 30) {
            nameError.textContent = "Note cannot exceed 30 characters.";
            isValid = false;
        } else if (!/^[a-zA-Z\s]*$/.test(name)) {
            nameError.textContent = "Name can only contain letters and spaces.";
            isValid = false;
        } else {
            nameError.textContent = "";
        }

        if (!isValid) {
            event.preventDefault();
        }


    });
    document.getElementById("Name").addEventListener("input", function () {
        document.getElementById("nameError").textContent = "";
    });
});