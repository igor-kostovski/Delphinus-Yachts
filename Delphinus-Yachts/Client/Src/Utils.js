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

    utils.chartNumberFormat = function(number, decimals, dec_point, thousands_sep) {
        number = (number + '').replace(',', '').replace(' ', '');
        var n = !isFinite(+number) ? 0 : +number,
            prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
            sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
            dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
            s = '',
            toFixedFix = function(n, prec) {
                var k = Math.pow(10, prec);
                return '' + Math.round(n * k) / k;
            };
        s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
        if (s[0].length > 3) {
            s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
        }
        if ((s[1] || '').length < prec) {
            s[1] = s[1] || '';
            s[1] += new Array(prec - s[1].length + 1).join('0');
        }
        return s.join(dec);
    };
})(window, window.utils = window.utils || {});