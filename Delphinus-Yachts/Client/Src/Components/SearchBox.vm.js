(function () {
    var searchBox = {
        template: `
            <input 
                type="text" 
                class="form-control bg-light border-0 small" 
                placeholder="Search for..." 
                aria-label="Search" 
                aria-describedby="basic-addon2"
                v-on:input="changeSearchText()"
                v-model="searchText"
            />`,
        data: function () {
            return {
                timer: {},
                searchText: ""
            };
        },
        methods: {
            changeSearchText() {
                var vm = this;
                clearTimeout(this.timer);
                this.timer = setTimeout(() => vm.$emit('get-table-data', vm.searchText), 1000);
                localStorage.searchText = this.searchText;
            }
        },
        created: function () {
            this.searchText = localStorage.searchText;
        }
    };
    Vue.component('search-box', searchBox);
})()