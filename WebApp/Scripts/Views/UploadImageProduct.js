//Images for products 1
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnProductImage1');

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
                document.querySelector('#txtImage1').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtImage1').value);

                addbackgroundImage('#divImage1', document.querySelector('#txtImage1').value);
            });
    });
});
//Images for products 2
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnProductImage2');

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
                document.querySelector('#txtImage2').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtImage2').value);

                addbackgroundImage('#divImage2', document.querySelector('#txtImage2').value);
            });
    });
});
//Images for products 3
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnProductImage3');

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
                document.querySelector('#txtImage3').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtImage3').value);

                addbackgroundImage('#divImage3', document.querySelector('#txtImage3').value);
            });
    });
});
//Images for products 4
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnProductImage4');

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
                document.querySelector('#txtImage4').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtImage4').value);

                addbackgroundImage('#divImage4', document.querySelector('#txtImage4').value);
            });
    });
});
//Images for products 5
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/image/upload/';
    let uploadButton = $('#btnProductImage5');

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
                document.querySelector('#txtImage5').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtImage5').value);

                addbackgroundImage('#divImage5', document.querySelector('#txtImage5').value);
            });
    });
});
//Video
$(document).ready(function () {
    // Configure Cloudinary
    // with credentials available on
    // your Cloudinary account dashboard
    $.cloudinary.config({ cloud_name: 'zehitec', api_key: '246966548626964' });

    // Upload button
    let cloudinaryURL = 'https://res.cloudinary.com/zehitec/video/upload/';
    let uploadButton = $('#btnVideo');

    // Upload button event
    uploadButton.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'zehitec', upload_preset: 'proyecto', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                // If NO error, log image data to console
                console.log(result[0]);
                let id = result[0].public_id;
                console.log(id);
                imageUrl = processImage(id);
                document.querySelector('#txtVideo').value = cloudinaryURL + id;
                console.log(document.querySelector('#txtVideo').value);

                addVideoPlayer('#divVideo', document.querySelector('#txtVideo').value);
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

function addVideoPlayer(pIdElemento, pUrlVideo) {
    document.querySelector(pIdElemento).innerHTML = '<video width="280" height="280" controls><source src="' + pUrlVideo + '" type="video/mp4"></video>';
    document.querySelector(pIdElemento).style.background = "black";
}
