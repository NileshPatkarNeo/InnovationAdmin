
    document.addEventListener("DOMContentLoaded", function () {
            var form = document.querySelector("form");

    form.addEventListener("submit", function (event) {
                var isValid = true;

    // Validate Name
    var name = document.querySelector("#Name").value;
    var nameError = document.querySelector("#nameError");
    if (name.trim() === "") {
        nameError.textContent = "Name is required.";
    isValid = false;
    } else if (!/^[a-zA-Z\s]*$/.test(name)) {
        nameError.textContent = "Name can only contain characters";
        isValid = false;
    }    else if (name.length < 2) {
        nameError.textContent = "Name should be at least 2 characters.";
    isValid = false;
                } else if (name.length > 30) {
        nameError.textContent = "Name cannot exceed 30 characters.";
    isValid = false;
                } else {
        nameError.textContent = "";
                }

    if (!isValid) {
        event.preventDefault();
                }
            });
        });
