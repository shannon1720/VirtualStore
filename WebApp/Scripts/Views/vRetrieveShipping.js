function vRetrieveShipping() {
    this.tblShippingId = 'tblShipping';
    this.service = 'shipping';
    this.ctrlActions = new ControlActions();
    this.columns = "#,Nombre,Número de teléfono,Tarifa Base,Tarifa por kilómetro";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblShippingId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblShippingId, true);
    };
    

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmShipping', data);
        sessionStorage.setItem("Identification", JSON.stringify(data.Identification));
        sessionStorage.setItem("Name", JSON.stringify(data.Name));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        swal("Se ha seleccionado a", data.Name, "success");
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        this.validateState(state);

    };


 
    this.Delete = function (data) {

        var identification = JSON.parse(sessionStorage.getItem("Identification", JSON.stringify(data)));
        var name = JSON.parse(sessionStorage.getItem("Name", JSON.stringify(data)));
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        var shipping = { "Identification": identification };
        if (identification !== null) {
            
            this.ctrlActions.DeleteToAPI(this.service, shipping);
            if (state === "Activado") {
                swal("Se desactivo con éxito", "", "success");
                sessionStorage.removeItem("State");

            } else {
                swal("Se activo con éxito", "", "success");
                sessionStorage.removeItem("State");
            }
           
            this.ReloadTable();
            sessionStorage.removeItem("Identification");

            this.ReloadTable();
            $('#btnActive').hide();
            $('#btnDelete').hide();
            this.ReloadTable();
            this.ReloadTable();
            this.ReloadTable();
            this.ReloadTable();
            this.ReloadTable(); 
            // location.reload();
        } else {
            this.ctrlActions.ShowMessage('E', 'No ha seleccionado nigún proveedor de envío,por favor seleccionar uno.');
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

    var vretrieveShipping = new vRetrieveShipping();
    vretrieveShipping.RetrieveAll();

    $('#btnActive').hide();
    $('#btnDelete').hide();
});

