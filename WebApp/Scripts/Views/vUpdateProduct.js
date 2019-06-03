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
    //borrar
    $("#txtIdProduct").hide();
    $("#txtIdMedia").hide();
    $("#txtStock").hide();
    //sessionStorage.setItem('IdProduct', JSON.stringify(20));

    let updateProduct = new vUpdateProduct();
    updateProduct.obtainData();
});

$(document).ready(function () {
    $("#txtTaxes").mask("00");
    $("#txtPriceInitial").mask('000.000.000.000.000,00', { reverse: true });
    $("#txtPriceFinal").mask('000.000.000.000.000,00', { reverse: true });
});

function vUpdateProduct() {
    this.service = "Product";
    this.ctrlActions = new ControlActions();

    this.Update = function () {
        var formData = {};
        var MediaFlag = this.ValidateProduct();
        var ProductFlag = this.ValidateMedia();

        if (MediaFlag === false && ProductFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('MediaForm');
                this.ctrlActions.PutToAPI("ProductMedia", formData);
                formData = this.ctrlActions.GetDataForm('ProductForm');
                formData.PriceInitial = formData.PriceInitial.replace(/[.]/g, '');
                formData.PriceInitial = formData.PriceInitial.replace(/[,]/g, '.');
                formData.PriceFinal = formData.PriceFinal.replace(/[.]/g, '');
                formData.PriceFinal = formData.PriceFinal.replace(/[,]/g, '.');
                formData.State = sessionStorage.getItem('State');
                this.ctrlActions.PutToAPI("Product", formData);     
                swal("Actualizacion exitosa!", "", "success").then((willDelete) => {
                    location.reload();
                });
             
            } catch (e) {
                swal("Hubo un problema al actualizar, intente de nuevo.", "", "error");
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

    this.obtainData = function () {

        var Id = JSON.parse(sessionStorage.getItem('IdProduct'));

        var url = this.ctrlActions.GetUrlApiService("Product" + "?Id=" + Id);
        var product = this.ctrlActions.GetIDToAPI(url);
        sessionStorage.setItem('Stock', product.Stock);

        product.PriceInitial = parseFloat(product.PriceInitial).toFixed(2);
        product.PriceFinal = parseFloat(product.PriceFinal).toFixed(2);
        var url2 = this.ctrlActions.GetUrlApiService("ProductMedia/" + product.IdMedia);
        var media = this.ctrlActions.GetIDToAPI(url2);

        this.fillForm(product, media);

    };

    this.fillForm = function (product, media) {

        $('#txtIdMedia').val(media['Id']);
        if (media.Image1 !== "" ) {
            $('#txtImage1').val(media['Image1']);
            this.addbackgroundImage('#divImage1', document.querySelector('#txtImage1').value);
        }

        if (media.Image2 !== "") {
            $('#txtImage2').val(media['Image2']);
            this.addbackgroundImage('#divImage2', document.querySelector('#txtImage2').value);
        }

        if (media.Image3 !== "") {
            $('#txtImage3').val(media['Image3']);
            this.addbackgroundImage('#divImage3', document.querySelector('#txtImage3').value);
        }

        if (media.Image4 !== "") {
            $('#txtImage4').val(media['Image4']);
            this.addbackgroundImage('#divImage4', document.querySelector('#txtImage4').value);
        }
      
        if (media.Image5 !== "") {
            $('#txtImage5').val(media['Image5']);
            this.addbackgroundImage('#divImage5', document.querySelector('#txtImage5').value);
        }
       
        if (media.Video !== "" ) {
            $('#txtVideo').val(media['Video']);
            this.addVideoPlayer('#divVideo', document.querySelector('#txtVideo').value);
        }
        
        $('#txtIdProduct').val(product['Id']);
        $('#txtStock').val(product['Stock']);
        $('#txtName').val(product['Name']);
        $('#txtDescription').val(product['Description']);
        $('#txtPriceInitial').val(product['PriceInitial']);
        $('#txtPriceFinal').val(product['PriceFinal']);
        $('#txtTaxes').val(product['Taxes']);
        $('#txtProvider').val(product['Provider']);      
        $('#CategorySelect').find("option[value='" + product.IdCategory + "']").attr('selected', true);
        $('#CurrencySelect').find("option[value='" + product.IdCurrency + "']").attr('selected', true);
    };
    
    this.resetContent = function () {
        document.getElementById("ProductForm").reset();
        document.getElementById("MediaForm").reset();
        document.querySelector("#divUrl_Photo_Id").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divUrl_Photo_Id").style.backgroundSize = "contain";
        document.querySelector("#divUrl_Photo_Id").style.backgroundPosition = "center";
        document.querySelector("#divUrl_Photo_Id").style.backgroundRepeat = "no-repeat";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundImage = "url('../Content/imgs/ICO.jpg')";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundSize = "contain";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundPosition = "center";
        document.querySelector("#divUrl_Profile_Pric").style.backgroundRepeat = "no-repeat";
    };

    this.Cancel = function () {
        window.location.href = "http://localhost:52014/Product/vRetrieveProduct";
    };

    this.addbackgroundImage = function (pIdElemento, pUrlImagen) {
        document.querySelector(pIdElemento).style.backgroundImage = "url('" + pUrlImagen + "')";
        document.querySelector(pIdElemento).style.backgroundSize = "contain";
        document.querySelector(pIdElemento).style.backgroundPosition = "center";
        document.querySelector(pIdElemento).style.backgroundRepeat = "no-repeat";
    };

    this.addVideoPlayer = function (pIdElemento, pUrlVideo) {
        document.querySelector(pIdElemento).innerHTML = '<video width="280" height="280" controls><source src="' + pUrlVideo + '" type="video/mp4"></video>';
        document.querySelector(pIdElemento).style.background = "black";
    };
}

