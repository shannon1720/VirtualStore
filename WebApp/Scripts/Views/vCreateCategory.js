function vCreateCategory()
{
    this.service = 'Category';
    this.ctrlActions = new ControlActions();

    this.Create = function (cont)
    {
        var selfActions = this.ctrlActions;
        if (cont == 0) {
            var categoryData = this.ctrlActions.GetDataForm('frmCategory');
            //Hace el post al create
            selfActions
                .PostAsync(this.service, categoryData)
                .then(function (data) 
                {
                    swal("Categoría creada con éxito! ", "", "success")
                        .then((willDelete) =>
                        {
                            document.getElementById("frmCategory").reset();
                            window.location.href = "http://localhost:52014/Category/vRetrieveCategory";
                        });
                })
                .fail(function (failError) {
                    selfActions.ShowMessage('E', 'Error:' + failError.responseJSON.Message);
                });
        }
    };

    this.BindFields = function (data)
    {
            this.ctrlActions.BindFields('frmCategory', data);
    };

    this.validateInput = function ()
    {
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++)
        {
            if (listInput[i].value.length == 0)
            {
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

    this.Cancel = function()
    {
        window.history.back();
    }

}