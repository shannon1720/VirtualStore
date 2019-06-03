function vUserCode() {
    this.service = 'UserCode';
    this.ctrlActions = new ControlActions();

    this.Create = function (cont) {
        var selfActions = this.ctrlActions;
        if (cont == 0) {
            var codeData = this.ctrlActions.GetDataForm('frmCode');
            //Hace el post al create
            selfActions
                .PostAsync(this.service, codeData)
                .then(function (data) { 
                         swal("Su cuenta se ha activado con exito! ", "", "success")
                        .then((willDelete) => {
                            //document.getElementById("frmCode").reset();
                            window.location.href = "http://localhost:52014/";
                        });
                })
                .fail(function (failError) {
                    selfActions.ShowMessage('E', 'Error:' + failError.responseJSON.Message);
                });
        }
    };

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmCode', data);
    };

    this.validateInput = function () {
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length == 0) {
                listInput[i].classList.add('is-invalid');
                swal("'Por favor, verifique que los espacios en rojo no esten vacíos o que sean válidos", "", "error");
                cont++;
                this.Create()
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Create(cont);
    };

    this.Cancel = function () {
        window.history.back();
    }

}