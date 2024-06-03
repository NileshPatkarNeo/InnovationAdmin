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
        if (!defaultPaymentMethod) {
            $('#defaultPaymentMethodError').text('Default Payment Method is required.');
            return false;
        } else if (defaultPaymentMethod.length > 100) {
            $('#defaultPaymentMethodError').text('Default Payment Method cannot exceed 100 characters.');
            return false;
        } else {
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
        var regex = /^[a-zA-Z]+\d*$/; // Regex to match a string followed by numbers
        if (!description) {
            $('#defaultReceiptBatchDescriptionError').text('Default Receipt Batch Description is required.');
            return false;
        } else if (!regex.test(description)) {
            $('#defaultReceiptBatchDescriptionError').text('Default Receipt Batch Description must start with letters followed by numbers.');
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
        } else if (threshold < 0) {
            $('#claimPaidThresholdError').text('Claim Paid Threshold must be a non-negative value.');
            return false;
        } else {
            $('#claimPaidThresholdError').text('');
            return true;
        }
    }

    function validateClaimStatusWriteOff() {
        var statusWriteOff = $('#ClaimStatusWriteOff').val();
        var regex = /^[a-zA-Z]+\d*$/; // Regex to match a string followed by numbers
        if (!statusWriteOff) {
            $('#claimStatusWriteOffError').text('Claim Status Write Off is required.');
            return false;
        } else if (!regex.test(statusWriteOff)) {
            $('#claimStatusWriteOffError').text('Claim Status Write Off must start with letters followed by numbers.');
            return false;
        } else if (statusWriteOff.length > 200) {
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
        } else if (daysToBlock < 0) {
            $('#daysToBlockError').text('Days To Block must be a non-negative value.');
            return false;
        } else {
            $('#daysToBlockError').text('');
            return true;
        }
    }

    $('form').submit(function (event) {
        if (!validateCompanyID() ||
            !validateDefaultPaymentMethod() ||
            !validateLastCheckNo() ||
            !validateClaimAgeCollectionStart() ||
            !validateClaimAgeCollectionEnd() ||
            !validateDefaultReceiptBatchDescription() ||
            !validateClaimPaidThreshold() ||
            !validateClaimStatusWriteOff() ||
            !validateDaysToBlock()) {
            event.preventDefault();
        }
    });

    $('#CompanyID').change(validateCompanyID);
    $('#DefaultPaymentMethod').keyup(validateDefaultPaymentMethod);
    $('#LastCheckNo').keyup(validateLastCheckNo);
    $('#ClaimAgeCollectionStart').change(validateClaimAgeCollectionStart);
    $('#ClaimAgeCollectionEnd').change(validateClaimAgeCollectionEnd);
    $('#DefaultReceiptBatchDescription').keyup(validateDefaultReceiptBatchDescription);
    $('#ClaimPaidThreshold').keyup(validateClaimPaidThreshold);
    $('#ClaimStatusWriteOff').keyup(validateClaimStatusWriteOff);
    $('#DaysToBlock').keyup(validateDaysToBlock);
});