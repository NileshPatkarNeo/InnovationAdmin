
    document.addEventListener("DOMContentLoaded", function () {
        console.log("EditAdminUser.js loaded");
    var form = document.querySelector("form");

    form.addEventListener("submit", function (event) {
                var isValid = true;

    // Validate User Name
    var userName = document.querySelector("#User_Name").value;
    var userNameError = document.querySelector("#userNameError");
    if (userName.trim() === "") {
        userNameError.textContent = "User Name is required.";
    isValid = false;
                } else if (userName.length > 20) {
        userNameError.textContent = "User Name should be 20 characters or less.";
    isValid = false;
                } else {
        userNameError.textContent = "";
                }

    // Validate Email
    var email = document.querySelector("#Email").value;
    var emailError = document.querySelector("#emailError");
    var emailRegex = /^[^\s]+[^\s]+\.[^\s]+$/;
    if (email.trim() === "") {
        emailError.textContent = "Email is required.";
    isValid = false;
                } else if (!emailRegex.test(email)) {
        emailError.textContent = "Invalid email format.";
    isValid = false;
                } else {
        emailError.textContent = "";
                }

    // Validate Password
    var password = document.querySelector("#Password").value;
    var passwordError = document.querySelector("#passwordError");
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
    var status = document.querySelector("#Status").checked;
    var statusError = document.querySelector("#statusError");
    // Assuming Status is a boolean and no additional validation needed
    statusError.textContent = "";

    if (!isValid) {
        event.preventDefault();
                }
            });
        });
