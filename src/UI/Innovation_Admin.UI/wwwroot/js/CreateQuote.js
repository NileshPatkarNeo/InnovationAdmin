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

document.getElementById("createQuoteForm").addEventListener("submit", function (event) {
    let isValid = true;

    // Name Validation
    const nameInput = document.getElementById("Name");
    const nameError = document.getElementById("Name_error");
    nameError.textContent = "";
    if (nameInput.value.trim() === "") {
        nameError.textContent = "Name is required.";
        isValid = false;
    } else if (nameInput.value.length > 25) {
        nameError.textContent = "Name cannot exceed 25 characters.";
        isValid = false;
    }

    // Quote By Validation
    const quoteByInput = document.getElementById("QuoteBy");
    const quoteByError = document.getElementById("QuoteBy_error");
    quoteByError.textContent = "";
    if (quoteByInput.value.trim() === "") {
        quoteByError.textContent = "Quote By is required.";
        isValid = false;
    } else if (quoteByInput.value.length > 100) {
        quoteByError.textContent = "Quote By cannot exceed 100 characters.";
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

document.getElementById("QuoteBy").addEventListener("input", function () {
    document.getElementById("QuoteBy_error").textContent = "";
});