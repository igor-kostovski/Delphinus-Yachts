(function () {
    var vm = new Vue({
        el: "#table",
        data: {
            isLoading: false,
            rows: [],
            count: 0,
            columns: constants.bookingListColumns,
            config: constants.tableConfig,
            queryParams: constants.tableQueryParams
        },
        methods: {
            onChangeQuery(queryParams) {
                if (!this.areEqual(queryParams)) {
                    this.queryParams = queryParams;
                    this.getTableData();
                }
            },
            getTableData(searchText = null) {
                this.isLoading = true;
                axios.get(baseUrl + "api/bookings", {
                    params: {
                        "query": searchText,
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
            }
        },
        created: function () {
            this.getTableData();
        }
    });
})();