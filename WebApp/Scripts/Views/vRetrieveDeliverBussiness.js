function vRetrieveDeliverBussiness() {
    this.tblDeliversId = 'tblDeliver';
    this.service = 'Deliver';
    this.ctrlActions = new ControlActions();
    this.columns = "Cédula,Nombre,Primer apellido,Segundo apellido,Email, Número de teléfono, Estado";

    this.RetrieveAll = function () {
        var emailBussiness = sessionStorage.getItem('email');
        var service = 'Deliver?Email=' + emailBussiness;
        this.ctrlActions.FillTable(service, this.tblDeliversId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblDeliversId, true);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmDeliver', data);
        sessionStorage.setItem("Deliver", JSON.stringify(data));
        sessionStorage.setItem("Email", JSON.stringify(data.Email));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        swal("Se ha seleccionado a", data.Name_1, "success");
        var active = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data.State)));
        this.validateState(active);
    };

    this.validateState = function (state) {
        if (state === "Activado") {
            $('#btnActive').hide();
            $('#btnDelete').show();
        }
        else {

            $('#btnDelete').hide();
            $('#btnActive').show();
        }
    };

        this.Delete =  function (data) {
        try {

            var Email = JSON.parse(sessionStorage.getItem("Email"));
            var active = JSON.parse(sessionStorage.getItem("State"));
            var deliver = { "Email": Email };

            this.ctrlActions.DeleteToAPI(this.service, deliver);

            if (active === true) {
                swal("Se desactivo con Éxito!", "", "success");
            } else {
                swal("Se activo con Éxito!","", "success");
            }
            sessionStorage.removeItem("Id");
            sessionStorage.removeItem("State");

            $('#btnActive').hide();
            $('#btnDelete').hide();

            for (var i = 0; i < 50; i++) {
                this.ReloadTable();
            }
             

        } catch (e) {
            console.log("error ==>" + e);
            swal("Hubo un error, intentelo denuevo.", "", "error");
        }
    };
}



$(document).ready(function () {

    var vretrieve = new vRetrieveDeliverBussiness();
    vretrieve.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
});