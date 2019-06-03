$(document).ready(function () {

    var vcardsStore = new vCardsStore();
    vcardsStore.ObtainData();
});

function vCardsStore() {
    this.service = 'Store';
    this.ctrlActions = new ControlActions();

    this.ObtainData = function () {

        const url = this.ctrlActions.GetUrlApiService(this.service);
        const dataStore = this.ctrlActions.GetIDToAPI(url);

        this.createCardsStore(dataStore);
    };

    this.createCardsStore = function (dataStore) {
        const container = document.querySelector('#crds');
        for (let i = 0; i < dataStore.length; i++) {
            if (dataStore[i].Active) {
               // let url = this.ctrlActions.GetUrlApiService("Store" + "?Id=" + dataStore[i].Logo);
                //let infoMedia = this.ctrlActions.GetIDToAPI(url);
                console.log(dataStore);
                const divproyect = document
                    .createRange()
                    .createContextualFragment(`
                    <div class="col-12 col-sm-6 col-md-4 col-lg-3 card">
                        <div class='our-team'>
                             <div class="picture">
                                <img src="${dataStore[i].Logo}"/>
                            </div>
                            <div class="team-content" ">
                                <h4> ${dataStore[i].Name}</h3>
                                  <br>    
                                <button type="button" class="btnAddCar" data-store-name="${dataStore[i].Name}" data-slt-id="slct0">Ir a tienda.</button>
                             </div>
                        </div>
                    </div>
                `);
                container.appendChild(divCard);

                document
                    .querySelectorAll('button.btnAddCar')
                    .forEach(function (theButton) {
                        theButton.addEventListener("click", function (e) {
                            const storename = e.target.dataset.storeName;
                            swal('vista tienda ' + storename);
                        })
                    });
            }
        }
    };
};