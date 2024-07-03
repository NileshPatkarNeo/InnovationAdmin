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
