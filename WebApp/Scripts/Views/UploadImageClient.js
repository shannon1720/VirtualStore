let imageUrl = '';

//Image for Id
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnUrl_Photo_Id');

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
                document.querySelector('#txtUrl_Photo_Id').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtUrl_Photo_Id').value);

                addbackgroundImage('#divUrl_Photo_Id', document.querySelector('#txtUrl_Photo_Id').value);
            });
    });
});
//Images for profile picture
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnUrl_Profile_Pric');

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
                document.querySelector('#txtUrl_Profile_Pric').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtUrl_Profile_Pric').value);

                addbackgroundImage('#divUrl_Profile_Pric', document.querySelector('#txtUrl_Profile_Pric').value);
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
