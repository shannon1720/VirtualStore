function vUpdateSeller()
{
    this.service = "SellerStore";
    this.ctrlActions = new ControlActions();

    this.Update = function (cont) {
        var formData = {};
        var AddressFlag = this.ValidateAddress();
        var SellerFlag = this.validateInput();
        if (AddressFlag === false && SellerFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('frmaddress');
                this.ctrlActions.PutToAPI("address", formData);
                formData = this.ctrlActions.GetDataForm('frmSeller');
                this.ctrlActions.PutToAPI("SellerStore", formData);
                swal("Su cuenta ha sido modificada con éxito! ", "", "success")
            } catch (e) {
                swal("Hubo un problema al Actualizar. Por favor intentelo de nuevo", "", "error");
                //this.ctrlActions.ShowMessage('E', 'Hubo un problema al Actualizar. Por favor intentelo de nuevo.');
            }
        }
    };

    this.validateInput = function (data) {
        
        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('frmSeller');

        if (formData.URL_Profile_Pric === null || formData.URL_Profile_Pric === "") {
            input = document.querySelector("#btnSelectImage1");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnSelectImage1");
            input.classList.remove('redButton');
        }
        if (formData.URL_Photo_ID === null || formData.URL_Photo_ID === "") {
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
        } else{
            input = document.querySelector("#txtId");
            input.classList.remove('is-invalid');
        }
        if (flag === true) {
            swal("'Por favor, verifique que los espacios en rojo no esten vacíos o que sean válidos", "", "error");
            //this.ctrlActions.ShowMessage('E', 'Por favor, verifique que los espacios en rojo no esten vacíos o que sean válidos.');
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
            swal("'Por favor, verifique que los espacios en rojo no esten vacíos o que sean válidos", "", "error");
        }

        return flag;
    };

    this.obtainData = function () {

       // var email = JSON.parse(sessionStorage.getItem('email'));
        var email = sessionStorage.getItem('email');


        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + email);
        let infoSeller = this.ctrlActions.GetIDToAPI(url);
        console.log(infoSeller);
      
        let url2 = this.ctrlActions.GetUrlApiService("address" + "?Id_address=" + infoSeller.ID_Address);
        let infoAddress = this.ctrlActions.GetIDToAPI(url2);
        console.log(infoAddress);

        this.fillForm(infoSeller, infoAddress);

    }
    
    this.fillForm = function (infoSeller,infoAddress) {

        if (infoSeller != null) {

            $('#txtFile').val(infoSeller['Url_Profile_Pric']);
            this.addbackgroundImage('#divImagen', document.querySelector('#txtFile').value);
            $('#txtphotoId').val(infoSeller['Url_Photo_ID']);
            this.addbackgroundImage('#divImagen1', document.querySelector('#txtphotoId').value);
            $('#txtId').val(infoSeller['ID']);
            $('#txtId').prop('disabled', 'disabled');
            $('#txtName_1').val(infoSeller['Name_1']);
            $('#txtName_2').val(infoSeller['Name_2']);
            $('#txtLastName_1').val(infoSeller['Last_Name_1']);
            $('#txtLastName_2').val(infoSeller['Last_Name_2']);
            $('#txtPhone_1').val(infoSeller['Phone_1']);
            $('#txtPhone_2').val(infoSeller['Phone_2']);
            $('#txtEmail').val(infoSeller['Email']);
            $('#txtEmail').prop('disabled', 'disabled');
            $('#txtAddress').val(infoAddress['Description']);
            $('#txtProvince').val(infoAddress['Province']);
            $('#txtCanton').val(infoAddress['Canton']);
            $('#txtCity').val(infoAddress['City']);
            $('#txtIdAddress').val(infoAddress['Id']);
        }

    }

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
        this.resetContent();
        window.history.back();
    };

    this.addbackgroundImage = function (pIdElemento, pUrlImagen) {
        document.querySelector(pIdElemento).style.backgroundImage = "url('" + pUrlImagen + "')";
        document.querySelector(pIdElemento).style.backgroundSize = "contain";
        document.querySelector(pIdElemento).style.backgroundPosition = "center";
        document.querySelector(pIdElemento).style.backgroundRepeat = "no-repeat";
    };
};

$(document).ready(function () {

    //sessionStorage.setItem('email', JSON.stringify('asd@'));
    let updateSeller = new vUpdateSeller();
    updateSeller.obtainData();
});

$(document).ready(function () {
  
    $("#txtPhone_2").click(function () {
        $("#txtPhone_2").mask("00000000");
    });
    $("#txtPhone_1").click(function () {
        $("#txtPhone_1").mask("00000000");
    });
});