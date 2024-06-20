document.addEventListener('DOMContentLoaded', function () {
    var nameField = document.getElementById('Name');
    var typeField = document.getElementById('Type');
    var form = document.getElementById('receiptBatchForm');

    function removeValidationMessage(element) {
        var messageSpan = element.parentNode.querySelector('.custom-validation-message');
        if (messageSpan) {
            messageSpan.remove();
        }
    }

    nameField.addEventListener('input', function () {
        if (nameField.value.trim() !== '' && nameField.value.trim().length <= 50) {
            removeValidationMessage(nameField);
        }
    });

    typeField.addEventListener('change', function () {
        if (typeField.value.trim() !== '') {
            removeValidationMessage(typeField);
        }
    });

    form.addEventListener('submit', function (event) {
        var nameValue = nameField.value.trim();
        var typeValue = typeField.value.trim();

        var isValid = true;

        removeValidationMessage(nameField);
        removeValidationMessage(typeField);

        if (!nameValue) {
            displayValidationMessage(nameField, 'Name is required.');
            isValid = false;
        } else if (nameValue.length > 50) {
            displayValidationMessage(nameField, 'Name should not exceed 50 characters.');
            isValid = false;
        }

        if (!typeValue) {
            displayValidationMessage(typeField, 'Type is required.');
            isValid = false;
        }

        if (!isValid) {
            event.preventDefault();
        }
    });

    function displayValidationMessage(element, message) {
        var messageSpan = document.createElement('span');
        messageSpan.className = 'text-danger custom-validation-message';
        messageSpan.innerText = message;
        element.parentNode.appendChild(messageSpan);
    }
});

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
