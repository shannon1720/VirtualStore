$(document).ready(function () {
    $("#txtId").mask("0-0000-0000");
    $("#txtPhone_1").mask("0000-0000");
    $("#txtPhone_2").mask("0000-0000");

    sessionStorage.setItem('ID_STORE', JSON.stringify('1223344556688'));


})

function vCreateSeller() {
    this.service = 'SellerStore';
    this.ctrlActions = new ControlActions();

    this.Create =  function () {
        var formData = {};
        var AddressFlag = this.ValidateAddress();
        var SellerFlag = this.validateInput();
        
        if (AddressFlag === false && SellerFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('frmaddress');
                 this.ctrlActions.PostAsync("Address", formData);
                formData = this.ctrlActions.GetDataForm('frmSeller');
                const ID_STORE = sessionStorage.getItem("ID_Store");
                formData.ID_STORE = ID_STORE;
                this.ctrlActions.PostAsync("SellerStore", formData);
                swal("Su cuenta ha sido creada con éxito!, se le ha enviado un mensaje a su correo electronico", "", "success").then((willDelete) => {
                    //this.resetContent();
                });
            } catch (e) {
                swal("Hubo un problema al registrar. Por favor intentalo de nuevo.", "", "error");
            }
        }
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmSeller', data);
    };

    this.validateInput = function () {
        var formData = {};
        var flag = false;
        var verifyPassword = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('frmSeller');

        if (formData.Url_Profile_Pric === null || formData.Url_Profile_Pric === "") {
            input = document.querySelector("#btnSelectImage1");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnSelectImage1");
            input.classList.remove('redButton');
        }
        if (formData.Url_Photo_ID === null || formData.Url_Photo_ID === "") {
            input = document.querySelector("#btnSelectImage2");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnSelectImage2");
            input.classList.remove('redButton');
        }
        if (formData.Name_1 === null || formData.Name_1 === "") {
            input = document.querySelector("#txtName_1");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtName_1");
            input.classList.remove('is-invalid');
        }
        if (formData.Last_Name_1 === null || formData.Last_Name_1 === "") {
            input = document.querySelector("#txtLastName_1");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtLastName_1");
            input.classList.remove('is-invalid');
        }
        if (formData.Phone_1 === null || formData.Phone_1 === "") {
            input = document.querySelector("#txtPhone_1");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtPhone_1");
            input.classList.remove('is-invalid');
        }
        if (formData.Email === null || formData.Email === "") {
            input = document.querySelector("#txtEmail");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtEmail");
            input.classList.remove('is-invalid');
        }

        if (formData.Email === null || formData.Email === "") {
            input = document.querySelector("#txtId");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtId");
            input.classList.remove('is-invalid');
        }
        if (formData.Password === null || formData.Password === "") {
            input = document.querySelector("#txtPassword");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtPassword");
            input.classList.remove('is-invalid');
        }
        if (formData.VerifyPassword === null || formData.VerifyPassword === "") {
            input = document.querySelector("#txtVerifyPassword");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtVerifyPassword");
            input.classList.remove('is-invalid');
        }
        if (formData.VerifyPassword !== formData.Password) {
            if (formData.VerifyPassword !== "" || formData.Password !== "") {
                verifyPassword = true;
            }
            flag = true;
        }
        if (flag === true) {
            if (verifyPassword === true) {
                this.ctrlActions.ShowMessage('E', 'Las contraseñas no coinciden.');
            } else {
                swal("Por favor verifique que los espacios en rojo no esten vacíos, sean válidos y las 2 fotos se hayan cargado.", "", "error");
            }

        }
        return flag;
    };

    this.ValidateAddress = function () {
        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('frmaddress');

        if (formData.Province === null || formData.Province === "") {
            input = document.querySelector("#txtProvince");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtProvince");
            input.classList.remove('is-invalid');
        }

        if (formData.Canton === null || formData.Canton === "") {
            input = document.querySelector("#txtCanton");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtCanton");
            input.classList.remove('is-invalid');
        }

        if (formData.City === null || formData.City === "") {
            input = document.querySelector("#txtCity");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtCity");
            input.classList.remove('is-invalid');
        }

        if (formData.Description === null || formData.Description === "") {
            input = document.querySelector("#txtAddress");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtAddress");
            input.classList.remove('is-invalid');
        }

        if (flag === true) {
            swal("Por favor verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
        }

        return flag;
    };


    this.resetContent = function () {

        document.getElementById("frmSeller").reset();
        document.getElementById("frmaddress").reset();
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
        //this.resetContent();
        window.history.back();
    };

}