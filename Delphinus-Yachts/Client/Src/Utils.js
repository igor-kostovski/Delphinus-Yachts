(function (window, utils) {
    utils.getIdFromUrl = function () {
        var url = window.location.pathname;
        return +url.substring(url.lastIndexOf("/") + 1) || 0;
    };

    utils.formatDate = function (date) {
        return moment(date, 'YYYY-MM-DD').format('DD-MM-YYYY');
    };

    utils.getQueryStringParam = function (queryString, paramName) {
        const urlParams = new URLSearchParams(queryString);
        if (!urlParams.has(paramName))
            return 0;
        return +urlParams.get(paramName);
    };
})(window, window.utils = window.utils || {});