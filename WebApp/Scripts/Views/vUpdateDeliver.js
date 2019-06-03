$(document).ready(function () {
    $("#txtPhone_1").mask("0000-0000");
});

function vUpdateDeliver() {
    this.service = "Deliver";
    this.ctrlActions = new ControlActions();

    this.Update = function (cont) {

        var deliverData = {};
        if (cont === 0) {

            var Name_1 = document.getElementById('txtName').value;
            var Last_Name1 = document.getElementById('txtLastName1').value;
            var Last_Name2 = document.getElementById('txtLastName2').value;
            var Phone_1 = document.getElementById('txtPhone_1').value;
            var Email = sessionStorage.getItem('email');
            var deliverData = { Name_1, Last_Name1, Last_Name2, Phone_1, Email };

            //Hace el put al update
            console.log("deliver data===>" + deliverData);
            this.ctrlActions.PutToAPI(this.service, deliverData);
            swal('¡Éxito!', 'La información se ha modificado correctamente.', 'success');


        }
    };


    this.validateInput = function (data) {

        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0 &&
                i != 4 && i != 6 && i != 8) {
                listInput[i].classList.add('is-invalid');
                swal('Campos vacíos','Por favor,verifique que los espacios en rojo no esten vacíos.', 'error');
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
        let infoDeliver = this.ctrlActions.GetIDToAPI(url);
       
        this.fillForm(infoDeliver);

    }


    this.fillForm = function (infoDeliver) {

        if (infoDeliver !== null) {

            $('#txtName').val(infoDeliver['Name_1']);
            $('#txtLastName1').val(infoDeliver['Last_Name1']);
            $('#txtLastName2').val(infoDeliver['Last_Name2']);
            $('#txtPhone_1').val(infoDeliver['Phone_1']);
        }

    }

    this.resetContent = function () {
        document.getElementById("frmDeliver").reset();
    };

    this.Cancel = function () {
        this.resetContent();
        window.history.back();
    };

}

$(document).ready(function () {

    let updateDeliver = new vUpdateDeliver();
    updateDeliver.obtainData();
});

