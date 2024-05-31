$(document).ready(function () {
    function validateCompanyID() {
        var companyId = $('#CompanyID').val();
        if (!companyId) {
            $('#companyIDError').text('Company is required.');
            return false;
        } else {
            $('#companyIDError').text('');
            return true;
        }
    }

    function validateDefaultPaymentMethod() {
        var defaultPaymentMethod = $('#DefaultPaymentMethod').val();
        var regex = /^[a-zA-Z]+\d*$/;
        if (!defaultPaymentMethod) {
            $('#defaultPaymentMethodError').text('Default Payment Method is required.');
            return false;
        }  else {
            $('#defaultPaymentMethodError').text('');
            return true;
        }
    }

    function validateLastCheckNo() {
        var lastCheckNo = $('#LastCheckNo').val();
        if (!lastCheckNo) {
            $('#lastCheckNoError').text('Last Check No is required.');
            return false;
        } else if (lastCheckNo <= 0) {
            $('#lastCheckNoError').text('Last Check No must be a positive value.');
            return false;
        } else {
            $('#lastCheckNoError').text('');
            return true;
        }
    }

    function validateClaimAgeCollectionStart() {
        var startDate = $('#ClaimAgeCollectionStart').val();
        var today = new Date().toISOString().split('T')[0];
        if (!startDate) {
            $('#claimAgeCollectionStartError').text('Claim Age Collection Start is required.');
            return false;
        } else if (startDate < today) {
            $('#claimAgeCollectionStartError').text('Claim Age Collection Start must be today or later.');
            return false;
        } else {
            $('#claimAgeCollectionStartError').text('');
            return true;
        }
    }

    function validateClaimAgeCollectionEnd() {
        var startDate = $('#ClaimAgeCollectionStart').val();
        var endDate = $('#ClaimAgeCollectionEnd').val();
        if (!endDate) {
            $('#claimAgeCollectionEndError').text('Claim Age Collection End is required.');
            return false;
        } else if (endDate <= startDate) {
            $('#claimAgeCollectionEndError').text('Claim Age Collection End must be after Claim Age Collection Start.');
            return false;
        } else {
            $('#claimAgeCollectionEndError').text('');
            return true;
        }
    }

    function validateDefaultReceiptBatchDescription() {
        var description = $('#DefaultReceiptBatchDescription').val();
        var regex = /^[a-zA-Z]+\d*$/;
        if (!description) {
            $('#defaultReceiptBatchDescriptionError').text('Default Receipt Batch Description is required.');
            return false;
        } else if (!regex.test(description)) {
            $('#defaultReceiptBatchDescriptionError').text('Default Receipt Batch Description must be a string followed by numbers.');
            return false;
        } else if (description.length > 200) {
            $('#defaultReceiptBatchDescriptionError').text('Default Receipt Batch Description cannot exceed 200 characters.');
            return false;
        } else {
            $('#defaultReceiptBatchDescriptionError').text('');
            return true;
        }
    }

    function validateClaimPaidThreshold() {
        var threshold = $('#ClaimPaidThreshold').val();
        if (!threshold) {
            $('#claimPaidThresholdError').text('Claim Paid Threshold is required.');
            return false;
        } else if (threshold <= 0) {
            $('#claimPaidThresholdError').text('Claim Paid Threshold must be a Positive value.');
            return false;
        } else {
            $('#claimPaidThresholdError').text('');
            return true;
        }
    }

    function validateClaimStatusWriteOff() {
        var writeOff = $('#ClaimStatusWriteOff').val();
        if (!writeOff) {
            $('#claimStatusWriteOffError').text('Claim Status Write Off is required.');
            return false;
        } else if (writeOff.length > 200) {
            $('#claimStatusWriteOffError').text('Claim Status Write Off cannot exceed 200 characters.');
            return false;
        } else {
            $('#claimStatusWriteOffError').text('');
            return true;
        }
    }

    function validateDaysToBlock() {
        var daysToBlock = $('#DaysToBlock').val();
        if (!daysToBlock) {
            $('#daysToBlockError').text('Days To Block is required.');
            return false;
        } else if (daysToBlock <= 0) {
            $('#daysToBlockError').text('Days To Block must be a positive value.');
            return false;
        } else {
            $('#daysToBlockError').text('');
            return true;
        }
    }

    $('form').on('submit', function (e) {
        var isValid = true;

        if (!validateCompanyID()) isValid = false;
        if (!validateDefaultPaymentMethod()) isValid = false;
        if (!validateLastCheckNo()) isValid = false;
        if (!validateClaimAgeCollectionStart()) isValid = false;
        if (!validateClaimAgeCollectionEnd()) isValid = false;
        if (!validateDefaultReceiptBatchDescription()) isValid = false;
        if (!validateClaimPaidThreshold()) isValid = false;
        if (!validateClaimStatusWriteOff()) isValid = false;
        if (!validateDaysToBlock()) isValid = false;

        if (!isValid) {
            e.preventDefault();
        }
    });

    $('#CompanyID').on('change', validateCompanyID);
    $('#DefaultPaymentMethod').on('input', validateDefaultPaymentMethod);
    $('#LastCheckNo').on('input', validateLastCheckNo);
    $('#ClaimAgeCollectionStart').on('input', validateClaimAgeCollectionStart);
    $('#ClaimAgeCollectionEnd').on('input', validateClaimAgeCollectionEnd);
    $('#DefaultReceiptBatchDescription').on('input', validateDefaultReceiptBatchDescription);
    $('#ClaimPaidThreshold').on('input', validateClaimPaidThreshold);
    $('#ClaimStatusWriteOff').on('input', validateClaimStatusWriteOff);
    $('#DaysToBlock').on('input', validateDaysToBlock);
});