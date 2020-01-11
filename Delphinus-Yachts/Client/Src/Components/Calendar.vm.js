(function () {
    Vue.use(window.AirbnbStyleDatepicker, constants.datePickerOptions);

    var calendar = {
        template: `
        <div class="datepicker-container inline-with-input">
            <span id="trigger"></span>
            <airbnb-style-datepicker
                :trigger-element-id="'trigger'"
                :mode="'single'"
                :inline="true"
                :months-to-show="2"
                v-on:previous-month="onMonthChange"
                v-on:next-month="onMonthChange"
                :bookings="data"
                :calendar-mode="true"
                v-on:show-popup="showPopup"
            ></airbnb-style-datepicker>
        </div>
        `,
        props: ["data"],
        methods: {
            onMonthChange(startingDates) {
                this.$emit('on-months-change', startingDates);
            },
            showPopup(bookings) {
                this.$emit("on-popup-change", bookings);
            }
        }
    };

    Vue.component('calendar-component', calendar);
})();