
$(function () {
    $("#PdfFile").on('change', function (event) {
        var file = event.target.files[0];
        if (file.size >= 2 * 1024 * 1024) {
            alert("PDF files of maximum 2MB are allowed.");
            $("#editTemplateForm").get(0).reset();
            return;
        }

        if (!file.type.match('application/pdf')) {
            alert("Only PDF files are allowed.");
            $("#editTemplateForm").get(0).reset();
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

document.getElementById("editTemplateForm").addEventListener("submit", function (event) {
    let isValid = true;

   // const nameInput = document.getElementById("Name");
   // const nameError = document.getElementById("Name_error");
   // nameError.textContent = "";
   //if (nameInput.length < 2) {
   //     nameError.textContent = "Name should be at least 2 characters.";
   //     isValid = false;
   // }
   // else if (nameInput.value.length > 50) {
   //     nameError.textContent = "Name cannot exceed 50 characters.";
   //     isValid = false;
   // } 



    const pdfFileInput = document.getElementById("PdfFile");
    const pdfFileError = document.getElementById("PdfFile_error");
    pdfFileError.textContent = "";
    if (!pdfFileInput.files.length && !document.getElementById("keepCurrentPdf").checked) {
        pdfFileError.textContent = "PDF File is required if not keeping the current one.";
        isValid = false;
    }
    else if (!keepCurrentPdfCheckbox.checked && pdfFileInput.files[0].size > 5242880) {
        pdfFileError.textContent = "PDF File size cannot exceed 5MB.";
        isValid = false;
    }



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