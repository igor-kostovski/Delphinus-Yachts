(function () {
    var vm = new Vue({
        el: "#view",
        data: {
            bookings: {}
        },
        methods: {
            init() {
                var thisMonth = moment().startOf('month').format('MM-DD-YYYY');
                var threeMonthsForward = moment(thisMonth, 'MM-DD-YYYY').add(3, 'M').format('MM-DD-YYYY');

                this.getData([thisMonth, threeMonthsForward]);
            },
            onMonthsChange(startingDates) {
                var firstMonth = startingDates[0];
                var lastMonth = moment(startingDates[2], 'YYYY-MM-DD').add(1, 'M').format('MM-DD-YYYY');
                this.getData([firstMonth, lastMonth]);
            },
            getData(startingDates) {
                this.isLoading = true;
                axios.get(baseUrl + "api/availabilities?" + `fromDate=${startingDates[0]}&toDate=${startingDates[1]}`)
                    .then((res) => {
                        this.bookings = res.data;
                        this.isLoading = false;
                    })
            }
        },
        created() {
            this.init();
        }
    })
})();