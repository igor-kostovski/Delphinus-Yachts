(function (window, constants) {

    constants.bookingListColumns = [{
        label: "Booking number",
        name: "number"
    },
    {
        label: "Start date",
        name: "startDate"
    },
    {
        label: "Start location",
        name: "startLocation"
    },
    {
        label: "End location",
        name: "endLocation"
    },
    {
        label: "Status",
        name: "statusAsString"
    }];

    constants.tableConfig = {
        card_mode: false,
        show_refresh_button: false,
        per_page_options: [5, 10],
        pagination_info: false,
        show_reset_button: false,
        server_mode: true,
        global_search: {
            visibility: false
        }
    };

    constants.tableQueryParams = {
        per_page: 10,
        page: 1,
    };

})(window, window.constants = window.constants || {});