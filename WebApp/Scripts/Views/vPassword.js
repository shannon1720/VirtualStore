function vPassword()
{
    this.service = 'UserPassword';
    this.ctrlActions = new ControlActions();

    this.Update =  async function (cont) {
        if (cont === 0)
        {
            var Email = JSON.parse(sessionStorage.getItem('email'));
            var UserPassword = document.getElementById('txtPassword').value;
            var VerifyPassword = document.getElementById('txtVerifyPassword').value;
            //var CurrentPassword = document.querySelector('CurrentPassword').value;

            if (UserPassword == VerifyPassword) {
                const Data = { Email, UserPassword  };
                if (this.validatePass(Data) === false) {
                    try {
                        this.ctrlActions.PutToAPI(this.service, Data);
                        await swal("Su contraseña ha sido cambiada con éxito! ", "", "success");
                            this.resetContent();
                           // window.location.href = "http://localhost:52014/Home/Index";
                    }catch (e) {
                            swal("Hubo un error al cambiar su contraseña, vuelva a intentarlo", e, "error");
                        }
                    }
            } else {
                swal('Error', 'Las contraseñas no coinciden.', 'error');
            }
        }
    };

    this.ValidateCurrentPassword = function (cont) {
        if (cont === 0) {
            var currentPassword = document.querySelector('#txtCurrentPassword').value;
            var email = JSON.parse(sessionStorage.getItem('email'));

            Data = { email, currentPassword };

            response = this.ctrlActions.PostWithResponse('LogIn', Data);

            var DataPassword = {
                CurrentPassword: string(currentPassword)
            };
            if (response.Email == email && response.Password == DataPassword.Password) {
                this.validateInput;
            }
            else {
                swal('Contrasaeña actual incorrecta.');
            }

        }
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
    this.Update(cont);
};


    this.validatePass = function (data) {

        var flag = false;
        var regularExpression = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*)(?=.*\W.*)[a-zA-Z0-9\S]{8,30}/;
        var passwordFlag = false;


        if (regularExpression.test(data.UserPassword) === false) {
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

    this.obtainData = function () {

        var email = JSON.parse(sessionStorage.getItem('email'));

        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + email);
        let infoPassword= this.ctrlActions.GetIDToAPI(url);
        console.log(infoPassword);
        this.fillForm(infoPassword);

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmPassword', data);
    };

    this.fillForm = function (infoPassword) {

        if (infoPassword != null) {
            $('#txtPassword').val(infoPassword['UserPassword']);
            $('#txtUser_Email').val(infoPassword['Email']);
            $('#txtUser_Email').prop('disabled', 'disabled');
        }
    }

    this.resetContent = function () {
        document.getElementById("frmPassword").reset();
    };

    this.Cancel = function () {
        this.resetContent();
        window.history.back();
    }
};

$(document).ready(function () {
    sessionStorage.setItem('email', JSON.stringify('funcionePa@gmail.com'));
    let updPassword = new vPassword();
    updPassword.obtainData();
});