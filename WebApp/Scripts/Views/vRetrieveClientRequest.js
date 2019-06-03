$(document).ready(function () {
    sessionStorage.setItem("email", "pitiquis@gmail.com");
});

$(document).ready(function () {
    var vretrieveClientRequest = new vRetrieveClientRequest();
    vretrieveClientRequest.RetrieveAll();
});

function vRetrieveClientRequest() {
    this.tblId = 'tblClientRequest';
    var email = sessionStorage.getItem("email");
    this.service = 'Request?Email=' + email;
    this.ctrlActions = new ControlActions();
    this.columns = "Descripción";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblId, false);
    };

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblId, true);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('tblClientRequest', data);
        swal("Se ha seleccionado a", data.Description, "success");
    };
}
