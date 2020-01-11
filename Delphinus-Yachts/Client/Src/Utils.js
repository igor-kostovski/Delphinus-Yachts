(function (window, utils) {
    utils.getIdFromUrl = function () {
        var url = window.location.pathname;
        return +url.substring(url.lastIndexOf("/") + 1) || 0;
    };

    utils.formatDate = function (date) {
        return moment(date, 'YYYY-MM-DD').format('DD-MM-YYYY');
    };
})(window, window.utils = window.utils || {});