(function () {
    var vm = new Vue({
        el: "#table",
        data: {
            isLoading: false,
            rows: [],
            count: 0,
            columns: constants.locationListColumns,
            config: constants.tableConfig,
            queryParams: {
                per_page: 10,
                page: 1,
            },
            isTableSetup: false
        },
        methods: {
            getTableData(searchText = null) {
                this.isLoading = true;
                axios.get(baseUrl + "api/locations", {
                    params: {
                        "query": searchText,
                        "page": this.queryParams.page,
                        "limit": this.queryParams.per_page
                    }
                }).then((res) => {
                    this.rows = res.data.data;
                    this.count = res.data.count;
                    this.isLoading = false;
                    this.addTableStyle();
                });
            },
            onChangeQuery(queryParams) {
                if (this.isTableSetup) {
                    var areSame = this.queryParams.page == queryParams.page && this.queryParams.per_page == queryParams.per_page;
                    if (!areSame) {
                        this.queryParams = {
                            per_page: queryParams.per_page,
                            page: queryParams.page
                        };
                        this.isTableSetup = false;
                        this.getTableData();
                    }
                }
            },
            addTableStyle() {
                if (!this.isLoading) {
                    var vm = this;
                    setTimeout(function () {
                        var unwantedElement = document.querySelector('[step="1"]');
                        unwantedElement.remove();
                        vm.isTableSetup = true;
                        var paginationParent = document.querySelector(".pagination");
                        paginationParent.querySelector(".active").classList.remove("active");
                        paginationParent.querySelector(".disabled").classList.remove("disabled");
                        [...paginationParent.querySelectorAll(".page-item")].filter(x => x.innerText == vm.queryParams.page)[0].classList.add("active");
                        document.querySelector('.vbt-per-page-dropdown').remove();
                    }, 50);
                }
            }
        },
        created: function () {
            this.getTableData();
        }
    });
})();