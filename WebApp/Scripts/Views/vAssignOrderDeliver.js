$(document).ready(function () {
    this.ctrlActions = new ControlActions();
    var URL = this.ctrlActions.GetUrlApiService("Order");
    var categories = this.ctrlActions.GetIDToAPI(URL);
    categories.forEach(function (category) {
        $("#CategorySelect").append($("<option></option>").attr("value", category.ID).text(category.Name));
    });
});