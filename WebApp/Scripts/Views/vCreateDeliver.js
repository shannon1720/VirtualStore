$(document).ready(function () {
    $("#txtIdentification").mask("0-0000-0000");
    $("#txtPhone").mask("0000-0000");
});

function vCreateDeliver() {

    this.service = "Deliver";
    this.ctrlActions = new ControlActions();

    this.CreateDeliver = function (cont) {

        if (cont === 0) {

            var ID = document.getElementById('txtIdentification').value;
            var Name_1 = document.getElementById('txtName').value;
            var Last_Name1 = document.getElementById('txtLastName1').value;
            var Last_Name2 = document.getElementById('txtLastName2').value;
            var Phone_1 = document.getElementById('txtPhone').value;
            var Email = document.getElementById('txtEmail').value;
            var Password = document.getElementById('txtPassword').value;
            var password2 = document.getElementById('txtConfirmPassword').value;
            var Id_Bussiness = sessionStorage.getItem("email");

            console.log(Password);
            console.log(password2);
            if (Password == password2) {
                console.log("contras coinciden");
                var deliverData = { ID, Name_1, Last_Name1, Last_Name2, Phone_1, Email, Password, Id_Bussiness};
                if (this.validatePass(deliverData) === false) {
                    try {
                        this.ctrlActions.PostToAPI(this.service, deliverData);
                        swal('¡Éxito!', 'El mensajero se ha registrado correctamente.', 'success');
                        this.resetContent();
                        window.location.href = "http://localhost:52014/Deliver/vRetrieveDeliver";
                    } catch (e) {

                        swal("Hubo un error al registrar el mensajero", e, "error");
                    }
                }
                
            } else{
                swal('Error', 'Las contraseñas no coinciden.', 'error');
                
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

    this.validateInput = function () {

        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0) {
                listInput[i].classList.add('is-invalid');
                swal("¡Faltan campos!", "Debes llenar todos los campos.", "error");
                cont++;

            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.CreateDeliver(cont);

    };

    this.resetContent = function () {

        document.getElementById("frmDeliver").reset();


    }
}