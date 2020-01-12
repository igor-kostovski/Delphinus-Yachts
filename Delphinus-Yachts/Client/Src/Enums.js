(function (window, enums) {
    enums.bookingStatus = {
        complete: 'Complete',
        optional: 'Optional',
        cancelled: 'Cancelled'
    };

    enums.contractType = {
        myba: 'Myba',
        nonMyba: 'NonMyba'
    };
})(window, window.enums = window.enums || {});