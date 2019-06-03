//Fill Category select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Category");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
    });
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
//Mask
$(document).ready(function () {
    $("#txtId").mask("0-0000-0000");
    $("#txtPhone_1").mask("0000-0000");
    $("#txtPhone_2").mask("0000-0000");
});

function vCreateClient() {

    this.ctrlActions = new ControlActions();

    this.Create = async function () {
        var formData = {};
        var AddressFlag = this.ValidateAddress();
        var ClientFlag = this.ValidateClient();

        if (AddressFlag === false && ClientFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('AddressForm');
                await this.ctrlActions.PostAsync("Address", formData);
                formData = this.ctrlActions.GetDataForm('ClientForm');
                await this.ctrlActions.PostAsync("Client", formData);
                swal("Su cuenta ha sido creada con éxito! ", "", "success").then((willDelete) => {
                    this.resetContent();
                    window.location.href = "http://localhost:52014/Home/Index";
                });
            } catch (e) {
                swal("Hubo un error al registrar su cuenta", e, "error");
            }
        }
    };

    this.ValidateClient = function () {
        var formData = {};
        var flag = false;
        var verifyPassword = false;
        var input = null;
        var passwordFlag = false;
        var regularExpression = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*)(?=.*\W.*)[a-zA-Z0-9\S]{8,30}/;
        formData = this.ctrlActions.GetDataForm('ClientForm');

        if (formData.Url_Photo_Id === null || formData.Url_Photo_Id === "") {
            input = document.querySelector("#btnUrl_Photo_Id");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnUrl_Photo_Id");
            input.classList.remove('redButton');
        }

        if (formData.Url_Profile_Pric === null || formData.Url_Profile_Pric === "") {
            input = document.querySelector("#btnUrl_Profile_Pric");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnUrl_Profile_Pric");
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
            input = document.querySelector("#txtLast_Name_1");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtLast_Name_1");
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

        if (formData.Id === null || formData.Id === "") {
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
            if (regularExpression.test(formData.Password) === false) {
                input = document.querySelector("#txtPassword");
                input.classList.add('is-invalid');
                passwordFlag = true;
                flag = true;
            } else {
                input = document.querySelector("#txtId");
                input.classList.remove('is-invalid');
            }
          
        }

        if (formData.Password !== "") {
           
            if (passwordFlag === true) {
                input = document.querySelector("#txtPassword");
                input.classList.remove('is-invalid');
            }
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
            if (passwordFlag === true) {
                swal("Por favor verifique que la contraseña cumpla con el formato requerido.", "", "error");
            }
            else if (verifyPassword === true) {
                swal("Las contraseñas no coinciden. Por favor verifiquelas.", "", "error");
            } else {
                swal("Por favor verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
            }
        }

        return flag;
    };

    this.ValidateAddress = function () {
        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('AddressForm');


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
            input = document.querySelector("#txtDescription");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtDescription");
            input.classList.remove('is-invalid');
        }

        if (flag === true) {
            swal("Por favor verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
        }

        return flag;
    };

    this.Cancel = function () {
        window.history.back();
    };

    this.resetContent = function () {

        document.getElementById("ClientForm").reset();
        document.getElementById("AddressForm").reset();
        document.querySelector("#divUrl_Photo_Id").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divUrl_Photo_Id").style.backgroundSize = "contain";
        document.querySelector("#divUrl_Photo_Id").style.backgroundPosition = "center";
        document.querySelector("#divUrl_Photo_Id").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundSize = "contain";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundPosition = "center";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundRepeat = "no-repeat";
    };
}
