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
                name: "statusAsString"
            }],
            config: {
                card_mode: false,
                show_refresh_button: false,
                per_page_options: [5, 10],
                pagination_info: false,
                show_reset_button: false,
                server_mode: true,
                global_search: {
                    visibility: false
                }
            },
            queryParams: {
                per_page: 10,
                page: 1,
            },
            searchText: "",
            timer: {}
        },
        methods: {
            onChangeQuery(queryParams) {
                if (!this.areEqual(queryParams)) {
                    this.queryParams = queryParams;
                    this.getTableData();
                }
            },
            getTableData() {
                this.isLoading = true;
                axios.get(baseUrl + "api/bookings", {
                    params: {
                        "query": this.searchText,
                        "page": this.queryParams.page,
                        "limit": this.queryParams.per_page
                    }
                }).then((res) => {
                    this.rows = res.data.data;
                    this.count = res.data.count;
                    this.isLoading = false;
                });
            },
            areEqual(queryParams) {
                var page = queryParams.page == this.queryParams.page;
                var per_page = queryParams.per_page == this.queryParams.per_page;

                return page && per_page;
            },
            changeSearchText() {
                clearTimeout(this.timer);
                this.timer = setTimeout(() => this.getTableData(), 1000);
            }
        },
        created: function () {
            this.getTableData();
        }
    });
})();