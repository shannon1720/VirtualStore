function vRetrieveStore() {

    this.tblStoreId = 'tblStore';
    this.service = 'store';
    this.ctrlActions = new ControlActions();
    //this.columns = "Id,Name,PhoneNumber,State";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblStoreId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblStoreId, true);
    };



    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmStore', data);
        sessionStorage.setItem("Id", JSON.stringify(data.Id));
        sessionStorage.setItem("Name", JSON.stringify(data.Name));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        swal("Se ha seleccionado a", data.Name, "success");
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        this.validateState(state);

    };
    this.Delete = function (data) {

        var id = JSON.parse(sessionStorage.getItem("Id", JSON.stringify(data)));
        var name = JSON.parse(sessionStorage.getItem("Name", JSON.stringify(data)));
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        var store = {"Id":id};
        if (id != null) {

            this.ctrlActions.DeleteToAPI(this.service, store);
            if (state === "Activado") {
                swal("Se desactivo con éxito", "", "success");
                sessionStorage.removeItem("State");

            } else {
                swal("Se activo con éxito", "", "success");
                sessionStorage.removeItem("State");
            }
            
            this.ReloadTable();
            sessionStorage.removeItem("Id");
            $('#btnActive').hide();
            $('#btnDelete').hide();
            this.ReloadTable();
          
            this.ReloadTable();
            this.ReloadTable();

            this.ReloadTable();
            this.ReloadTable();

            this.ReloadTable();
            // location.reload();
        } else {

            this.ctrlActions.ShowMessage('E', 'No ha seleccionado niguna tienda,por favor seleccionar uno.');
        }


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






}


//ON DOCUMENT READY
$(document).ready(function () {

    var vretrieveStore = new vRetrieveStore();
    vretrieveStore.RetrieveAll();
    $('#btnDelete').hide();
    $('#btnActive').hide();
});