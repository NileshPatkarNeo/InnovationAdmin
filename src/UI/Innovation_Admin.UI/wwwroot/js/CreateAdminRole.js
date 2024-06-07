

document.getElementById("createAdminRoleForm").addEventListener("submit", function (event) {
    let isValid = true;

    // Role Name Validation
    const roleNameInput = document.getElementById("Role_Name");
    const roleNameError = document.getElementById("Role_Name_error");
    roleNameError.textContent = "";
    if (roleNameInput.value.trim() === "") {
        roleNameError.textContent = "Role Name is required.";
        isValid = false;
    } else if (roleNameInput.value.length > 20) {
        roleNameError.textContent = "Role Name cannot exceed 20 characters.";
        isValid = false;
    }
    function onlyAlphabets(e, t) {
        try {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                return true;
            else
                return false;
        }
        catch (err) {
            alert(err.Description);
        }
    } 

    // Description Validation
    const descriptionInput = document.getElementById("Description");
    const descriptionError = document.getElementById("Description_error");
    descriptionError.textContent = "";
    if (descriptionInput.value.trim() === "") {
        descriptionError.textContent = "Description is required.";
        isValid = false;
    } else if (descriptionInput.value.length > 59) {
        descriptionError.textContent = "Description cannot exceed 59 characters.";
        isValid = false;
    }

    if (!isValid) {
        event.preventDefault();
    }
});

// Clear error messages on input
document.getElementById("Role_Name").addEventListener("input", function () {
    document.getElementById("Role_Name_error").textContent = "";
});

document.getElementById("Description").addEventListener("input", function () {
    document.getElementById("Description_error").textContent = "";
});

