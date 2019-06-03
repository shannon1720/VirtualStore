let inputFoto = document.querySelector('#btnSelectImage');
let imageUrl = '';

/*Función que llama al api de cloudinary y sube la imagen al URL*/
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnSelectImage');

    // Upload button event
    uploadButton.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'zehitec', upload_preset: 'proyecto', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                // If NO error, log image data to console
                let id = result[0].public_id;
                console.log(id);
                imageUrl = processImage(id);
                document.querySelector('#txtURLlogo').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtURLlogo').value);

                addbackgroundImage('#divImagen', document.querySelector('#txtURLlogo').value);
            });
    });
});

$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnSelectImage1');

    // Upload button event
    uploadButton.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'zehitec', upload_preset: 'proyecto', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                // If NO error, log image data to console
                let id = result[0].public_id;
                console.log(id);
                imageUrl = processImage(id);
                document.querySelector('#txtFile').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtFile').value);

                addbackgroundImage('#divImagen', document.querySelector('#txtFile').value);
            });
    });
});




$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnSelectImage2');

    // Upload button event
    uploadButton.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'zehitec', upload_preset: 'proyecto', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                // If NO error, log image data to console
                let id = result[0].public_id;
                console.log(id);
                imageUrl = processImage(id);
                document.querySelector('#txtphotoId').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtphotoId').value);

                addbackgroundImage('#divImagen1', document.querySelector('#txtphotoId').value);
            });
    });
});
/*Función que devuelve la dirección URL de la imagen agregada a cloudinary*/
function processImage(id) {
    let options = {
        client_hints: true
    };
    return $.cloudinary.url(id, options);
}

function addbackgroundImage(pIdElemento, pUrlImagen) {
    document.querySelector(pIdElemento).style.backgroundImage = "url('" + pUrlImagen + "')";
    document.querySelector(pIdElemento).style.backgroundSize = "contain";
    document.querySelector(pIdElemento).style.backgroundPosition = "center";
    document.querySelector(pIdElemento).style.backgroundRepeat = "no-repeat";
}

function UploadImage() {
    $(document).ready(function () {
        $("#txtId").blur(function () {
            $("#txtId").mask("0-0000-0000");
        });
    });
}
