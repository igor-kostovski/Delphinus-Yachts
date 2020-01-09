(function () {
    Vue.use(window.AirbnbStyleDatepicker, constants.datePickerOptions)

    var datepicker = {
        template: `
        <div class="datepicker-trigger">
            <input class="text-input" id="trigger-range" type="text" :value="showDate" readonly>
            <airbnb-style-datepicker
                :mode="'range'"
                :trigger-element-id="'trigger-range'"
                :date-one="startDate"
                :date-two="endDate"
                v-on:date-one-selected="changeStartDate"
                v-on:date-two-selected="changeEndDate"
            ></airbnb-style-datepicker>
        </div>
        `,
        props: ["start-date", "end-date"],
        data: function () {
            return {
                dateFormat: 'D MMM',
                errorMsg: 'Invalid date'
            }
        },
        computed: {
            showDate() {
                var date = {
                    year: moment(this.endDate, 'YYYY-MM-DD').year(),
                    start: moment(this.startDate, 'YYYY-MM-DD').format(this.dateFormat),
                    end: moment(this.endDate, 'YYYY-MM-DD').format(this.dateFormat)
                };

                Object.keys(date).forEach(x => {
                    if (date[x] == this.errorMsg || date[x] == 0)
                        date[x] = '';
                });

                return `${date.start} - ${date.end} ${date.year}`;
            }
        },
        methods: {
            changeStartDate(val) {
                this.$emit('change-start-date', val);
            },
            changeEndDate(val) {
                this.$emit('change-end-date', val);
            }
        }
    };

    Vue.component('date-picker', datepicker);
})()