//Fill Category select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Category");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
    });
});
//Fill Currency select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Currency");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (currency) {
        $("#CurrencySelect").append($("<option></option>").attr("value", currency.Id).text(currency.Name));
    });
});

$(document).ready(function () {
    //sessionStorage.setItem("IdCellar", 1 );
    $("#txtIdCellar").hide();
    $('#txtIdCellar').val(sessionStorage.getItem("IdCellar"));
});
//Mask
$(document).ready(function () {
    $("#txtTaxes").mask("00");
    $("#txtPriceInitial").mask('000.000.000.000.000,00', { reverse: true });
    $("#txtPriceFinal").mask('000.000.000.000.000,00', { reverse: true });
});

function vCreateProduct() {

    this.service = "Product";

    this.ctrlActions = new ControlActions();

    this.Create = async function () {
        var formData = {};
        var MediaFlag = this.ValidateMedia();
        var productFlag = this.ValidateProduct();

        if (MediaFlag === false && productFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('MediaForm');
                await this.ctrlActions.PostAsync("ProductMedia", formData);
                formData = this.ctrlActions.GetDataForm('ProductForm');
                formData.PriceInitial = formData.PriceInitial.replace(/[.]/g, '');
                formData.PriceInitial = formData.PriceInitial.replace(/[,]/g, '.');
                formData.PriceFinal = formData.PriceFinal.replace(/[.]/g, '');
                formData.PriceFinal = formData.PriceFinal.replace(/[,]/g, '.');
                await this.ctrlActions.PostAsync("Product", formData);
                formData = this.ctrlActions.GetDataForm('InventoryForm');
                await this.ctrlActions.PostAsync("Inventory", formData);
                swal("Se registró el producto con éxito!", "", "success").then((willDelete) => {
                    this.resetContent();
                    window.location.href = "http://localhost:52014/Product/vRetrieveProduct";
                });

            } catch (e) {
                swal("Hubo un problema al registrar el producto. Por favor denuevo.", "", "error");
            }
        }
    };

    this.ValidateProduct = function () {
        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('ProductForm');

        if (formData.Name === null || formData.Name === "") {
            input = document.querySelector("#txtName");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtName");
            input.classList.remove('is-invalid');
        }

        if (formData.Description === null || formData.Description === "") {
            input = document.querySelector("#txtDescription");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtDescription");
            input.classList.remove('is-invalid');
        }

        if (formData.PriceInitial === null || formData.PriceInitial === "") {
            input = document.querySelector("#txtPriceInitial");
            input.classList.add('is-invalid');
            flag = true;
        }
        else {
            try {
                var validatePriceInitial = parseFloat(formData.PriceInitial);
                input = document.querySelector("#txtPriceInitial");
                input.classList.remove('is-invalid');
            } catch (e) {
                input = document.querySelector("#txtPriceInitial");
                input.classList.add('is-invalid');
                flag = true;
            }
        }

        if (formData.PriceFinal === null || formData.PriceFinal === "") {
            input = document.querySelector("#txtPriceFinal");
            input.classList.add('is-invalid');
            flag = true;
        }
        else {
            try {
                var validatePriceFinal = parseFloat(formData.PriceInitial);
                input = document.querySelector("#txtPriceFinal");
                input.classList.remove('is-invalid');
            } catch (e) {
                input = document.querySelector("#txtPriceFinal");
                input.classList.add('is-invalid');
                flag = true;
            }
        }

        if (formData.Taxes === null || formData.Taxes === "") {
            input = document.querySelector("#txtTaxes");
            input.classList.add('is-invalid');
            flag = true;
        }
        else {
            try {
                var validateTaxes = parseFloat(formData.Taxes);
                input = document.querySelector("#txtTaxes");
                input.classList.remove('is-invalid');
            } catch (e) {
                input = document.querySelector("#txtTaxes");
                input.classList.add('is-invalid');
                flag = true;
            }
        }
        if (formData.Provider === null || formData.Provider === "") {
            input = document.querySelector("#txtProvider");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtProvider");
            input.classList.remove('is-invalid');
        }

        if (flag === true) {
            swal("Por favor,verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
        }

        return flag;
    };

    this.ValidateMedia = function () {
        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('MediaForm');

        if (formData.Image1 === null || formData.Image1 === "") {
            input = document.querySelector("#btnProductImage1");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnProductImage1");
            input.classList.remove('redButton');
        }

        if (formData.Image2 === null || formData.Image2 === "") {
            input = document.querySelector("#btnProductImage2");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnProductImage2");
            input.classList.remove('redButton');
        }

        if (formData.Image3 === null || formData.Image3 === "") {
            input = document.querySelector("#btnProductImage3");
            input.classList.add('redButton');
            flag = true;
        } else {
            input = document.querySelector("#btnProductImage3");
            input.classList.remove('redButton');
        }

        if (flag === true) {
            swal("Por favor,verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
        }

        return flag;
    };

    this.Cancel = function () {
        window.location.href = "http://localhost:52014/Product/vRetrieveProduct";
    };

    this.resetContent = function () {

        document.getElementById("MediaForm").reset();
        document.getElementById("ProductForm").reset();
        document.querySelector("#divImage1").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImage1").style.backgroundSize = "contain";
        document.querySelector("#divImage1").style.backgroundPosition = "center";
        document.querySelector("#divImage1").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divImage2").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImage2").style.backgroundSize = "contain";
        document.querySelector("#divImage2").style.backgroundPosition = "center";
        document.querySelector("#divImage2").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divImage3").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImage3").style.backgroundSize = "contain";
        document.querySelector("#divImage3").style.backgroundPosition = "center";
        document.querySelector("#divImage3").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divImage4").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImage4").style.backgroundSize = "contain";
        document.querySelector("#divImage4").style.backgroundPosition = "center";
        document.querySelector("#divImage4").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divImage5").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divImage5").style.backgroundSize = "contain";
        document.querySelector("#divImage5").style.backgroundPosition = "center";
        document.querySelector("#divImage5").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divVideo").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divVideo").style.backgroundSize = "contain";
        document.querySelector("#divVideo").style.backgroundPosition = "center";
        document.querySelector("#divVideo").style.backgroundRepeat = "no-repeat";
    };
}

