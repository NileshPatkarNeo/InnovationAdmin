// Function to ensure that only alphabets and spaces are entered
function onlyAlphabets(event) {
    try {
        var charCode = (event.which) ? event.which : event.keyCode;

        // Allow space (charCode 32) and alphabet characters
        if ((charCode >= 65 && charCode <= 90) || // A-Z
            (charCode >= 97 && charCode <= 122) || // a-z
            charCode === 32) { // Space
            return true;
        }
        return false;
    } catch (err) {
        alert(err.Description);
    }
}

// Function to validate Company Name
function validateCompanyName() {
    var companyName = document.getElementById('CompanyName').value.trim();
    var errorElement = document.getElementById('companyNameError');

    if (companyName === '') {
        errorElement.innerText = 'Company Name is required';
        return false;
    } else if (companyName.length > 40) {
        errorElement.innerText = 'Company Name should be a maximum of 40 characters';
        return false;
    }

    errorElement.innerText = '';
    return true;
}

// Function to validate Term For Pharmacy
function validateTermForPharmacy() {
    var termForPharmacy = document.getElementById('TermForPharmacy').value.trim();
    var errorElement = document.getElementById('termForPharmacyError');

    if (termForPharmacy === '') {
        errorElement.innerText = 'Term For Pharmacy is required';
        return false;
    } else if (termForPharmacy.length > 50) {
        errorElement.innerText = 'Term For Pharmacy should be a maximum of 50 characters';
        return false;
    }

    errorElement.innerText = '';
    return true;
}

// Function to validate the entire form
function validateForm() {
    var isValid = true;
    isValid = validateCompanyName() && isValid;
    isValid = validateTermForPharmacy() && isValid;
    return isValid;
}

// Adding event listeners for real-time validation feedback
document.getElementById('CompanyName').addEventListener('blur', validateCompanyName);
document.getElementById('TermForPharmacy').addEventListener('blur', validateTermForPharmacy);

// Ensure only alphabets and spaces are typed in the inputs
document.getElementById('CompanyName').addEventListener('input', function (event) {
    var input = event.target.value;
    var regex = /^[a-zA-Z\s]*$/;

    if (!regex.test(input)) {
        event.target.value = input.replace(/[^a-zA-Z\s]/g, ''); // Remove invalid characters
    }
});

document.getElementById('TermForPharmacy').addEventListener('input', function (event) {
    var input = event.target.value;
    var regex = /^[a-zA-Z\s]*$/;

    if (!regex.test(input)) {
        event.target.value = input.replace(/[^a-zA-Z\s]/g, ''); // Remove invalid characters
    }
});
