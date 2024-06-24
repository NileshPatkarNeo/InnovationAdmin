
    document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("createAdminUserForm");

    form.addEventListener("submit", function (event) {
        var isValid = true;

    // Validate User Name
    var userName = document.getElementById("User_Name").value;
    var userNameError = document.getElementById("userNameError");
    if (userName.trim() === "") {
        userNameError.textContent = "User Name is required.";
    isValid = false;
        } else if (!/^[a-zA-Z\s]*$/.test(userName)) {
        userNameError.textContent = "Name can only contain characters";
    isValid = false;
        } else if (userName.value.length < 2) {
        userNameError.textContent = "Name should be at least 2 characters.";
    isValid = false;
        }
        else if (userName.value.length > 30) {
        userNameError.textContent = "User Name should be 30 characters or less.";
    isValid = false;
        } else {
        userNameError.textContent = "";
        }

    // Validate Email
    var email = document.getElementById("Email").value;
    var emailError = document.getElementById("emailError");
    var emailRegex = /^[^\s]+[^\s]+\.[^\s]+$/;
    if (email.trim() === "") {
        emailError.textContent = "Email is required.";
    isValid = false;
        } else if (!emailRegex.test(email)) {
        emailError.textContent = "Invalid email format.";
    isValid = false;
        } else if (!email.includes(".com")) {
        emailError.textContent = "Email address must contain .com";
    isValid = false;
        } else {
        emailError.textContent = "";
        }

    // Validate Password
    var password = document.getElementById("Password").value;
    var passwordError = document.getElementById("passwordError");
    if (password.trim() === "") {
        passwordError.textContent = "Password is required.";
    isValid = false;
        } else if (password.length < 6 || password.length > 40) {
        passwordError.textContent = "Password should be between 6 and 40 characters.";
    isValid = false;
        } else {
        passwordError.textContent = "";
        }

    // Validate Status
    var statusError = document.getElementById("statusError");
    // Assuming Status is a boolean and no additional validation needed
    statusError.textContent = "";

    if (!isValid) {
        event.preventDefault();
        }
    });
});

