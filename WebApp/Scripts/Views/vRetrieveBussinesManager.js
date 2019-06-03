function vRetrieveBussinesManager() {
    this.tblBussinessManagerId = 'tblBussinessManager';
    this.service = 'bussinesManager';
    this.ctrlActions = new ControlActions();
    this.columns = "Identificación,Primer Nombre,Segundo Nombre,Primer Apellido,Segundo Apellido,Número de telefono,Email,Empresa";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblBussinessManagerId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblBussinessManagerId, true);
    };


    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmBussines', data);

        sessionStorage.setItem("Id", JSON.stringify(data.Id));
        sessionStorage.setItem("Email", JSON.stringify(data.Email));
        sessionStorage.setItem("Name_1", JSON.stringify(data.Name_1));
        sessionStorage.setItem("LastName_1", JSON.stringify(data.LastName_1));
        sessionStorage.setItem("Active", JSON.stringify(data.Active));
        var state = JSON.parse(sessionStorage.getItem("Active", JSON.stringify(data)));
        var email = JSON.parse(sessionStorage.getItem("Email", JSON.stringify(data)));
        swal("Se ha seleccionado a", email, "success");
        this.validateState(state);
    };

    this.Delete = function (data) {


        var email = JSON.parse(sessionStorage.getItem("Email", JSON.stringify(data)));
        var state = JSON.parse(sessionStorage.getItem("Active", JSON.stringify(data)));

        var bussines = { "Email": email, "Active": "desactivado"  };
        if (email != null) {
            this.ctrlActions.DeleteToAPI(this.service, bussines);
            if (state === "Activado") {
                swal("Se desactivo con éxito", "", "success");
                sessionStorage.removeItem("Active");

            } else {
                swal("Se activo con éxito", "", "success");
                sessionStorage.removeItem("Active");
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
            sessionStorage.removeItem("Email");
        } else {

            this.ctrlActions.ShowMessage('E', 'No ha seleccionado ningún administrador de proveedor de envío,por favor seleccionar uno.');
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

    var vretrieveBussinesManager = new vRetrieveBussinesManager();
    vretrieveBussinesManager.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
});
