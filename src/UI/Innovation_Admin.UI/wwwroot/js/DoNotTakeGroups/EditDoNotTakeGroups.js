document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('editGroupForm');
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


    groupCodeInput.addEventListener('input', function () {
        const groupCodeValue = groupCodeInput.value.trim();
        if (groupCodeValue !== '' && !isNaN(groupCodeValue) && parseFloat(groupCodeValue) > 0 && groupCodeValue.length <= 9) {
            groupCodeError.innerText = '';
        } else if (groupCodeValue.length > 9) {
            groupCodeError.innerText = 'Group Code cannot exceed 9 characters.';
        }
    });

    // Event listener for Group Name input
    groupNameInput.addEventListener('input', function () {
        const groupNameValue = groupNameInput.value.trim();
        if (groupNameValue !== '') {
            groupNameError.innerText = '';
        }
    });
});
