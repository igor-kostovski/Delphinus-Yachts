(function () {
    var vm = new Vue({
        el: "#table",
        data: {
            isLoading: false,
            rows: [],
            columns: [{
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
                name: "status"
            }],
            config: {
                show_refresh_button: false,
                per_page_options: [5, 10],
                pagination_info: false
            }
        },
        created: function () {
            this.isLoading = true;
            axios.get(baseUrl + "api/bookings").then((res) => {
                this.rows = res.data;
                this.isLoading = false;
            })
        }
    });
})();