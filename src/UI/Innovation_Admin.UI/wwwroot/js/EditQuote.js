
$(document).ready(function () {
    $('#editQuoteForm').submit(function (e) {
        e.preventDefault(); 

        var name = $('#Name').val();
        var quoteBy = $('#QuoteBy').val();

        $('.text-danger').empty();

        if (!name) {
            $('#Name_error').text('Name is required');
            return false; 
        } else if (name.length > 100) {
            $('#Name_error').text('Name must be at most 100 characters long');
            return false; 
        }

        if (!quoteBy) {
            $('#QuoteBy_error').text('Quote By is required');
            return false; 
        } else if (quoteBy.length > 25) {
            $('#QuoteBy_error').text('Quote By must be at most 25 characters long');
            return false; 
        }

        this.submit();
    });
});
