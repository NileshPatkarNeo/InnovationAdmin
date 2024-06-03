// wwwroot/js/CreateSysPrefSecurityEmail.js

document.addEventListener("DOMContentLoaded", function () {
    var form = document.querySelector("#createSysPrefSecurityEmailForm");

    form.addEventListener("submit", function (event) {
        var isValid = true;

        // Validate Default From Name
        var defaultFromName = document.querySelector("#defaultFromName").value;
        var defaultFromNameError = document.querySelector("[asp-validation-for='DefaultFromName']");
        if (defaultFromName.trim() === "") {
            defaultFromNameError.textContent = "Default From Name is required.";
            isValid = false;
        } else if (defaultFromName.length > 20) {
            defaultFromNameError.textContent = "Default From Name cannot exceed 20 characters.";
            isValid = false;
        } else {
            defaultFromNameError.textContent = "";
        }

        // Validate Default From Address
        var defaultFromAddress = document.querySelector("#defaultFromAddress").value;
        var defaultFromAddressError = document.querySelector("#defaultFromAddressError");
        if (defaultFromAddress.trim() === "") {
            defaultFromAddressError.textContent = "Default From Address is required.";
            isValid = false;
        } else if (!validateEmail(defaultFromAddress)) {
            defaultFromAddressError.textContent = "Please enter a valid email address.";
            isValid = false;
        } else if (!emailRegex.test(email)) {
            emailError.textContent = "Invalid email format.";
            isValid = false;
        } else if (!defaultFromAddress.includes(".com")) {
            defaultFromAddressError.textContent = "Email address must contain .com";
            isValid = false;

        } else if (defaultFromAddress.length > 20) {
            defaultFromAddressError.textContent = "Default From Address cannot exceed 20 characters.";
            isValid = false;
        } else {
            defaultFromAddressError.textContent = "";
        }

        // Validate Default Reply To Address
        var defaultReplyToAddress = document.querySelector("#defaultReplyToAddress").value;
        var defaultReplyToAddressError = document.querySelector("#defaultReplyToAddressError");
        if (defaultReplyToAddress.trim() === "") {
            defaultReplyToAddressError.textContent = "Default Reply To Address is required.";
            isValid = false;
        } else if (!validateEmail(defaultReplyToAddress)) {
            defaultReplyToAddressError.textContent = "Please enter a valid email address.";
            isValid = false;
        } else if (!defaultFromAddress.includes(".com")) {
            defaultFromAddressError.textContent = "Email address must contain .com";
            isValid = false;
        }else if (defaultReplyToAddress.length > 20) {
            defaultReplyToAddressError.textContent = "Default Reply To Address cannot exceed 20 characters.";
            isValid = false;
        } else {
            defaultReplyToAddressError.textContent = "";
        }

        // Validate Default Reply To Name
        var defaultReplyToName = document.querySelector("#defaultReplyToName").value;
        var defaultReplyToNameError = document.querySelector("[asp-validation-for='DefaultReplyToName']");
        if (defaultReplyToName.trim() === "") {
            defaultReplyToNameError.textContent = "Default Reply To Name is required.";
            isValid = false;
        } else if (defaultReplyToName.length > 20) {
            defaultReplyToNameError.textContent = "Default Reply To Name cannot exceed 20 characters.";
            isValid = false;
        } else {
            defaultReplyToNameError.textContent = "";
        }

        // Validate Status
        var status = document.querySelector("#status").value;
        var statusError = document.querySelector("[asp-validation-for='Status']");
        if (status.trim() === "") {
            statusError.textContent = "Status is required.";
            isValid = false;
        } else if (isNaN(status)) {
            statusError.textContent = "Status must be a number.";
            isValid = false;
        } else {
            statusError.textContent = "";
        }

        if (!isValid) {
            event.preventDefault();
        }
    });

    // Function to validate email addresses
    function validateEmail(email) {
        // General email regex pattern
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }
});
