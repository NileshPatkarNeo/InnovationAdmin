function toggleDropdown() {
    var dropdownMenu = document.getElementById('dropdownMenu');
    if (dropdownMenu.style.display === 'block') {
        dropdownMenu.style.display = 'none';
    } else {
        dropdownMenu.style.display = 'block';
    }
}

function selectType(type) {
    document.getElementById('Type').value = type;
    document.getElementById('dropdownMenu').style.display = 'none';
}

$(document).ready(function () {
    $('#receiptBatchForm').on('submit', function (e) {
        var isValid = true;
        $('.text-danger').text('');

        var name = $('#Name').val();
        if (!name) {
            isValid = false;
            $('#Name').next('.text-danger').text('Name is required.');
        } else if (name.length > 50) {
            isValid = false;
            $('#Name').next('.text-danger').text('Name cannot exceed 50 characters.');
        }

        var type = $('#Type').val();
        if (!type) {
            isValid = false;
            $('#Type').next('.text-danger').text('Type is required.');
        }

        if (!isValid) {
            e.preventDefault();
        }
    });
});

function onlyAlphabets(e, t) {
    try {
        var charCode = e ? (e.which ? e.which : e.keyCode) : window.event.keyCode;
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123)) {
            return true;
        } else {
            return false;
        }
    } catch (err) {
        alert(err.Description);
    }
}

document.addEventListener('click', function (event) {
    var dropdownButton = document.querySelector('.dropdown-button');
    var dropdownMenu = document.getElementById('dropdownMenu');

    if (!dropdownButton.contains(event.target) && !dropdownMenu.contains(event.target)) {
        dropdownMenu.style.display = 'none';
    }
});