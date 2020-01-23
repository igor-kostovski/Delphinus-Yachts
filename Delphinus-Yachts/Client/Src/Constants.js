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

    constants.contractListColumns = [{
        label: "Paying passenger",
        name: "payingPassenger"
    },
    {
        label: "Price",
        name: "price"
    },
    {
        label: "Type",
        name: "typeAsString"
    },
    {
        label: "APA",
        name: "apa"
    },
    {
        label: "Tax",
        name: "tax"
    },
    {
        label: "Discount",
        name: "discount"
    }];

    constants.locationListColumns = [{
        label: 'Name',
        name: 'name'
    }];

    constants.routeListColumns = [{
        label: 'Name',
        name: 'name'
    }];

    constants.tableConfig = {
        pagination: true,
        card_mode: false,
        show_refresh_button: false,
        per_page_options: [10],
        pagination_info: false,
        show_reset_button: false,
        server_mode: true,
        global_search: {
            visibility: false
        }
    };

    constants.datePickerOptions = {
        colors: {
            selected: '#41579F',
            inRange: '#A6A6A8',
            selectedText: '#fff',
            text: '#565a5c',
            inRangeBorder: '#719BE6',
            disabled: '#fff',
            hoveredInRange: '#212529'
        }
    };
})(window, window.constants = window.constants || {});