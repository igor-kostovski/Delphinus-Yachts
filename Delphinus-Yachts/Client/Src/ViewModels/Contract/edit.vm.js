(function () {
    var vm = new Vue({
        el: "#edit",
        data: {
            contract: {}
        },
        methods: {
            init: function () {
                axios.get(baseUrl + "api/contracts/" + this.contract.id).then((res) => {
                    this.contract = res.data;
                });
            },
            save: function () {
                if (this.contract.id != 0)
                    axios.put(baseUrl + "api/contracts", this.contract);
                else
                    axios.post(baseUrl + "api/contracts", this.contract).then((res) => {
                        window.location.href += `/${res.data}`;
                    });
            }
        },
        created: function () {
            this.contract.id = utils.getIdFromUrl();
            if (this.contract.id != 0)
                this.init();
        }
    });
})();