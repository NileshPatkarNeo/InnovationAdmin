$(document).ready(function () {
    $('#createForm').submit(function (event) {
        var recordsLockedSeconds = $('#Records_Locked_Seconds').val();
        var userTimeout = $('#User_Timeout').val();
        var isValid = true;

        if (recordsLockedSeconds < 0) {
            $('#Records_Locked_Seconds').addClass('input-validation-error');
            $('span[data-valmsg-for="Records_Locked_Seconds"]').text('Invalid seconds').addClass('text-danger');
            isValid = false;
        } else {
            $('#Records_Locked_Seconds').removeClass('input-validation-error');
            $('span[data-valmsg-for="Records_Locked_Seconds"]').text('');
        }

        if (userTimeout < 0) {
            $('#User_Timeout').addClass('input-validation-error');
            $('span[data-valmsg-for="User_Timeout"]').text('Invalid timeout').addClass('text-danger');
            isValid = false;
        } else {
            $('#User_Timeout').removeClass('input-validation-error');
            $('span[data-valmsg-for="User_Timeout"]').text('');
        }

        if (!isValid) {
            event.preventDefault();
        }
    });
});
