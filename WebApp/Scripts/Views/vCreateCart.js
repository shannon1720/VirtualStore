let cobrototal = 0;
let subtotalCarrito = 0;
let total = 0;
let position1;
let divTotal = 0;
let infoCart;
let infoborrada = {};
let select = document.querySelector("#ShippingSelect").value;
$(document).ready(function () {
    $('#btnPay1').hide();
    $('#btnPay2').hide();
    var vcart = new vCreateCart();
    vcart.ObtainData();
    $('#divProvider').hide();
    $('#txtLong').hide();
    $('#txtLat').hide();
  
    navigator.geolocation.getCurrentPosition(success); 
    
});
$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("shipping");
    var proveedores = this.ctrlActions.GetIDToAPI(URL);
    proveedores.forEach(function (proveedor) {
        $("#ShippingSelect").append($("<option></option>").attr("value", proveedor.Id).text(proveedor.Name));
    });
});
function vCreateCart() {
    this.service = "cart";
    this.ctrlActions = new ControlActions();

    this.ObtainData = function () {
       
        let ctrlActions5 =new ControlActions()
        let url = ctrlActions5.GetUrlApiService(this.service + "?Email=" + sessionStorage.getItem('email'));
        infoCart = ctrlActions5.GetIDToAPI(url);
        if(infoCart.length!==0){
        this.createTable(infoCart);
        } else {
            $('#cardC').hide();
            swal(
                'Oops...',
                'No haz agregado ningun producto al carrito.',
                'error'
            )

        }
    };
    
    this.createTable = function (infoCart) {
        var tblcart = $("#tbodyCarrito");
        $("#tbodyCarrito").empty();
        let ctrlActions2 = new ControlActions();
        
        if (JSON.stringify(infoborrada) !== '{}') {
            subtotalCarrito = 0;
            divTotal = 0;
            $.each(infoCart, function (index, item) {
               
                    if (infoborrada['Cart'] !== item.Id) {
                        let url2 = "http://localhost:57056/api/product" + "?Id=" + item.IdProduct;
                        let infoProduct = ctrlActions2.GetIDToAPI(url2);
                        let url3 = ctrlActions2.GetUrlApiService("productMedia" + "?Id=" + infoProduct['IdMedia']);
                        let infoMedia = ctrlActions2.GetIDToAPI(url3);

                        var tr = $("<tr></tr>");
                        tr.html(("<td><a class='fa fa-times-circle'  onclick='DeleteProduct(" + item.Id + ")'></a></td>")
                            + " " + ("<td><img src='" + infoMedia['Image1'] + "'height='50' width='50'></td>")
                            + " " + ("<td>" + infoProduct['Name'] + "</td>")
                            + " " + ("<td>" + item['Quantity'] + "</td>")
                            + " " + ("<td>" + parseFloat(infoProduct['PriceFinal']).toFixed(2) + "</td>")
                            + " " + ("<td>" + parseFloat(parseFloat(infoProduct['PriceFinal']).toFixed(2) * item['Quantity']).toFixed(2) + "</td>"));
                       
                        divTotal = parseFloat(parseFloat(infoProduct['PriceFinal']).toFixed(2) * item['Quantity']).toFixed(2);
                        divPago(divTotal);
                        tblcart.append(tr);

                    }
               
            });
        } else {
            $.each(infoCart, function (index, item) {

                let url2 = "http://localhost:57056/api/product" + "?Id=" + item.IdProduct;
                let infoProduct = ctrlActions2.GetIDToAPI(url2);
                let url3 = ctrlActions2.GetUrlApiService("productMedia" + "?Id=" + infoProduct['IdMedia']);
                let infoMedia = ctrlActions2.GetIDToAPI(url3);

                var tr = $("<tr></tr>");
                tr.html(("<td><a class='fa fa-times-circle'  onclick='DeleteProduct(" + item.Id + ")'></a></td>")
                    + " " + ("<td><img src='" + infoMedia['Image1'] + "'height='50' width='50'></td>")
                    + " " + ("<td>" + infoProduct['Name'] + "</td>")
                    + " " + ("<td>" + item['Quantity'] + "</td>")
                    + " " + ("<td>" + parseFloat(infoProduct['PriceFinal']).toFixed(2) + "</td>")
                    + " " + ("<td>" + parseFloat(parseFloat(infoProduct['PriceFinal']).toFixed(2) * item['Quantity']).toFixed(2) + "</td>"));
                divTotal = parseFloat(parseFloat(infoProduct['PriceFinal']).toFixed(2) * item['Quantity']).toFixed(2);
                divPago(divTotal);
                tblcart.append(tr);



            });




        }
    };     
};
function Pay() {
    let longFin = $('#txtLong').val();
    let latFin = $('#txtLat').val();
    let list = data();
    this.service = "recipe";
    this.ctrlActions7 = new ControlActions();
    var recipeData = {};
    recipeData = {
        "Email": sessionStorage.getItem('email'),
        "IdProvider": Number(select),
        "TotalProvider": Number(cobrototal),
        "Total": total,
        "Latitud": Number(longFin),
        "Longitud": Number(latFin)
    };
    let recipeCart = {};
   
  
    var response = this.ctrlActions7.PostWithResponse(this.service, recipeData);
    swal(response.Message, "", "success").then((willDelete) => {
        let url = this.ctrlActions7.GetUrlApiService(this.service);
        infoRecipe = this.ctrlActions7.GetIDToAPI(url);
        for (let j = 0; j < infoCart.length; j++) {
            recipeCart = { "Id_Recipe": infoRecipe["Id"], "Id_Cart": infoCart[j]["Id"]};
            this.ctrlActions7.PostWithResponse("recipe_Cart", recipeCart);
            let cart = { "Id": infoCart[j]["Id"] };
            this.ctrlActions7.DeleteToAPI("cart", cart);
            recipeCart = {};
        }

        Clean();
    });
};
function data() {
    var guardado = JSON.parse(localStorage.getItem('ListCart'));
    if (guardado === null) {
        guardado = []
    }
    return guardado;
};
function DeleteProduct(Id) {
    let sCodigo = Id;
    let cart = { "Id": sCodigo };
    infoborrada = { "Cart": Number(sCodigo) };
    localStorage.setItem("Eliminado", JSON.stringify(infoborrada));
    Display(cart);
    
};
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success);
    } else {
        console.log("Geolocation is not supported by this browser.");
    }
}
function success(position) {
  let  position3 = position.coords;
    console.log('Latitude : ' + position3.latitude);
    console.log('Longitude: ' + position3.longitude);
    position1= position3;
};
function Display(cart) {
    let ctrlActions = new ControlActions();
    swal({
        title: '¿Seguro  que desea eliminar este producto del carrito?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí,eliminelo',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.value) {
            ctrlActions.DeleteToAPI("cart", cart);
            swal(
                '',
                'El producto seleccionado se ha eliminado.',
                'success'
            )
                var vcart = new vCreateCart();
                vcart.ObtainData();
        }
    });
};
function ProviderPay() {    
    $('#divProvider').show();
    $("#ShippingSelect").change(function () {
        getLocation();
        divProvider();
        $('#btnPay1').hide();
        $('#btnPay2').show();
    });

};
function carrito(cosa) {

    let divTotal2 = $("#divTotal");
    $("#divTotal").empty();

    if (cosa) {
       
        divTotal2.append("<h4 class='card-title'>Subtotal:₡" + parseFloat(subtotalCarrito).toFixed(2) + "\n</h4>");
        total = Number(subtotalCarrito) + Number(cobrototal);
        divTotal2.append("<h4 class='card-title'>\nCobro de envío:₡" + cobrototal + "</h4 >");
        divTotal2.append("<h4 class='card-title'>Total:₡" + total + "\n</h4>");

    } 
};
function divPago(divTotal) {
    
    let divTotal2 = $("#divTotal");
    $("#divTotal").empty();
    subtotalCarrito += Number(divTotal);  
    divTotal2.append("<h4 class='card-title'>Subtotal:₡" + parseFloat(subtotalCarrito).toFixed(2) + "\n</h4>");

  
};
function divProvider() {
    select = document.querySelector('#ShippingSelect').value;
    let ctrlActions = new ControlActions();
    let divTotal3 = document.querySelector("#divTotal");
  //  document.querySelector("#divTotalCobro").innerHTML = "";
    var URL = ctrlActions.GetUrlApiService("shipping");
    var proveedores = ctrlActions.GetIDToAPI(URL);
    $.each(proveedores, function (index, item) {
       
        if (item.Id === Number(select)) {
            let dis = crearDistancia(parseFloat(item.Minimum_Rate).toFixed(2));

 
            cobrototal = parseFloat(dis).toFixed(2);
            
            carrito(true);
            
        }
    })
};
function crearDistancia(dato) {
    let totalWithDistancia = 0;
    let longIn = position1.longitude;
    let latIn = position1.latitude;
    let longFin = $('#txtLong').val();
    let  latFin = $('#txtLat').val();
    if (longFin !=="" && latFin !=="") {
        var x1 = new google.maps.LatLng(latIn,longIn);
        var x2 =  new google.maps.LatLng(latFin,longFin);
        var distancia = google.maps.geometry.spherical.computeDistanceBetween(x1, x2) / 1000;

        totalWithDistancia = Number(distancia)  * Number(dato);
    } else {
        
     
        totalWithDistancia = dato; 
    }
    return parseFloat(totalWithDistancia).toFixed(2);
};
function initMap() {
    var zoom = 15;
    let map
        costaRica = { lat: 9.922114582760013, lng: -84.08251953125 };
    map = new GMaps({
        div: '#map',
        lat: costaRica.lat,
        lng: costaRica.lng,
        zoom: zoom
    });
        map.addMarker({
            lat: costaRica.lat,
            lng: costaRica.lng,
            draggable: true,
            dragend: function (event) {
                $("#txtLong").val(event.latLng.lng());
                $("#txtLat").val(event.latLng.lat());
            }
        }); 
};
function DivMap() {
    $('#divMap').show();
    $('#map').show();
    $('#btnPay').hide();
    $('#btnPay1').show();
};
function Clean() {
    var vcart = new vCreateCart();
    vcart.ObtainData();
    $('#divMap').hide();
    $("#tbodyCarrito").empty();
    localStorage.clear();
    $('#divProvider').hide();
    $('#cardC').hide();
};
