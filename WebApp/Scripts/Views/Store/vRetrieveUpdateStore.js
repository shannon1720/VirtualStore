function vRetrieveUpdateStore() {

    this.service = 'store';

    this.ctrlActions = new ControlActions();

    this.obtainData = function () {

        
            var email = sessionStorage.getItem('email');
        var response = this.ctrlActions.GetToAPI(this.storeAdminService, email);
        var response2 = this.ctrlActions.GetToAPI("cellar?Id=" + response.IdCellar);
        console.log(response, response2);
        }
        
    }

    this.fillForm = function (data) {
        $('#txtNumber').val(data['Id']);
        $('#txtName').val(data['Name']);
        $('#txtPhone').val(data['PhoneNumber']);
        $('#txtName_2').val(data['Category']);
        $('#txtEarnings').val(data['Earnings']);
        $('#txtURLlogo').val(data['Logo']);
        this.addbackgroundImage('#divImagen', document.querySelector('#txtURLlogo').value);

      

    };

    this.addbackgroundImage = function (pIdElemento, pUrlImagen) {
        document.querySelector(pIdElemento).style.backgroundImage = "url('" + pUrlImagen + "')";
        document.querySelector(pIdElemento).style.backgroundSize = "contain";
        document.querySelector(pIdElemento).style.backgroundPosition = "center";
        document.querySelector(pIdElemento).style.backgroundRepeat = "no-repeat";
    };

    this.validateInput = function ()
    {
        var Session = JSON.parse(sessionStorage.getItem("StoreUpdate"));
        if (Session === null) {
            $('#txtName').removeAttr('disabled');
            $('#txtPhone').removeAttr('disabled');
            $('#txtName_2').removeAttr('disabled');
            $('#txtURLlogo').removeAttr('disabled');
            $('#btnCreate').removeAttr('disabled');
        }
        else
        {
            var storeData = {};
            storeData = this.ctrlActions.GetDataForm('frmStore');
            console.log(storeData);
            sessionStorage.setItem("StoreUpdate", JSON.stringify(storeData.Id));
            //Hace el post al create

            this.ctrlActions.PutToAPI(this.service, storeData);
            this.ctrlActions.ShowMessage('I', 'Se ha actualizado correctamente.');
            this.resetContent();
        }
        var Store = JSON.parse(sessionStorage.getItem('tblStore_selected'));
        sessionStorage.setItem("StoreUpdate", JSON.stringify(Store));
        
    }

    this.Cancel = function () {
        window.history.back();
    };
}

$(document).ready(function () {
    let updateStore = new vRetrieveUpdateStore();
    updateStore.obtainData();
})