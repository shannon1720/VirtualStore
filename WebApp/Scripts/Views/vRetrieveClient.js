//ON DOCUMENT READY
$(document).ready(function () {
    var vretrieveClient = new vRetrieveClient();
    vretrieveClient.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
});

function vRetrieveClient() {
    this.tblClientId = 'tblClient';
    this.service = 'client';
    this.ctrlActions = new ControlActions();
    this.columns = "Correo Electronico, Estado";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblClientId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblClientId, true);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('tblClient', data);
        sessionStorage.setItem("Email", JSON.stringify(data.Email));
        sessionStorage.setItem("Active", JSON.stringify(data.Active));
        swal("Se ha seleccionado a", data.Email, "success");
        var active = JSON.parse(sessionStorage.getItem("Active", JSON.stringify(data.Active)));
        this.validateState(active);
    };

    this.validateState = function (active) {

        if (active === true) {
            $('#btnActive').hide();
            $('#btnDelete').show();
        }
        else {

            $('#btnDelete').hide();
            $('#btnActive').show();
        }
    };

    this.Delete =  async function (data) {
        try {

            var email = JSON.parse(sessionStorage.getItem("Email", JSON.stringify(data)));
            var active = JSON.parse(sessionStorage.getItem("Active", JSON.stringify(data)));
            var client = { "Email": email };

            await this.ctrlActions.DeleteToAPI(this.service, client);

            if (active === true) {
                swal("Se desactivo con Éxito", "", "success");
            } else {     
                swal("Se activo con Éxito", "", "success");
            }
            sessionStorage.removeItem("Email");
            sessionStorage.removeItem("Active");

            $('#btnActive').hide();
            $('#btnDelete').hide();

            await this.ReloadTable(); 
            await this.ReloadTable(); 
            await this.ReloadTable(); 
            await this.ReloadTable(); 
            
        } catch (e) {
            swal("Hubo un error, intentelo denuevo.", "", "success");
        }
    };
}

