(function () {
    var vm = new Vue({
        el: "#edit",
        data: {
            contract: {},
            isNew: true,
            isLoading: true
        },
        methods: {
            init: function () {
                axios.get(baseUrl + "api/contracts/" + this.contract.id).then((res) => {
                    this.contract = res.data;
                    this.isNew = false;
                    this.isLoading = false;
                });
            },
            save: function () {
                if (!this.isNew)
                    axios.put(baseUrl + "api/contracts", this.contract).then(() => location.reload());
                else
                    axios.post(baseUrl + "api/contracts", this.contract).then((res) => {
                        window.location.href = baseUrl + 'Contracts/Edit' + `/${res.data}`;
                    });
            }
        },
        created: function () {
            this.contract.id = utils.getIdFromUrl();
            if (this.contract.id != 0)
                this.init();
            else {
                this.contract.id = utils.getQueryStringParam(window.location.search, 'bookingId');
                this.isLoading = false;
            }
        }
    });
})();