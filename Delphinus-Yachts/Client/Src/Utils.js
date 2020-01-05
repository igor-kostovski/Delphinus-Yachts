(function (window, utils) {
    utils.getIdFromUrl = function () {
        var url = window.location.pathname;
        return +url.substring(url.lastIndexOf("/") + 1) || 0;
    };
})(window, window.utils = window.utils || {});