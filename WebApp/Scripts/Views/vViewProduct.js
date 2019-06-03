function vViewProduct() {
    this.service = "product";
    this.ctrlActions = new ControlActions();
    let cantproduct = 0;

    this.ObtainData = function () {

        let url = this.ctrlActions.GetUrlApiService(this.service + "?Id=" + sessionStorage.getItem("idProduct"));
        let infoProducts = this.ctrlActions.GetIDToAPI(url);
        console.log(infoProducts);
        this.createCards(infoProducts);
    };

    this.createCards = function (infoProducts) {
        let carrousel = document.querySelector('#content');
        if (infoProducts['State'] && infoProducts['Stock'] > 0) {
                let url = this.ctrlActions.GetUrlApiService("productMedia" + "?Id=" + infoProducts['IdMedia']);
                let infoMedia = this.ctrlActions.GetIDToAPI(url);
                
            this.Carrousel(infoMedia);
          
            this.carContent(infoProducts);  
        }
        

    };


    this.Carrousel = function (infoMedia) {
        let card = [infoMedia['Image1'], infoMedia['Image2'], infoMedia['Image3'], infoMedia['Image4'], infoMedia['Image5']];
       // JSON.stringify(card)
        let postcard = card;
        let info = new Array(6);
        let img = new Array(6);
        let j = 0;

        let carrousel = document.querySelector('#slideshow');
        let div1 = document.createElement('div');
        div1.classList.add('entire-content');
        let div2 = document.createElement('div');
        div2.classList.add('content-carrousel');
        for (let i in postcard) {
            if (postcard[i].length!==0) {
                info[j] = document.createElement('figure');
                info[j].classList.add('shadow');
                img[j] = document.createElement('img');
                img[j].src = postcard[i];
                info[j].appendChild(img[j]);
                div2.appendChild(info[j]);
                j++;
            }
        }
        if (infoMedia['Video'].length !== 0) {
           let info1 = document.createElement('figure');
            info1.classList.add('shadow');
            let video = document.createElement('video');
            video.controls = true;
            let src= document.createElement('source');
            src.src = infoMedia['video'];
            src.type="video/mp4"
            video.appendChild(src);
            info1.appendChild(video);
            div2.appendChild(info1);

        }
        div1.appendChild(div2);
        carrousel.appendChild(div1);
        
    }

    this.carContent = function(infoProducts){
        let mainCard = document.querySelector('#card');
        mainCard.setAttribute("class","card mb-3 ");
        let bodyCard = document.createElement('div');
        bodyCard.setAttribute("class"," row");
        let div1 = document.createElement('div');
        div1.setAttribute("class", " content col-lg-4")


        let title = document.createElement('h3');
        title.setAttribute("class", " card-title");
        let texTitle = document.createTextNode(infoProducts['Name']);
        title.appendChild(texTitle);
        div1.appendChild(title);

        let sub1 = document.createElement('h5');
        sub1.setAttribute("class", "card-subtitle mb-2 text-muted row");
        let textSub1 = document.createTextNode("Categoría: " + infoProducts['CategoryName']);
        sub1.appendChild(textSub1);
        div1.appendChild(sub1);

        let sub2 = document.createElement('h5');
        sub2.setAttribute("class", "card-subtitle mb-2 text-muted row");
        let textSub2 = document.createTextNode("Precio: " + parseFloat(infoProducts['PriceFinal']).toFixed(2));
        sub2.appendChild(textSub2);
        div1.appendChild(sub2);

        let sub3 = document.createElement('h5');
        sub3.setAttribute("class", "card-subtitle mb-2 text-muted row");
        let textSub3 = document.createTextNode("Proveedor: " + infoProducts['Provider']);
        sub3.appendChild(textSub3);
        div1.appendChild(sub3);

        let sub4 = document.createElement('h5');
        sub4.setAttribute("class", "card-subtitle mb-2 text-muted row");
        let textSub4 = document.createTextNode("Descripción: " + infoProducts['Description']);
        sub4.appendChild(textSub4);
        div1.appendChild(sub4);

        let div2 = document.createElement('div');
        div2.setAttribute("class", "col-lg-4")

        let btn = document.createElement('button');
        btn.setAttribute("class", "btnSetCar");
        let textbtn = document.createTextNode('Agregar al carrrito');
        btn.appendChild(textbtn);
        div2.appendChild(btn);
        btn.dataset.Id = infoProducts['Id'];


        bodyCard.appendChild(div1);
        bodyCard.appendChild(div2);
        mainCard.appendChild(bodyCard);

        btn.addEventListener('click', this.ADDCART);
    };

    this.ADDCART = function () {
        let idProduct = this.dataset.Id;

        let cart = [idProduct,1, sessionStorage.getItem('email')];
        ObtainID(cart);
    };
}


$(document).ready(function () {

    var vcards = new vViewProduct();
    vcards.ObtainData();
    crearArticuloCarrito();
})

function ObtainID(idProduct) {
    let cont = 0;
    let lslt = data();
    if (lslt.length === 0) {
        lslt.push(idProduct);
        localStorage.setItem('List', JSON.stringify(lslt));
        crearArticuloCarrito();
        createpost(idProduct);
    } else {
        for (let i = 0; i < lslt.length; i++) {
            if (lslt[i][0] === idProduct[0]) {
                swal(
                    'Oops...',
                    'Ya haz agregado este producto al carrito.',
                    'error'
                )
                cont++;
            }
        }
        if (cont === 0) {
            lslt.push(idProduct);
            localStorage.setItem('List', JSON.stringify(lslt));
            crearArticuloCarrito();
            createpost(idProduct);
        }
    }
};

function createpost(idProduct) {
    this.ctr = new ControlActions();
    let cart = { "idProduct": idProduct[0], "Quantity": 1, "Email": idProduct[2] }

    let response = this.ctr.PostWithResponse("cart", cart);
    const toast = swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 5000
    });

    toast({
        type: 'success',
        title: 'Se ha agregado al carrito.'
    })

    window.location.href = "http://localhost:52014/Client/vCards";
};

function data() {
    var guardado = JSON.parse(localStorage.getItem('List'));
    if (guardado === null) {
        guardado = []
    }
    return guardado;
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
        if (lslt.length !== 0) {
            nContadorArticulos = nContadorArticulos + 1;
        }
    }
    return nContadorArticulos;
};