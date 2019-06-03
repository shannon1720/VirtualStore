function vCards() {
    
    this.service = 'product';
    this.ctrlActions = new ControlActions();
    let cantproduct = 0;

        this.ObtainData = function () {

            let url = this.ctrlActions.GetUrlApiService(this.service);
            let infoProducts = this.ctrlActions.GetIDToAPI(url);
            
            this.createCards(infoProducts);
        };

    this.createCards = function (infoProducts) {
        let container = document.querySelector('#crds');

        for (var i = 0; i < infoProducts.length; i++) {
            if (infoProducts[i].Active && infoProducts[i].Stock>0) {
                let url = this.ctrlActions.GetUrlApiService("productMedia"+"?Id=" + infoProducts[i].IdMedia);
                let infoMedia = this.ctrlActions.GetIDToAPI(url);
                let divCard = document.createElement('div');
                divCard.classList.add('col-12');
                divCard.classList.add('col-sm-6');
                divCard.classList.add('col-md-4');
                divCard.classList.add('col-lg-3');
                divCard.classList.add('card');
                let divContent = document.createElement('div');
                divContent.classList.add('our-team');

                let contentImage = document.createElement('div');
                contentImage.classList.add('picture');
                let image = document.createElement('img');
                image.src = infoMedia['Image1'];
        
                contentImage.appendChild(image);
                divContent.appendChild(contentImage);

                 let divinfo = document.createElement('div');
                 divinfo.classList.add('team-content');
                 let element = document.createElement('h4');
                 let textType = document.createTextNode(infoProducts[i]['Name']);
             
                 element.appendChild(textType);
                 divinfo.appendChild(element);
    
             let element1 = document.createElement('h5'); 
                let textType1 = document.createTextNode('Precio:' + parseFloat(infoProducts[i]['PriceFinal']).toFixed(2));

                
                element1.appendChild(textType1);
                divinfo.appendChild(element1);


                let element3 = document.createElement('h5');
                let textType3 = document.createTextNode('Cantidad:');
                element3.appendChild(textType3);
                divinfo.appendChild(element3);
                let select = document.createElement('select');

                select.setAttribute("class", "custom-select custom-select-sm-1 mb-4");
                select.id = "slct" + i;
                for (var j = 1; j < infoProducts[i]['Stock']; j++) {
                    var option = document.createElement("option");
                    option.id = "" + j + "";
                    option.value = j;
                    option.text = j;
                    select.appendChild(option);
                }
               

                
               
                divinfo.appendChild(select);
                
                let btnAdd0 = document.createElement('button');
                let textadd0 = document.createTextNode('Ver más');
                btnAdd0.classList.add('btnAddCar');
                btnAdd0.dataset.Id = infoProducts[i]['Id'];
                btnAdd0.appendChild(textadd0);
                divinfo.appendChild(btnAdd0);

             let btnAdd = document.createElement('button');
             let textadd = document.createTextNode('Agregar');
             btnAdd.classList.add('btnSetCar');
             btnAdd.dataset.Id = infoProducts[i]['Id'];
             btnAdd.dataset.SltId = select.id;

             btnAdd.appendChild(textadd);
             divinfo.appendChild(btnAdd);
             divContent.appendChild(divinfo);
             divCard.appendChild(divContent);
             container.appendChild(divCard);

             btnAdd0.addEventListener('click',this.SetID); 
             btnAdd.addEventListener('click', this.ADDCART);
          }
        }
    };
    this.SetID = function () {
        let idProduct = this.dataset.Id;

        sessionStorage.setItem("idProduct", idProduct);
        window.location.href = "http://localhost:52014/Product/vViewProduct";
    }
   
    this.ADDCART = function () {
        let val = this.dataset.SltId;
        let valor = document.querySelector("#" + val).value;
       
        let idProduct = this.dataset.Id;
    
        let cart = [idProduct, Number(valor), sessionStorage.getItem('email')];
       ObtainID(cart);
    };
};

$(document).ready(function () {

    var vcards = new vCards();
    vcards.ObtainData();
    crearArticuloCarrito();
});

function ObtainID(idProduct) {
    let cont = 0;
    let lslt =data();
    if (JSON.stringify(lslt) == '{}') {
        createpost(idProduct);
        crearArticuloCarrito();
    } else {
   
        for (let i = 0; i < lslt.length; i++) {
            if (lslt[i]['IdProduct'] === Number(idProduct[0])) {
                swal(
                    'Oops...',
                    'Ya haz agregado este producto al carrito.',
                    'error'
                )
                cont++;
            }
        }
        if (cont === 0) {
         
           
            createpost(idProduct);
            crearArticuloCarrito();
        }
    }
};

function createpost(idProduct) {
    this.ctr = new ControlActions(); 
    let cart = { "IdProduct": idProduct[0], "Quantity": idProduct[1], "Email": idProduct[2] }
    
    let response = this.ctr.PostWithResponse("cart", cart);
    const toast = swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });

    toast({
        type: 'success',
        title: 'Se ha agregado al carrito.'
    })


};

function data() {
    
    let ctrlActions5 = new ControlActions()
    let url = ctrlActions5.GetUrlApiService("cart" + "?Email=" + sessionStorage.getItem('email'));
    let infoCart = ctrlActions5.GetIDToAPI(url);
    return infoCart;
};

function crearArticuloCarrito() {
    let divConCart1 = document.querySelector('#divConCart');
    limpiarCarrito(divConCart1);
    mostrarCarrito(divConCart1);
};

function mostrarCarrito(divConCart1) {
    let btnCarrito = document.createElement('a');
    btnCarrito.classList.add('fa');
    btnCarrito.classList.add('fa-shopping-cart');
    btnCarrito.classList.add('botonCarrito');
  
    divConCart1.appendChild(btnCarrito);
   let cantidadCarrito = contarMiCarrito();
    let elementoCantidad = document.createElement('h3');
    let textoCantidad = document.createTextNode(cantidadCarrito);
    elementoCantidad.appendChild(textoCantidad);
    divConCart1.appendChild(elementoCantidad);
};

function limpiarCarrito(divConCart1) {
    divConCart1.innerHTML = '';
};

function contarMiCarrito() {
    let lslt = data();
    let nContadorArticulos = 0;
    for (let i = 0; i < lslt.length; i++) {
        if (JSON.stringify(lslt)!=='{}') {
            nContadorArticulos = nContadorArticulos+1;
        }
    }
    return nContadorArticulos;
};
