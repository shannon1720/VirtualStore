$(document).ready(function () {
    $("#txtId").mask("0-0000-0000");
    $("#txtPhone").mask("0000-0000");
    $("#txtPhoneStore").mask("0000-0000");
    $("#txtLong").hide();
    $("#txtLat").hide();

});

//Fill Category select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Category");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
    });
});

function CreateStore() {
    

    this.serviceStore = 'store';
    this.ctrlActions = new ControlActions();
    this.cellar = 'cellar';
    this.storeAdministrator = 'storeAdministrator';

    var dataLat = {};

    

    console.log("Info ===>   " + dataLat.Latitude);
    console.log("Info ===>   " + dataLat.Longitude);

    this.Create = function (cont) {

        if (cont === 0) {
            //Info admi de tienda
            var dataAdmi = {};
            var Id = document.getElementById('txtId').value;
            var Name_1 = document.getElementById('txtName1').value;
            var Last_Name1 = document.getElementById('txtFirstLastName').value;
            var Last_Name2 = document.getElementById('txtSecondLastName').value;
            var Phone_1 = document.getElementById('txtPhone').value;
            var Email = document.getElementById('txtEmail').value;
            var Password = document.getElementById('txtPassword').value;
            var password2 = document.getElementById('txtConfirmPassword').value;

            //Info de la tienda
            var dataStore = {};
            var Logo = document.getElementById('txtURLlogo').value;
            var Id_Store = document.getElementById('txtNumber').value;
            var Name = document.getElementById('txtName').value;
            var Phone = document.getElementById('txtPhoneStore').value;
            var Category = document.getElementById('CategorySelect').value;


            //Info de la bodega
            var dataCellar = {};
            dataTemp = this.ctrlActions.GetDataForm('frmCellar');
            var Latitude = dataTemp.Latitude;
            var Longitude = dataTemp.Longitude;
            var Address = dataTemp.Address;


            if (Password == password2) {
                console.log("contras coinciden");
                var dataAdmi = { "Id":Id, "Name_1":Name_1,"Last_Name1":Last_Name1,"Last_Name2":Last_Name2, "Phone_1":Phone_1,"Email": Email, "Password":Password,"Id_Store": Id_Store };
                if (this.validatePass(dataAdmi) === false) {
                    try {
                        //Post to admin
                        this.ctrlActions.PostToAPI(this.storeAdministrator, dataAdmi);

                        //Post to cellar
                        dataCellar = {"Latitude":Latitude,"Logitude": Longitude,"Id_store": Id_Store, "Address":Address };
                        this.ctrlActions.PostToAPI(this.cellar, dataCellar);

                        //Post to store
                        dataStore = {"Id": Id_Store, "Name":Name,"Logo": Logo, "Phone":Phone,"Category": Category };
                        this.ctrlActions.PostToAPI(this.serviceStore, dataStore);

                        swal('¡Éxito!', 'La tienda se ha registrado exitosamente.', 'success');
                        this.resetContent();
                        window.location.href = "http://localhost:52014/";
                    } catch (e) {

                        swal("Hubo un error al registrar la tienda", e, "error");
                    }
                }

            } else {
                swal('Error', 'Las contraseñas del administrador no coinciden.', 'error');

            }

        }
    };

    this.validatePass = function (deliverData) {

        var flag = false;
        var regularExpression = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*)(?=.*\W.*)[a-zA-Z0-9\S]{8,30}/;
        var verifyPassword = false;
        var passwordFlag = false;


        if (regularExpression.test(deliverData.Password) === false) {
            input = document.querySelector("#txtPassword");
            input.classList.add('is-invalid');
            passwordFlag = true;
            flag = true;
            if (passwordFlag === true) {
                swal("Por favor verifique que la contraseña cumpla con el formato requerido.", "", "error");
            }
        }


        return flag;
    }

    this.CreateAdminStore = function () {

        var storeAdminData = {};
        storeAdminData = this.ctrlActions.GetDataForm('frmStoreAdmin');

        storeData = sessionStorage.getItem("StoreCreate");
        storeData = JSON.parse(storeData);

        storeAdminData.Store = storeData['Id'];
        sessionStorage.setItem("StoreCreateAdministrator", JSON.stringify(storeAdminData.Identification));
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.storeAdministrator, storeAdminData);
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmStore', data);
    };

    this.validateInputStore = function () {

        var listInput = document.querySelectorAll("input");
        var select = document.querySelector("#CategorySelect");
        var btn = document.querySelector("#btnSelectImage");

        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0) {
                listInput[i].classList.add('is-invalid');
                select.classList.add('is-invalid');
                btn.classList.add('redButton');
                swal("¡Faltan campos!", "Debes llenar todos los campos.", "error");
                cont++;
                this.Create();
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Create(cont);

    };

    this.resetContent = function () {

        document.getElementById("frmStore").reset();
        document.getElementById("frmStoreAdmin").reset();
        document.querySelector("#divImagen").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImagen").style.backgroundSize = "contain";
        document.querySelector("#divImagen").style.backgroundPosition = "center";
        document.querySelector("#divImagen").style.backgroundRepeat = "no-repeat";



    };

    this.Cancel = function () {

        window.history.back();
        //  document.querySelector("#btnCreate").setAttribute('href', "../Views/Home/vBussinesManager.cshtml");

    };
}

$(document).ready(function () {
    $("#txtMinimun_Rate").click(function () {
        $("#txtMinimun_Rate").mask("0000.00");
    });
    $("#txtRate").click(function () {
        $("#txtRate").mask("0000.00");
    });

    $("#txtPhone_Number").click(function () {
        $("#txtPhone_Number").mask("00000000");
    });

});

$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Category");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
    });
});