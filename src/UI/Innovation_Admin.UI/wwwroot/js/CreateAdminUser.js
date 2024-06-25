document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("createAdminUserForm");

    form.addEventListener("submit", function (event) {
        var isValid = true;

        // Validate User Name
        var userName = document.getElementById("User_Name").value;
        var userNameError = document.getElementById("userNameError");
        userName = userName.trim(); // Add these line 
        if (userName.trim() === "") {
            userNameError.textContent = "UserName is required.";
            isValid = false;
        } else if (!/^[a-zA-Z\s]*$/.test(userName)) {
            userNameError.textContent = "Name can only contain characters";
            isValid = false;
        } else if (userName.length < 2) {
            userNameError.textContent = "Name should be at least 2 characters.";
            isValid = false;
        } else if (userName.length > 30) {
            userNameError.textContent = "Name cannot exceed 30 characters.";
            isValid = false;
        } else {
            userNameError.textContent = "";
        }

        // Validate Role
        var role = document.getElementById("RoleId").value;
        var roleError = document.getElementById("roleError");
        if (role.trim() === "") {
            roleError.textContent = "Role is required.";
            isValid = false;
        } else if (isNaN(role) || role < 1) {
            roleError.textContent = "Role should be a positive integer.";
            isValid = false;
        } else {
            roleError.textContent = "";
        }

        // Validate Email
        var email = document.getElementById("Email").value;
        var emailError = document.getElementById("emailError");
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
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
