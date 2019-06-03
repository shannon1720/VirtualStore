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