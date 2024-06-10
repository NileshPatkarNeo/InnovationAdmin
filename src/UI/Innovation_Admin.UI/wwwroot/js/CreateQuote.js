
$(document).ready(function () {
    $('#createQuoteForm').submit(function (e) {
        e.preventDefault(); 

        var name = $('#Name').val();
        var quoteBy = $('#QuoteBy').val();

        $('.text-danger').empty();

        if (!name) {
            $('#Name_error').text('Name is required');
            return false; 
        } else if (name.length > 26) {
            $('#Name_error').text('Name must be at most 26 characters long');
            return false; 
        }

        if (!quoteBy) {
            $('#QuoteBy_error').text('Quote By is required');
            return false; 
        } else if (quoteBy.length > 101) {
            $('#QuoteBy_error').text('Quote By must be at most 101 characters long');
            return false; 
        }

        this.submit();
    });
});
