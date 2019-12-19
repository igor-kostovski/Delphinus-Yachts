(function () {
    var vm = new Vue({
        el: "#table",
        data: {
            isLoading: false,
            rows: [],
            count: 0,
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
            },
            queryParams: {
                sort: [],
                filters: [],
                global_search: "",
                per_page: 10,
                page: 1,
            },
        },
        methods: {
            onChangeQuery(queryParams) {
                this.queryParams = queryParams;
                this.getTableData();
            },
            getTableData() {
                this.isLoading = true;
                axios.get(baseUrl + "api/bookings", {
                    params: {
                        "query": this.queryParams.global_search,
                        "page": this.queryParams.page,
                        "limit": this.queryParams.per_page
                    }
                }).then((res) => {
                    this.rows = res.data.data;
                    this.count = res.data.count;
                    this.isLoading = false;
                });
            }
        },
        created: function () {
            this.getTableData();
        }
    });
})();