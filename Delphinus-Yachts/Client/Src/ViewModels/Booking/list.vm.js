(function () {
    var vm = new Vue({
        el: "#table",
        data: {
            rows: [],
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
            }]
        },
        created: function () {
            axios.get(baseUrl + "api/bookings").then((res) => {
                this.rows = res.data;
            })
        }
    });
})();