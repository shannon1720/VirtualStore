function vcontCar() {
    this.service = "cart";
    this.ctrlActions = new ControlActions()
    let nContadorArticulos = 0;
    this.CrearArticuloCarrito = function () {
        let divConCart1 = document.querySelector('#divConCart');
        this.LimpiarCarrito(divConCart1);
        this.MostrarCarrito(divConCart1);
    };

    this.Data=function() {
        let url = this.ctrlActions.GetUrlApiService(this.service + "?Email=" + sessionStorage.getItem('email'));
        let infoCart = this.ctrlActions.GetIDToAPI(url);
        return infoCart;
    };
    this.MostrarCarrito = function (divConCart1) {
        let btnCarrito = document.createElement('a');
        btnCarrito.classList.add('fa');
        btnCarrito.classList.add('fa-shopping-cart');
        btnCarrito.classList.add('botonCarrito');

        divConCart1.appendChild(btnCarrito);
        let cantidadCarrito = this.ContarMiCarrito();
        let elementoCantidad = document.createElement('h3');
        let textoCantidad = document.createTextNode(cantidadCarrito);
        elementoCantidad.appendChild(textoCantidad);
        divConCart1.appendChild(elementoCantidad);
    };


    this.LimpiarCarrito=function(divConCart1) {
        divConCart1.innerHTML = '';
    };
    this.ContarMiCarrito=function() {
        let lslt =this.Data();
      
        for (let i = 0; i < lslt.length; i++) {
            if (JSON.stringify(lslt) !== '{}') {
                nContadorArticulos = nContadorArticulos + 1;
            }
        }
        return nContadorArticulos;
    };
}
$(document).ready(function () {

    var vcards = new vcontCar();
    vcards.CrearArticuloCarrito();

});