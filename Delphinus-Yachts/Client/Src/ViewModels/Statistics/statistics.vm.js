(function () {
    var vm = new Vue({
        el: '#statistics',
        data: {
            statistics: {},
            isLoading: true
        },
        methods: {
            init() {
                this.getStatisticsData();
            },
            getStatisticsData() {
                axios.get(baseUrl + 'api/statistics').then((res) => {
                    this.statistics = res.data;
                    this.isLoading = false;
                })
            }
        },
        created() {
            this.init();
        }
    });
})();