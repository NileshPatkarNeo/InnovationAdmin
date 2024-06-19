$(function () {
    $("#PdfFile").on('change', function (event) {
        var file = event.target.files[0];
        if (file.size >= 2 * 1024 * 1024) {
            alert("JPG images of maximum 2MB");
            $("#createTemplateForm").get(0).reset();
            return;
        }

        if (!file.type.match('application/pdf')) {
            alert("only PDF file");
            $("#createTemplateForm").get(0).reset(); 
            return;
        }

      
    });
});

function onlyAlphabets(e, t) {
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

document.getElementById("createTemplateForm").addEventListener("submit", function (event) {
    let isValid = true;

    // Name Validation
    const nameInput = document.getElementById("Name");
    const nameError = document.getElementById("Name_error");
    nameError.textContent = "";
    if (nameInput.value.trim() === "") {
        nameError.textContent = "Name is required.";
        isValid = false;
    } else if (nameInput.value.length > 50) {
        nameError.textContent = "Name cannot exceed 50 characters.";
        isValid = false;
    }

    // PDF Template File Validation
    const pdfTemplateFileInput = document.getElementById("PdfTemplateFile");
    const pdfTemplateFileError = document.getElementById("PdfTemplateFile_error");
    pdfTemplateFileError.textContent = "";
    if (pdfTemplateFileInput.value.trim() === "") {
        pdfTemplateFileError.textContent = "PDF Template File is required.";
        isValid = false;
    }

    // Domain Validation
    const domainInput = document.getElementById("Domain");
    const domainError = document.getElementById("Domain_error");
    domainError.textContent = "";
    if (domainInput.value.trim() === "") {
        domainError.textContent = "Domain is required.";
        isValid = false;
    } else if (domainInput.value.length > 50) {
        domainError.textContent = "Domain cannot exceed 50 characters.";
        isValid = false;
    }

    // Size Validation
    const sizeInput = document.getElementById("Size");
    const sizeError = document.getElementById("Size_error");
    sizeError.textContent = "";
    if (sizeInput.value.trim() === "") {
        sizeError.textContent = "Size is required.";
        isValid = false;
    } else if (sizeInput.value.length > 50) {
        sizeError.textContent = "Size cannot exceed 50 characters.";
        isValid = false;
    }

    if (!isValid) {
        event.preventDefault();
    }
});

// Clear error messages on input
document.getElementById("Name").addEventListener("input", function () {
    document.getElementById("Name_error").textContent = "";
});

document.getElementById("PdfTemplateFile").addEventListener("input", function () {
    document.getElementById("PdfTemplateFile_error").textContent = "";
});

document.getElementById("Domain").addEventListener("input", function () {
    document.getElementById("Domain_error").textContent = "";
});

document.getElementById("Size").addEventListener("input", function () {
    document.getElementById("Size_error").textContent = "";
});
