function vRetrieveSellerPlatform() {
    this.tblSellerID = 'tblSeller';
    this.service = 'SellerStore';
    this.ctrlActions = new ControlActions();
    this.columns = "Identificación,Primer Nombre,Segundo Nombre,Primer Apellido,Segundo Apellido,Número de telefono,Email,Tienda";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblSellerID, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblSellerID, true);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmSeller', data);

        sessionStorage.setItem("ID", JSON.stringify(data.Id));
        sessionStorage.setItem("Email", JSON.stringify(data.Email));
        sessionStorage.setItem("Name_1", JSON.stringify(data.Name_1));
        sessionStorage.setItem("Last_Name_1", JSON.stringify(data.Last_Name_1));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        var state = JSON.parse(sessionStorage.getItem("State", JSON.    stringify(data)));
        var email = JSON.parse(sessionStorage.getItem("Email", JSON.stringify(data)));
        swal("Se ha seleccionado a", data.Email, "success");
        this.validateState(state);
    };

    this.Delete = async function (data) {
        var email = JSON.parse(sessionStorage.getItem("Email", JSON.stringify(data)));
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));

        //var seller = { "Email": email, "State": "desactivado" };
        if (email != null) {
            if (state === "Activado") {
                seller = { "Email": email, "State": "desactivado" };
                sessionStorage.removeItem("State");
                swal("Se desactivo con Éxito!", "", "success");

            } else {
                seller = { "Email": email, "State": "activado" };
                sessionStorage.removeItem("State");
                swal("Se activo con Éxito!", "", "success");

            }
            this.ctrlActions.DeleteToAPI(this.service, seller);
            this.ReloadTable();
            sessionStorage.removeItem("Email");

            //this.ReloadTable();
            $('#btnActive').show();
            $('#btnDelete').show();
            await this.ReloadTable();
            //sessionStorage.removeItem("Email");
            // location.reload();
        } else {

            swal("Hubo un error, intentelo denuevo.", "", "success");
        }
    };

    this.validateState = function (a) {

        if (a === 'Activado') {
            $('#btnActive').hide();
            $('#btnDelete').show();
        }
        else {

            $('#btnDelete').hide();
            $('#btnActive').show();
        }
    };
}
//ON DOCUMENT READY
$(document).ready(function () {

    var vretrieveSeller = new vRetrieveSellerPlatform();
    vretrieveSeller.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
});
