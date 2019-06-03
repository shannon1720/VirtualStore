function vRetrieveStoreAdministrator() {
    this.tblStoreAdministratorId = 'tblStoreAdministrator';
    this.service = 'storeadministrator';
    this.ctrlActions = new ControlActions();
    

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblStoreAdministratorId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblStoreAdministratorId, true);
    };



    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmAdministratorStore', data);
        sessionStorage.setItem("Email", JSON.stringify(data.Email));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        swal("Se ha seleccionado a", data.Email, "success");
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        this.validateState(state);

    };
    this.Delete = function (data) {

        var email = JSON.parse(sessionStorage.getItem("Email", JSON.stringify(data)));
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        var storeAdmin = {"Email":email};
        try {

            this.ctrlActions.DeleteToAPI(this.service, storeAdmin);
            if (state === "Activado") {
                swal("Se desactivo con éxito", "", "success");
                sessionStorage.removeItem("State");

            } else {
                swal("Se activo con éxito", "", "success");
                sessionStorage.removeItem("State");
            }
            this.ReloadTable();
            sessionStorage.removeItem("Email");

            this.ReloadTable();
            $('#btnActive').hide();
            $('#btnDelete').hide();
            this.ReloadTable();
            this.ReloadTable();
            this.ReloadTable();
            this.ReloadTable(); 
       
        } catch (e) {
            swal("Hubo un error, intentelo denuevo.", "", "success");
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

    var vretrieveStoreAdministrator = new vRetrieveStoreAdministrator();
    vretrieveStoreAdministrator.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
});