//Mask
$(document).ready(function () {
    $("#txtId").mask("0-0000-0000");
    $("#txtPhone_1").mask("0000-0000");
    $("#txtPhone_2").mask("0000-0000");
});

$(document).ready(function () {
    let updateClient = new vUpdateClient();
    updateClient.obtainData();
});

function vUpdateClient() {
    this.service = "Client";
    this.ctrlActions = new ControlActions();

    this.Update = function (cont) {
        var formData = {};
        var AddressFlag = this.ValidateAddress();
        var ClientFlag = this.ValidateClient();

        if (AddressFlag === false && ClientFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('AddressForm');
                this.ctrlActions.PutToAPI("address", formData);
                formData = this.ctrlActions.GetDataForm('ClientForm');
                this.ctrlActions.PutToAPI("client", formData);
                swal("Su información ha sido modifica con éxito! ", "", "success").then((willDelete) => {
                    location.reload();
                });

            } catch (e) {
                swal("Hubo un error al actualizar su información", e, "error");
            }
        }   
    };

    this.ValidateClient = function () {
        var formData = {};
        var flag = false;
        var input = null;
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

        if (flag === true) {
            swal("Por favor verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
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

    this.obtainData = function () {

        var email = sessionStorage.getItem('email');

        var url = this.ctrlActions.GetUrlApiService("client" + "?Email=" + email);
        var clients = this.ctrlActions.GetIDToAPI(url);
        var client = Object.assign(clients[0]);

        var url2 = this.ctrlActions.GetUrlApiService("address" + "?Id_address=" + client.Id_Address);
        var address = this.ctrlActions.GetIDToAPI(url2);

        this.fillForm(client, address);

    };

    this.fillForm = function (client, address) {

        if (client !== null) {
            $('#txtUrl_Photo_Id').val(client['Url_Photo_Id']);
            this.addbackgroundImage('#divUrl_Photo_Id', document.querySelector('#txtUrl_Photo_Id').value);
            $('#txtUrl_Profile_Pric').val(client['Url_Profile_Pric']);
            this.addbackgroundImage('#divUrl_Profile_Pric', document.querySelector('#txtUrl_Profile_Pric').value);
            $('#txtId').val(client['Id']);
            $('#txtId').prop('disabled', 'disabled');
            $('#txtName_1').val(client['Name_1']);
            $('#txtName_2').val(client['Name_2']);
            $('#txtLast_Name_1').val(client['Last_Name_1']);
            $('#txtLast_Name_2').val(client['Last_Name_2']);
            $('#txtPhone_1').val(client['Phone_1']);
            $('#txtPhone_2').val(client['Phone_2']);
            $('#txtEmail').val(client['Email']);
            $('#txtEmail').prop('disabled', 'disabled');
            $('#txtIdAddress').val(address['Id']);
            $('#txtDescription').val(address['Description']);
            $('#txtProvince').val(address['Province']);
            $('#txtCanton').val(address['Canton']);
            $('#txtCity').val(address['City']);
        }

    };

    this.resetContent = function () {
        document.getElementById("AddressForm").reset();
        document.getElementById("ClientForm").reset();
        document.querySelector("#divUrl_Photo_Id").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divUrl_Photo_Id").style.backgroundSize = "contain";
        document.querySelector("#divUrl_Photo_Id").style.backgroundPosition = "center";
        document.querySelector("#divUrl_Photo_Id").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundSize = "contain";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundPosition = "center";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundRepeat = "no-repeat";
    };

    this.Cancel = function () {
        this.resetContent();
        window.history.back();
    };

    this.addbackgroundImage = function (pIdElemento, pUrlImagen) {
        document.querySelector(pIdElemento).style.backgroundImage = "url('" + pUrlImagen + "')";
        document.querySelector(pIdElemento).style.backgroundSize = "contain";
        document.querySelector(pIdElemento).style.backgroundPosition = "center";
        document.querySelector(pIdElemento).style.backgroundRepeat = "no-repeat";
    };

}


