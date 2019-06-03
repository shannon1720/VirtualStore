
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Currency");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (currency) {
        $("#CurrencySelect").append($("<option></option>").attr("value", currency.Id).text(currency.Name));
    });
});
function vUpdateShipping() {
    this.service = 'shipping';
    this.ctrlActions = new ControlActions();

    this.Update = function (cont) {
        if (cont===0) {
            var shippingData = {};
            shippingData = this.ctrlActions.GetDataForm('frmShipping');
            //Hace el post al create
            this.ctrlActions.PutToAPI(this.service, shippingData);
            try {
                swal("Se ha modificado correctamente.", "", "success").then((willDelete) => {
                    this.obtainData();
               
                });
        
        } catch (e) {

            swal("Hubo un error al registrar su cuenta", e, "error");
        }
         
        }

    }

    this.vaidateInput = function () {

        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0) {
                listInput[i].classList.add('is-invalid');
                swal("Por favor verifique que los espacios en rojo no esten vacíos o  que haya seleccionado el logo.", "", "error");
                cont++;
           
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Update(cont);

    };

    this.obtainData = function () {

        var email = sessionStorage.getItem('email');

        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + email);
        let infoShipping = this.ctrlActions.GetIDToAPI(url);
        console.log(infoShipping);
        this.fillForm(infoShipping);

    }

    this.fillForm = function (infoShipping) {
        if (infoShipping !== null) {


            $('#txtURLlogo').val(infoShipping['Logo']);
            this.addbackgroundImage('#divImagen', document.querySelector('#txtURLlogo').value);
            console.log(document.querySelector('#txtURLlogo').value);
            $('#txtIdentification').prop('disabled', 'disabled');
            $('#txtIdentification').val(infoShipping['Identification']);
            $('#txtName').val(infoShipping['Name']);
            $('#txtCoveredArea').val(infoShipping['CoveredArea']);
            $('#txtPhone_Number').val(infoShipping['Phone_Number']);
            $('#txtRate').val(infoShipping['Rate']);
            $('#txtMinimun_Rate').val(infoShipping['Minimum_Rate']);
            var currency = infoShipping.IdCurrency;
            $('#CurrencySelect option[value=' + currency + ']').attr('selected', true).change;
        }
    };

    this.addbackgroundImage=function(pIdElemento, pUrlImagen) {
        document.querySelector(pIdElemento).style.backgroundImage = "url('" + pUrlImagen + "')";
        document.querySelector(pIdElemento).style.backgroundSize = "contain";
        document.querySelector(pIdElemento).style.backgroundPosition = "center";
        document.querySelector(pIdElemento).style.backgroundRepeat = "no-repeat";
    };



    this.resetContent = function () {

        document.getElementById("frmShipping").reset();
        document.querySelector("#divImagen").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImagen").style.backgroundSize = "contain";
        document.querySelector("#divImagen").style.backgroundPosition = "center";
        document.querySelector("#divImagen").style.backgroundRepeat = "no-repeat";
    };

    this.Cancel = function () {
        this.resetContent();
        window.history.back();
        //  document.querySelector("#btnCreate").setAttribute('href', "../Views/Home/vBussinesManager.cshtml");


    };

}


$(document).ready(function () {
   

    let updateShipping = new vUpdateShipping();
    updateShipping.obtainData();
});

$(document).ready(function () {
  
    $("#txtMinimun_Rate").mask("0000.00");
    $("#txtRate").mask("0000.00");
    $("#txtPhone_Number").mask("0000-0000");
    $("#txtIdentification").mask("000000000000000");
    $("#txtCoveredArea").mask("0000.00");

});


