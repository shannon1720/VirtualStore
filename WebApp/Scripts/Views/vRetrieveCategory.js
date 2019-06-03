function vRetrieveCategory() {
    this.tblCategoryId = 'tblCategory';
    this.service = 'Category';
    this.ctrlActions = new ControlActions();
    this.columns = "#,Nombre, Estado";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblCategoryId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCategoryId, true);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        sessionStorage.setItem("ID", JSON.stringify(data.ID));
        sessionStorage.setItem("Name", JSON.stringify(data.Name));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        swal("Se ha seleccionado a", data.Name, "success");
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data))); 
        this.validateState(state);
        this.updateCategory;
    };

    this.Delete = async function (data) {

        var identification = JSON.parse(sessionStorage.getItem("ID", JSON.stringify(data)));
        var name = JSON.parse(sessionStorage.getItem("Name", JSON.stringify(data)));
        var state = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data)));
        var category = {};
        if (identification != null) {


            if (state === "Activado") {
                category = { "ID": identification, "Name": name, "State": "desactivado" };
                sessionStorage.removeItem("State");
                swal("Se desactivo con Éxito!", "", "success");

            } else {
                category = { "ID": identification, "Name": name, "State": "activado" };
                sessionStorage.removeItem("State");
                swal("Se activo con Éxito!", "", "success");
            }
            await this.ctrlActions.DeleteToAPI(this.service, category);
            sessionStorage.removeItem("ID");

             for (var i = 0; i < 50; i++) {
                 this.ReloadTable();
            }

            $('#btnActive').show();
            $('#btnDelete').show();
            await this.ReloadTable();

        } else {
            swal("Hubo un error, intentelo denuevo.", "", "success");
        }
    };

    this.updateCategory = function (data) {
        window.location.href = "http://localhost:52014/Category/vUpdateCategory";
        
    };

    this.validateState = function (state) {

        if (state === 'Activado')
        {
            $('#btnActive').hide();
            $('#btnDelete').show();
            $('#btnUpdCategory').show();

        } else {
            $('#btnDelete').hide();
            $('#btnActive').show();
            $('#btnUpdCategory').show();
        }

    };
}



//ON DOCUMENT READY
$(document).ready(function () {
    var vretrieveCategory = new vRetrieveCategory();
    vretrieveCategory.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
    $('#btnUpdCategory').hide();
});