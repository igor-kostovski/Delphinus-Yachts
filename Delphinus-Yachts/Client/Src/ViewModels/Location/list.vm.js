(function () {
    var vm = new Vue({
        el: "#table",
        data: {
            isLoading: false,
            rows: [],
            count: 0,
            columns: constants.locationListColumns,
            config: constants.tableConfig
        },
        methods: {
            getTableData(searchText = null) {
                this.isLoading = true;
                axios.get(baseUrl + "api/locations", {
                    params: {
                        "query": searchText,
                        "page": constants.tablePaginationConfig.page,
                        "limit": constants.tablePaginationConfig.perPage
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