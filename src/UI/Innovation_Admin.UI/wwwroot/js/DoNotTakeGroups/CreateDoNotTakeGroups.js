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
document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('createGroupForm');
    const groupCodeInput = document.getElementById('groupCode');
    const groupNameInput = document.getElementById('groupName');
    const groupCodeError = document.getElementById('groupCodeError');
    const groupNameError = document.getElementById('groupNameError');

    form.addEventListener('submit', function (event) {
        let isValid = true;


        groupCodeError.innerText = '';
        groupNameError.innerText = '';


        const groupCodeValue = groupCodeInput.value.trim();
        if (groupCodeValue === '') {
            groupCodeError.innerText = 'Group Code is required.';
            isValid = false;
        } else if (isNaN(groupCodeValue) || parseFloat(groupCodeValue) <= 0) {
            groupCodeError.innerText = 'Group Code must be a positive number.';
            isValid = false;
        } else if (groupCodeValue.length > 9) {
            groupCodeError.innerText = 'Group Code cannot exceed 9 characters.';
            isValid = false;
        }


        const groupNameValue = groupNameInput.value.trim();
        if (groupNameValue === '') {
            groupNameError.innerText = 'Group Name is required.';
            isValid = false;
        }

        if (!isValid) {
            event.preventDefault();
        }
    });


    groupCodeInput.addEventListener('focusout', function () {
        validateGroupCode();
    });

    groupCodeInput.addEventListener('input', function () {
        const groupCodeValue = groupCodeInput.value.trim();
        if (groupCodeValue !== '' && !isNaN(groupCodeValue) && parseFloat(groupCodeValue) > 0 && groupCodeValue.length <= 9) {
            groupCodeError.innerText = '';
        } else if (groupCodeValue.length > 9) {
            groupCodeError.innerText = 'Group Code cannot exceed 9 characters.';
        }
    });


    groupNameInput.addEventListener('focusout', function () {
        validateGroupName();
    });

    groupNameInput.addEventListener('input', function () {
        const groupNameValue = groupNameInput.value.trim();
        if (groupNameValue !== '') {
            groupNameError.innerText = '';
        }
    });

    function validateGroupCode() {
        const groupCodeValue = groupCodeInput.value.trim();
        if (groupCodeValue === '') {
            groupCodeError.innerText = 'Group Code is required.';
        } else if (isNaN(groupCodeValue) || parseFloat(groupCodeValue) <= 0) {
            groupCodeError.innerText = 'Group Code must be a positive number.';
        } else if (groupCodeValue.length > 9) {
            groupCodeError.innerText = 'Group Code cannot exceed 9 characters.';
        } else {
            groupCodeError.innerText = '';
        }
    }

    function validateGroupName() {
        const groupNameValue = groupNameInput.value.trim();
        if (groupNameValue === '') {
            groupNameError.innerText = 'Group Name is required.';
        } else {
            groupNameError.innerText = '';
        }
    }
});
