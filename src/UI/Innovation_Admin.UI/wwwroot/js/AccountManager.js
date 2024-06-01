$(document).ready(function () {
    $('form').on('submit', function (e) {
        var isValid = true;
        var name = $('#Name').val().trim();

        // Clear previous error messages
        $('#name-error').text('');

        // Check if the name is required
        if (name === '') {
            isValid = false;
            $('#name-error').text('Name is required.');
        }

        // Check if the name length is greater than 20 characters
        if (name.length > 50) {
            isValid = false;
            $('#name-error').text('Name cannot be more than 50 characters.');
        }

        // If the form is not valid, prevent the form submission
        if (!isValid) {
            e.preventDefault();
        }
    });
});