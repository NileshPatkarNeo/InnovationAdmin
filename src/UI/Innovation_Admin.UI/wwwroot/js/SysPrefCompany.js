$(document).ready(function () {
    $('#searchButton').on('click', function () {
        searchTable();
    });

    $('#sortButton').on('click', function () {
        sortTable();
    });

    $('#searchInput').on('input', function () {
        if (!this.value) {
            resetTable();
        }
    });
});

function searchTable() {
    var value = $('#searchInput').val().toLowerCase();
    $('#tableBody tr').each(function () {
        var companyName = $(this).find('td:eq(2)').text().toLowerCase();
        $(this).toggle(companyName.includes(value));
    });
}

function resetTable() {
    $('#tableBody tr').show();
}

function sortTable() {
    var rows = $('#tableBody tr').get();
    var order = $('#sortButton').data('order') || 'asc';

    rows.sort(function (a, b) {
        var valueA = parseInt($(a).find('td:eq(0)').text());
        var valueB = parseInt($(b).find('td:eq(0)').text());

        if (order === 'asc') {
            return valueA - valueB;
        } else {
            return valueB - valueA;
        }
    });

    $.each(rows, function (index, row) {
        $('#tableBody').append(row);
    });

    $('#sortButton').data('order', order === 'asc' ? 'desc' : 'asc');
    $('#sortButton').find('i').toggleClass('bi-sort-numeric-down bi-sort-numeric-up');
}


function confirmDelete(companyId) {
    if (confirm("Are you sure?")) {
        var form = document.createElement("form");
        form.method = "post";
        form.action = "/Common/DeleteSysPrefCompany";

        var hiddenField = document.createElement("input");
        hiddenField.type = "hidden";
        hiddenField.name = "companyId";
        hiddenField.value = companyId;
        form.appendChild(hiddenField);

        document.body.appendChild(form);
        form.submit();
    }
}