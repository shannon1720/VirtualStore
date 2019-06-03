//Fill Category select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Category");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        if (category.Active === true) {
            $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
        }
    });
});
//DateTimePicker
$(document).ready(function () {
    $('#datetimepicker1').datetimepicker();
});
//Set Email
$(document).ready(function () {
    sessionStorage.setItem("email", "pitiquis@gmail.com");
    $("#txtIdEmail").hide();
    $("#txtIdEmail").val(sessionStorage.getItem("email"));
});

function vCreateRequest() {

    this.ctrlActions = new ControlActions();

    this.Create = async function () {
        var formData = {};
        var MediaFlag = this.ValidateMedia();
        var RequestFlag = this.ValidateRequest();
        if (MediaFlag === false && RequestFlag === false) {
            try {
                formData = this.ctrlActions.GetDataForm('MediaForm');
                await this.ctrlActions.PostAsync("ProductMedia", formData);
                formData = this.ctrlActions.GetDataForm('RequestForm');
                formData.ElapsedTime = this.ConvertTime(formData.ElapsedTime);
                await this.ctrlActions.PostAsync("Request", formData);
                swal("Su Petición ha sido creada con éxito! ", "", "success").then((willDelete) => {
                    this.resetContent();
                    //window.location.href = "http://localhost:52014/Home/Index";
                });
            } catch (e) {
                swal("Hubo un error al realizar su petición", "", "error");
            }
        }
    };

    this.ValidateRequest = function () {
        var formData = {};
        var flag = false;
        var input = null;
        formData = this.ctrlActions.GetDataForm('RequestForm');

        if (formData.Description === null || formData.Description === "") {
            input = document.querySelector("#txtDescription");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            input = document.querySelector("#txtDescription");
            input.classList.remove('is-invalid');
        }

        if (formData.ElapsedTime === null || formData.ElapsedTime === "") {
            input = document.querySelector("#txtElapsedTime");
            input.classList.add('is-invalid');
            flag = true;
        } else {
            try {
                var time = Date.parse(formData.ElapsedTime);
                var now = Date.now();
                if (time <= now) {
                    flag = true;
                    input = document.querySelector("#txtElapsedTime");
                    input.classList.add('is-invalid');
                } else {
                    input = document.querySelector("#txtElapsedTime");
                    input.classList.remove('is-invalid');
                }

            } catch (e) {
                flag = true;
                input = document.querySelector("#txtElapsedTime");
                input.classList.add('is-invalid');
            }
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

        if (flag === true) {
            swal("Por favor,verifique que los espacios en rojo no esten vacíos o que sean válidos.", "", "error");
        }

        return flag;
    };

    this.Cancel = function () {
        window.history.back();
    };

    this.ConvertTime = function (time) {
        var elapsedTime = Date.parse(time);
        var date = new Date(elapsedTime);
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();
        var hour = date.getHours();
        var minute = date.getMinutes();
        var second = date.getSeconds();
        var result = month + "/" + day + "/" + year + " " + hour + ':' + minute + ':' + second;

        return result;
    };

    this.resetContent = function () {

        document.getElementById("RequestForm").reset();
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
    };
}
