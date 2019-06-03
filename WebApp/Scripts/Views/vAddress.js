function vAddress() {

    this.service = 'address'
    this.ctrlActions = new ControlActions();

    this.Create = function () {
        var bussinesData = {};
        bussinesData = this.ctrlActions.GetDataForm('frmAddress');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, bussinesData);
        //Refresca la tabla
        // this.ReloadTable();

    }


}