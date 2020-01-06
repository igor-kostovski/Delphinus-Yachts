(function () {
    var vm = new Vue({
        el: "#edit",
        data: {
            booking: {
                startLocation: 'Split',
                endLocation: 'Split',
                startDate: '',
                endDate: ''
            }
        },
        methods: {
            init: function () {
                axios.get(baseUrl + "api/bookings/" + this.booking.id).then((res) => {
                    this.booking = res.data;
                });
            },
            save: function () {
                if (this.booking.id != 0)
                    axios.put(baseUrl + "api/bookings", this.booking);
                else
                    axios.post(baseUrl + "api/bookings", this.booking).then((res) => {
                        window.location.href += `/${res.data}`;
                    });
            },
            changeStartDate(date) {
                this.booking.startDate = date;
            },
            changeEndDate(date) {
                this.booking.endDate = date;
            }
        },
        created: function () {
            this.booking.id = utils.getIdFromUrl();

            if (this.booking.id != 0)
                this.init();
            else {
                var currentDate = new Date();
                this.booking.startDate = currentDate.toISOString().slice(0, 10);
                this.booking.endDate = (new Date(currentDate.setDate(currentDate.getDate() + 7))).toISOString().slice(0, 10);
            }
        }
    });
})();