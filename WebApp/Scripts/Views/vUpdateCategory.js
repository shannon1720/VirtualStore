function vUpdateCategory()
{
    this.service = 'Category';
    this.ctrlActions = new ControlActions();

    this.Update = async function (cont)
    {
        if (cont === 0) {
            var categoryData = this.ctrlActions.GetDataForm('frmCategory');
            //Hace el post al create
            this.ctrlActions.PutToAPI(this.service, categoryData);
            await swal("Categoría modificada con éxito! ", "", "success")
            document.getElementById("frmCategory").reset();
            window.location.href = "http://localhost:52014/Category/vRetrieveCategory";

  //          this.resetContent(); 
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
            if (listInput[i].value.length === 0)
            {
                listInput[i].classList.add('is-invalid');
                swal("'Por favor, verifique que los espacios en rojo no esten vacíos o que sean válidos", "", "error");
                cont++;
                this.Create()
            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Update(cont);
    };


    this.obtainData = function () {

        //var ID = JSON.parse(sessionStorage.getItem('ID'));
        var ID = sessionStorage.getItem('ID');
        let url = this.ctrlActions.GetUrlApiService(this.service + "?ID=" + ID);
        let infoCategory = this.ctrlActions.GetIDToAPI(url);
        console.log(infoCategory);
        this.fillForm(infoCategory);
    }

    this.fillForm = function (infoCategory)
    {
        if (infoCategory !== null) {

            $('#txtName').val(infoCategory['Name']);
            $('#txtID_Category').val(infoCategory['ID']);
        }
    }

    this.Cancel = function () {
        this.resetContent();
        window.history.back();
    }
};

$(document).ready(function () {
    //borrar
    //sessionStorage.setItem('ID', JSON.stringify(2));

    let updateCategory= new vUpdateCategory();
    updateCategory.obtainData();
});