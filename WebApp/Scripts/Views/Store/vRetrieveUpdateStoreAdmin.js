function vRetrieveUpdateAdmin() {

    this.service = 'storeAdministrator';
    this.ctrlActions = new ControlActions();

    this.obtainData = function () {
        var email = sessionStorage.getItem("email");
        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + email);
        let infoStore = this.ctrlActions.GetIDToAPI(url);
        this.fillForm(infoStore);
    }


    this.Update = function (cont) {

        var customerData = {};
        if (cont === 0) {

            customerData = {};

            customerData = this.ctrlActions.GetDataForm('frmStoreAdmin');
            //Hace el put al update
          
            try {
                this.ctrlActions.PutToAPI(this.service, customerData);
                swal("Se ha modificado correctamente.", "", "success").then((willDelete) => {
                    this.obtainData();

                });

            } catch (e) {

                swal("Hubo un error al modificar su cuenta:", e, "error");
            }
            this.obtainData();
        }
    };


    this.fillForm = function (data) {
        $('#txtId').val(data['Id']);
        $('#txtId').prop('disabled', 'disabled');
        $('#txtName1').val(data['Name']);
        $('#txtFirstLastName').val(data['FirstLastName']);
        $('#txtSecondLastName').val(data['SecondLastName']);
        $('#txtEmail').val(data['Email']);
        $('#txtEmail').prop('disabled', 'disabled');
        $('#txtPhone').val(data['Phone']);
      
    };

    this.validateInput = function ()
    {
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0 ) {
                listInput[i].classList.add('is-invalid');
                swal("Por favor,verifique que los espacios en rojo no esten vacíos.", "", "error");
                cont++;

            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Update(cont);
        
    }


}

$(document).ready(function () {
    let updateStore = new vRetrieveUpdateAdmin();    
    updateStore.obtainData();
})


$(document).ready(function () {
    $("#txtPhone").mask("0000-0000");
    $("#txtId").mask("0-0000-0000");
});