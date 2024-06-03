﻿function validateCompanyName() {
    var companyNameInput = document.getElementById('CompanyName');
    var companyName = companyNameInput.value.trim();
    if (companyName === '') {
        document.getElementById('companyNameError').innerText = 'Company Name is required';
        return false;
    } else if (companyName.length > 40) {
        document.getElementById('companyNameError').innerText = 'Company Name should be max 40 characters';
        return false;
    }
    document.getElementById('companyNameError').innerText = '';
    return true;
}


function validateTermForPharmacy() {
    var termForPharmacyInput = document.getElementById('TermForPharmacy');
    var termForPharmacy = termForPharmacyInput.value.trim();
    if (termForPharmacy === '') {
        document.getElementById('termForPharmacyError').innerText = 'Term For Pharmacy is required';
        return false;
    }
    else if (termForPharmacy.length > 50) {
        document.getElementById('termForPharmacyError').innerText = 'Term For Pharmacy should be max 50 characters';
        return false;
    }
    document.getElementById('termForPharmacyError').innerText = '';
    return true;
}


function validateForm() {
    var isValid = true;
    isValid = validateCompanyName() && isValid;
    isValid = validateTermForPharmacy() && isValid;
    return isValid;
}


document.getElementById('CompanyName').addEventListener('blur', function () {
    validateCompanyName();
});

document.getElementById('TermForPharmacy').addEventListener('blur', function () {
    validateTermForPharmacy();
});