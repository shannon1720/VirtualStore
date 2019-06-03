$(document).ready(function () {
    $('#btnModify').hide();
    $('#btnProduct').hide();
    $('#btnInventory').hide();
    sessionStorage.setItem("email", "jocular@gmail.com");
    var vretrieveStore = new vRetrieveStore();
    vretrieveStore.RetrieveAll();  
});

function vRetrieveStore() {

    this.tblStoreId = 'tblStore';
    this.service = 'Store';
    this.ctrlActions = new ControlActions();
    this.columns = "Name,Phone,Earnings";

    this.RetrieveAll = function () {
        var userEmail = sessionStorage.getItem("email");
        var service = 'Store?email=' + userEmail +'&name=storeadmin';
        this.ctrlActions.FillTable(service, this.tblStoreId, false);
    };

    this.ReloadTable = function () {
        var userEmail = sessionStorage.getItem("email");
        var service = 'Store?email=' + userEmail + '&name=storeadmin';
        this.ctrlActions.FillTable(service, this.tblStoreId, true);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('StoreForm', data);
        sessionStorage.setItem("IdCellar", data.IdCellar);
        sessionStorage.setItem("IdStore", data.Id);
        sessionStorage.setItem("State", data.State);
        swal("Se ha seleccionado a", data.Name, "success");
        var state = data.State;
        this.validateState(state);
        $('#btnModify').show();
        $('#btnProduct').show();
        $('#btnInventory').show();
    };

    this.validateState = function (state) {

        if (state === 'Activado') {
            $('#btnActive').hide();
            $('#btnDelete').show();


        } else {

            $('#btnDelete').hide();
            $('#btnActive').show();
        }

    };

    this.Inventory = function () {
        window.location.href = "http://localhost:52014/Product/vRetrieveProduct"; 
    };

    this.Modify = function () {
        window.location.href = "http://localhost:52014/Store/vUpdateStore";
    };


    
}


