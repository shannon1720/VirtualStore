//Fill Category select
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Category");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
    });
});

$(document).ready(function () {
    $('#txtStore').hide();
    $('#txtId_C').hide();
   $('#txtLong').hide();
   $('#txtLat').hide();   
    let updateStore = new vUpdateStore();
    updateStore.obtainData();
});

$(document).ready(function () {
   
    $("#txtPhone").mask("0000-0000");
    $("#txtPhoneStore").mask("0000-0000");

});

function vUpdateStore() {
    this.service = 'store';
    this.ctrlActions = new ControlActions();

    this.Update = function (cont) {
        if (cont === 0) {
            var storeData = {};
            let dataCellar = {};
            dataCellar = this.ctrlActions.GetDataForm('frmCellar');
            storeData = this.ctrlActions.GetDataForm('frmStore');
            //Hace el post al create
           
            try {
                this.ctrlActions.PutToAPI(this.service, storeData);
                this.ctrlActions.PutToAPI("cellar", dataCellar);
                swal("Se ha modificado correctamente.", "", "success").then((willDelete) => {
                    this.obtainData();

                });

            } catch (e) {

                swal("Hubo un error al registrar su cuenta", e, "error");
            }

        }
    }



    this.ValidateInputs = function () {
        var listInput = document.querySelectorAll("input");
        var cont = 0;
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].value.length === 0) {
                listInput[i].classList.add('is-invalid');
                swal("Por favor verifique que los espacios en rojo no esten vacíos.", "", "error");
                cont++;

            } else {
                listInput[i].classList.remove("is-invalid");
            }
        }
        this.Update(cont);
    };


    this.obtainData = function () {

        var email = sessionStorage.getItem('email');
        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + email);
        let response = this.ctrlActions.GetIDToAPI(url);
        let url2 = this.ctrlActions.GetUrlApiService("cellar?Id_Store=" + response[0].Id);
        var response2 = this.ctrlActions.GetIDToAPI(url2);
        console.log(response, response2);

        this.fillForm(response, response2);

    };

    this.fillForm = function (response, response2) {
        $('#txtURLlogo').val(response[0]['Logo']);
        this.addbackgroundImage('#divImagen', document.querySelector('#txtURLlogo').value);
        $('#txtNumber').val(response[0]['Id']);
        $('#txtName').val(response[0]['Name']);
        $('#txtPhoneStore').val(response[0]['Phone']);
        $('#txtId_C').val(response2['Id']);
        $('#txtAddress1').val(response2['Address']);
        $('#txtStore').val(response2['Id_Store'])
        $('#txtLong').val(response2['Longitude']);
        $('#txtLat').val(response2['Latitude']);
        $('#CategorySelect').find("option[value='" + response[0].Category + "']").attr('selected', true);
        initMap(response2['Latitude'], response2['Longitude']);
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

}
var map;
function initMap(latitud, longitud) {
    var zoom = 7;
    let panel;
    if (latitud == 'undefined' && longitud == 'undefined') {
        costaRica = { lat: 9.922114582760013, lng: -84.08251953125 };
        panel = false;
    } else {
        costaRica = { lat: latitud, lng: longitud };
        zoom = 15;

    }
    map = new GMaps({
        div: '#map',
        lat: costaRica.lat,
        lng: costaRica.lng,
        zoom: zoom
    });


    if (panel == true) {
        map.addMarker({
            lat: costaRica.lat,
            lng: costaRica.lng,


        });
    } else {
        map.addMarker({
            lat: costaRica.lat,
            lng: costaRica.lng,
            draggable: true,
            dragend: function (event) {
                $("#txtLat").val(event.latLng.lat());
                $("#txtLong").val(event.latLng.lng());
            }
        });
    }
};