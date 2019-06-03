function vBussinesManager() {

    this.service = "bussinesManager";

    this.ctrlActions = new ControlActions();


    this.Create = function (cont) {
        if (cont === 0) {
           
           var  bussienesData = {};

            bussienesData = this.ctrlActions.GetDataForm('frmBussines');
            if (this.validatePass(bussienesData)===false) {
                try {
                //Hace el post al create
                response = this.ctrlActions.PostWithResponse(this.service, bussienesData);
                swal(response.Message, "", "success").then((willDelete) => {
                    this.resetContent();
                    sessionStorage.setItem("email", bussienesData.Email);
                    window.location.href = "http://localhost:52014/Shipping/vCreateShipping"
                });           
                 } catch (e) {

                      swal("Hubo un error al registrar su cuenta", e, "error");
                 }
            }
          
        
        }
    };
    this.validatePass = function (bussienesData) {

        var flag = false;
        var regularExpression = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*)(?=.*\W.*)[a-zA-Z0-9\S]{8,30}/;
        var verifyPassword = false;
        var passwordFlag = false;


        if (regularExpression.test(bussienesData.Password) === false) {
            input = document.querySelector("#txtPassword");
            input.classList.add('is-invalid');
            passwordFlag = true;
            flag = true;
            if (passwordFlag === true) {
                swal("Por favor verifique que la contraseña cumpla con el formato requerido.", "", "error");
            }
        }
        if (bussienesData.VerifyPassword !== bussienesData.Password) {
            if (bussienesData.VerifyPassword !== "" || bussienesData.Password !== "") {
                verifyPassword = true;
            }
            flag = true;
        }

        if (flag === true) {
                if (verifyPassword === true) {
                    swal("Las contraseñas no coinciden. Por favor verifiquelas.", "", "error");
                }
            }
        
        return flag;
    }
    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    };

    this.validateInput = function (data) {

  
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0 && i !== 4 && i != 6 && i != 8) {
                listInput[i].classList.add('is-invalid');
                swal("Por favor verifique que los espacios en rojo no esten vacíos o  que haya seleccionado las 2 imagenes.", "", "error");
                cont++;
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Create(cont);
    };
      

        this.resetContent = function () {
            document.getElementById("frmBussines").reset();
            document.querySelector("#divImagen").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
            document.querySelector("#divImagen").style.backgroundSize = "contain";
            document.querySelector("#divImagen").style.backgroundPosition = "center";
            document.querySelector("#divImagen").style.backgroundRepeat = "no-repeat";
            document.querySelector("#divImagen1").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
            document.querySelector("#divImagen1").style.backgroundSize = "contain";
            document.querySelector("#divImagen1").style.backgroundPosition = "center";
            document.querySelector("#divImagen1").style.backgroundRepeat = "no-repeat";
        };

        this.Cancel = function () {
            this.resetContent();
            window.history.back();
        };
}

$(document).ready(function () {
   
    $("#txtId").mask("0-0000-0000");
    $("#txtPhone_1").mask("0000-0000");
    $("#txtPhone_2").mask("0000-0000");
});

