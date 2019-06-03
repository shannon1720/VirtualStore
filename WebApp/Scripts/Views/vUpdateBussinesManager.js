function vUpdateBussinesManager() {
    this.service = "bussinesManager";
    this.ctrlActions = new ControlActions();

    this.Update= function (cont) {

        var customerData = {};
        if (cont === 0) {
         
            customerData = {};

            customerData = this.ctrlActions.GetDataForm('frmBussines');
            //Hace el put al update
            this.ctrlActions.PutToAPI(this.service, customerData);
            try {
                swal("Se ha modificado correctamente.", "", "success").then((willDelete) => {
                    this.obtainData();

                });

            } catch (e) {

                swal("Hubo un error al modificar su cuenta:", e, "error");
            }
            this.obtainData();
          
        }
    };


    this.validateInput = function (data) {

       
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0 &&
                i != 4 && i != 6 && i != 8    ) {
                listInput[i].classList.add('is-invalid');
                swal("Por favor,verifique que los espacios en rojo no esten vacíos y que haya seleccionado las 2 imagenes.", "", "error");
               
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Update(cont);

    };

    this.obtainData = function () {

        var email = sessionStorage.getItem("email");

        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + email);
        let infoBussines = this.ctrlActions.GetIDToAPI(url);
        //console.log(infoBussines);
       

        
 
        this.fillForm(infoBussines);

    }



    this.fillForm = function (infoBussines) {

        if (infoBussines !== null) {


            $('#txtFile').val(infoBussines['URL_Profile_Pric']);
            this.addbackgroundImage('#divImagen', document.querySelector('#txtFile').value);
            $('#txtphotoId').val(infoBussines['URL_Photo_ID']);
            this.addbackgroundImage('#divImagen1', document.querySelector('#txtphotoId').value);
            $('#txtId').val(infoBussines['Id']);
            $('#txtId').prop('disabled', 'disabled');
            $('#txtName_1').val(infoBussines['Name_1']);
            $('#txtName_2').val(infoBussines['Name_2']);
            $('#txtLastName_1').val(infoBussines['LastName_1']);
            $('#txtLastName_2').val(infoBussines['LastName_2']);
            $('#txtPhone_1').val(infoBussines['Phone_1']);
            $('#txtPhone_2').val(infoBussines['Phone_2']);
            $('#txtEmail').val(infoBussines['Email']);
            $('#txtEmail').prop('disabled', 'disabled');
           
          
        }

    }

    this.resetContent = function () {
        document.getElementById("frmBussines").reset();
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

}
$(document).ready(function () {
    //borrar
    //sessionStorage.setItem('email');

    let updatebussines = new vUpdateBussinesManager();
    updatebussines.obtainData();
});



$(document).ready(function () {
        $("#txtId").mask("0-0000-0000");
        $("#txtPhone_2").mask("0000-0000");
        $("#txtPhone_1").mask("0000-0000");
});