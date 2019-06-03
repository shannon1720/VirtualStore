function exception() {


    this.service = 'connection';
    this.ctrlActions = new ControlActions();
    let cantproduct = 0;

    this.ObtainData = function () {

        let url = this.ctrlActions.GetUrlApiService(this.service);
        let response = this.ctrlActions.GetIDToAPI(url);
        xhr.open('GET', '/server', true);
        if (xhr.status===0) {
            swal(
                '',
               'Oh no!Tenemos problemas con nuestro servidor.Por favor vuelva mas tarde.',
                'error'
            )


        }
        console.log('OPENED', xhr.status);
       
    };



    var xhr = new XMLHttpRequest();
    console.log('UNSENT', xhr.status);

    xhr.open('GET', '/server', true);
    console.log('OPENED', xhr.status);

    xhr.onprogress = function () {
        console.log('LOADING', xhr.status);
    };

    xhr.onload = function () {
        console.log('DONE', xhr.status);
    };

    xhr.send(null);

};
//ON DOCUMENT READY
$(document).ready(function () {
    var vretrieveConnection = new exception();
    vretrieveConnection.ObtainData();
});