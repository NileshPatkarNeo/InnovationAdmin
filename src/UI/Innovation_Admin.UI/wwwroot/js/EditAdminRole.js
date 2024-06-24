﻿function onlyAlphabets(e, t) {
    try {
        var charCode = (e.which) ? e.which : window.event.keyCode;
        if ((charCode > 64 && charCode < 91) ||
            (charCode > 96 && charCode < 123) ||
            charCode === 32) {
            return true;
        } else {
            return false;
        }
    } catch (err) {
        alert(err.Description);
    }
}

//document.getElementById("editAdminRoleForm").addEventListener("submit", function (event) {
//    let isValid = true;

//    // Role Name Validation
//    const roleNameInput = document.getElementById("Role_Name");
//    const roleNameError = document.getElementById("Role_Name_error");
//    roleNameError.textContent = "";
//    if (roleNameInput.value.trim() === "") {
//        roleNameError.textContent = "Role Name is required.";
//        isValid = false;
//    }
//     else if (roleNameInput.value.length > 50) {
//        roleNameError.textContent = "Role Name cannot exceed 50 characters.";
//        isValid = false;
//    }

//    // Description Validation
//    const descriptionInput = document.getElementById("Description");
//    const descriptionError = document.getElementById("Description_error");
//    descriptionError.textContent = "";
//    if (descriptionInput.value.trim() === "") {
//        descriptionError.textContent = "Description is required.";
//        isValid = false;
//    } else if (descriptionInput.value.length > 100) {
//        descriptionError.textContent = "Description cannot exceed 100 characters.";
//        isValid = false;
//    }

//    if (!isValid) {
//        event.preventDefault();
//    }
//});

// Clear error messages on input
document.getElementById("Role_Name").addEventListener("input", function () {
    document.getElementById("Role_Name_error").textContent = "";
});

document.getElementById("Description").addEventListener("input", function () {
    document.getElementById("Description_error").textContent = "";
});

