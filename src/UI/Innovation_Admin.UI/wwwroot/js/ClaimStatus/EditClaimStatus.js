document.addEventListener('DOMContentLoaded', function () {
    var colorPicker = document.getElementById('colorPicker');
    var colorDisplay = document.getElementById('colorDisplay');

    colorPicker.addEventListener('input', function () {
        colorDisplay.style.backgroundColor = colorPicker.value;
    });

    colorPicker.addEventListener('change', function () {
        colorDisplay.style.backgroundColor = colorPicker.value;
    });
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
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}