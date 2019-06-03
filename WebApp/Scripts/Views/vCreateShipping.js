function vCreateShipping()
{
    this.service = 'shipping';
    this.ctrlActions = new ControlActions();

    this.Create = function (cont) {

        if (cont === 0) {
            var shippingData = {};
            shippingData = this.ctrlActions.GetDataForm('frmShipping');
            try {
            //Hace el post al create
            var response = this.ctrlActions.PostWithResponse(this.service, shippingData);
          
                sessionStorage.setItem("Identification", shippingData.Identification);
                swal(response.Message, "", "success").then((willDelete) => {
                    this.resetContent();
                   
                    window.location.href = "http://localhost:52014/Shipping/vWelcomeBussiness";
                });
            } catch (e) {

                swal("Hubo un error al registrar su cuenta", e, "error");
            }
        }
           
    }
    

  
    this.vaidateInput = function () {
        document.querySelector("#txtEmail2").value = sessionStorage.getItem("email");
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.lengthy===0) {
            listInput[i].classList.add('is-invalid');
                swal("Por favor verifique que los espacios en rojo no esten vacíos o  que haya seleccionado el logo.", "", "error");
                cont++;    
            } else {
                listInput[i].classList.remove("is-invalid");
            }   
        }
        this.Create(cont);

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


    };
};

//Fill Currency select
$(document).ready(function () {
    
        $("#txtMinimun_Rate").mask("0000.00");
        $("#txtRate").mask("0000.00");
        $("#txtPhone_Number").mask("0000-0000");
        $("#txtIdentification").mask("000000000000000");
        $("#txtCoveredArea").mask("0000.00");
});



//Fill Currency select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Currency");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (currency) {
        $("#CurrencySelect").append($("<option></option>").attr("value", currency.Id).text(currency.Name));
    });
});
