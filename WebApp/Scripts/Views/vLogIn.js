this.dashboards = function () {
    var rol = sessionStorage.getItem("rol");
    console.log("Rol" + rol);

    switch (rol) {
        case "1": //Administrador
            window.location.href = "http://localhost:52014/Platform/vWelcomePlatformA";
            break;
        case "2": //Administrador de empresa
            window.location.href = "http://localhost:52014/Shipping/vWelcomeBussiness"
            break;
        case "3": //Administrador de tienda
            window.location.href = "http://localhost:52014/Store/vWelcomeStore";
            break;
        case "4"://Mensajero
            window.location.href = "http://localhost:52014/Deliver/vWelcomeDeliver";
            break;
        case "5"://Vendedor
            window.location.href = "http://localhost:52014/Seller/vWelcomeSeller";
            break;
        case "6"://Cliente
            window.location.href = "http://localhost:52014/Client/vCards";
            break;
    }
};


function vLogIn() {
    this.service = 'LogIn';
    this.ctrlActions = new ControlActions();

    this.LogIn = function (cont) {
        var logInData = {};

        if (cont === 0) {

            var email = document.getElementById('txtEmail').value;
            var password = document.getElementById('txtPassword').value;

            logInData = { email, password };

            response = this.ctrlActions.PostWithResponse(this.service, logInData);

            var data = {
                Email: String(email),
                Password: String(password)
            };

            if (response.State !== true) {
                swal("¡Cuenta inactiva!", "Tú cuenta se encuentra inactiva, por favor activala.", "warning");

            } else {
                if (response.Email == data.Email && response.Password == data.Password) {
                    console.log(response.Rol);
                    sessionStorage.setItem("email", email);
                    sessionStorage.setItem("rol", response.Rol);
                    dashboards();
                    console.log(sessionStorage.getItem("email"));
                    console.log(sessionStorage.getItem("rol"));
                } else {
                    swal("La información ingresada es incorrecta...", "Revisa que los datos sean correctos.", "error");
                }
            }
        }
    }

    this.validateInput = function () {

        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length == 0) {
                listInput[i].classList.add('is-invalid');
                swal("Verifique que los campos en rojo no estén vacíos", "error");
                cont++;
               
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.LogIn(cont);

    };

}


