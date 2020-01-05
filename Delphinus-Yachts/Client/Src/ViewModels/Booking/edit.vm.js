(function () {
    var vm = new Vue({
        el: "#edit",
        data: {
            booking: {}
        },
        methods: {
            init: function () {
                axios.get(baseUrl + "api/bookings/" + this.booking.id).then((res) => {
                    this.booking = res.data;
                })
            },
            save: function () {
                if (this.booking.id != 0)
                    axios.put(baseUrl + "api/bookings", this.booking);
                else
                    axios.post(baseUrl + "api/bookings", this.booking);
            }
        },
        created: function () {
            this.booking.id = utils.getIdFromUrl();
            if (this.booking.id != 0)
                this.init();
        }
    });
})();