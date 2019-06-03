//ON DOCUMENT READY
$(document).ready(function () {
    var vretrieveProduct = new vRetrieveProduct();
    vretrieveProduct.RetrieveAll();
    $('#btnActive').hide();
    $('#btnDelete').hide();
    $('#btnModify').hide(); 
    $('#btnStock').hide();
    $('#Stock').hide();
});

function vRetrieveProduct() {
    this.tblProductId = 'tblProduct';
    this.service = 'Product';
    this.ctrlActions = new ControlActions();
    this.columns = "Nombre, Categoria,Existencias ,Estado ";

    this.RetrieveAll = function () {
        //sessionStorage.setItem('IdCellar', 1);
        var IdCellar = sessionStorage.getItem('IdCellar');
        var service = 'Inventory?IdCellar=' + IdCellar;
        this.ctrlActions.FillTable(service, this.tblProductId, false);
    };

    this.ReloadTable = function () {
        var IdCellar = sessionStorage.getItem('IdCellar');
        var service = 'Inventory?IdCellar=' + IdCellar;
        this.ctrlActions.FillTable(service, this.tblProductId, true);
    };

    this.BindFields = function (data) {
        $('#Stock').hide();
        this.ctrlActions.BindFields('tblProduct', data);
        sessionStorage.setItem("Product", JSON.stringify(data));
        sessionStorage.setItem("IdProduct", JSON.stringify(data.Id));
        sessionStorage.setItem("State", JSON.stringify(data.State));
        swal("Se ha seleccionado a", data.Name, "success");
        var active = JSON.parse(sessionStorage.getItem("State", JSON.stringify(data.State)));
        this.validateState(active);
        $('#txtStock').val(data.Stock);
        $('#btnModify').show();
        $('#btnStock').show();
    };

    this.RedirectToModify = function () {
        window.location.href = "http://localhost:52014/Product/vUpdateProduct";
    };

    this.validateState = function (state) {
        if (state === true) {
            $('#btnActive').hide();
            $('#btnDelete').show();
            $('#btnModify').hide();
        }
        else {

            $('#btnDelete').hide();
            $('#btnActive').show();
        }
    };

    this.Delete =  function (data) {
        try {

            var Id = JSON.parse(sessionStorage.getItem("IdProduct"));
            var active = JSON.parse(sessionStorage.getItem("State"));
            var product = { "Id": Id };

            this.ctrlActions.DeleteToAPI(this.service, product);

            if (active === true) {
                swal("Se desactivo con Éxito!", "", "success");
            } else {
                swal("Se activo con Éxito!","", "success");
            }
            sessionStorage.removeItem("IdProduct");
            sessionStorage.removeItem("State");

            $('#btnActive').hide();
            $('#btnDelete').hide();
            $('#btnModify').hide();
            $('#btnStock').hide();
            $('#Stock').hide();
            $('#btnProduct').hide();

            for (var i = 0; i < 50; i++) {
                this.ReloadTable();
            }
             

        } catch (e) {
           
            swal("Hubo un error, intentelo denuevo.", "", "error");
        }
    };

    this.Stock =  function (data) {
        $('#Stock').show();
    };

    this.Hide = function (data) {
        $('#Stock').hide();
    };

    this.UpdateStock = function (data) {
        var formData = {};
        var StockFlag = this.ValidateStock();
        if (StockFlag === false ) {
            try {
                var product = JSON.parse(sessionStorage.getItem("Product"));
                formData = this.ctrlActions.GetDataForm('StockForm');
                product.Stock = formData.Stock;
                this.ctrlActions.PutToAPI("Product", product);         
                swal("Se han actualizado las existencias de " + product.Name, "", "success").then((willDelete) => {
                    $('#btnActive').hide();
                    $('#btnDelete').hide();
                    $('#btnModify').hide();
                    $('#btnStock').hide();
                    $('#Stock').hide();
                    $('#btnProduct').hide();
                    for (var i = 0; i < 50; i++) {
                        this.ReloadTable();
                    }
                });

            } catch (e) {
                swal("Hubo un error al actualizar su información", e, "error");
            }
        }   
    };

    this.ValidateStock = function () {

        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('StockForm');

        if (formData.Stock === null || formData.Stock === "" || formData.Stock < 0 ) {
            input = document.querySelector("#txtStock");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtStock");
            input.classList.remove('is-invalid');
        }

        if (flag === true) {
            swal("Por favor,verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
        }

        return flag;

    };

    this.AddProduct = function () {
        window.location.href = "http://localhost:52014/Product/vCreateProduct";
    };
    
}


