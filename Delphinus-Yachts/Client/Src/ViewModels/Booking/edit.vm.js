﻿(function () {
    var vm = new Vue({
        el: "#edit",
        data: {
            booking: {
                startLocation: 'Split',
                endLocation: 'Split',
                startDate: '',
                endDate: ''
            },
            isNew: true,
            isLoading: true
        },
        methods: {
            init: function () {
                axios.get(baseUrl + "api/bookings/" + this.booking.id).then((res) => {
                    this.booking = res.data;
                    this.isNew = false;
                    this.isLoading = false;
                });
            },
            save: function () {
                if (!this.isNew)
                    axios.put(baseUrl + "api/bookings", this.booking).then(() => location.reload());
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
            },
            initDatePicker() {
                var currentDate = new Date();
                var vm = this;
                setTimeout(function () {
                    vm.booking.startDate = currentDate.toISOString().slice(0, 10);
                    vm.booking.endDate = (new Date(currentDate.setDate(currentDate.getDate() + 7))).toISOString().slice(0, 10);
                    vm.isLoading = false;
                }, 50);
            }
        },
        created: function () {
            this.booking.id = utils.getIdFromUrl();

            if (this.booking.id != 0)
                this.init();
            else
                this.initDatePicker();
        }
    });
})();