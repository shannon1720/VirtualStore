﻿function ControlActions() {

    var self = this;

	this.URL_API = "http://localhost:57056/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    };


    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");

        return val;
    };

    this.FillTable = function (service, tableId, refresh) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
                },
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data'
                },
                "columns": arrayColumnsData
            });

        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();

        }

    };

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {


        console.log(data);
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
        });
    };

    this.GetDataForm = function (formId) {
        var data = {};

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;
        });

        console.log(data);
        return data;
    };

    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert alert-success alert-dismissable")
            $("#alert_container").addClass("alert alert-danger alert-dismissable");
            $("#alert_message").text(message);
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert alert-danger alert-dismissable")
            $("#alert_container").addClass("alert alert-success alert-dismissable");
            $("#alert_message").text(message);
        }
        $('.alert').show();
    };

    this.PostToAPI = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
       
    };

    this.PostAsync = function (service, data) {
        return $.post(this.GetUrlApiService(service), data)
            .then(function (response) {
                console.log('Data obtenida del servidor', response);
                return response;
            })
            .fail(function (error) {
                console.error(error);
                return error.responseJSON;
            });
    };

    this.GetToAPI = function (service, data) {
        var response = {};
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            response = data['Data'];

        });
        return response;
    };

    this.PostWithResponse = function (service, data) {
        var serverResponse;
        var request = $.ajax({
            url: this.GetUrlApiService(service),
            type: "post",
            data: data,
            contentType: "application/x-www-form-urlencoded;charset=ISO-8859-15",
            dataType: "json",
            async: false,
            success: function (response) {
                serverResponse = response;
            },
            error: function (request, error) {
                console.log(error);
            }
        });
        return serverResponse;
    };

	this.PutToAPI = function (service, data) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};

    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };


    this.GetToAPI = function (service, data) {
        var serverResponse = {};
        var request = $.ajax({
            url: this.GetUrlApiService(service),
            type: "post",
            data: data,
            contentType: "application/x-www-form-urlencoded;charset=ISO-8859-15",
            dataType: "json",
            async: false,
            success: function (response) {
                serverResponse = response;
            },
            error: function (request, error) {
                console.log(error);
            }
        });
        return serverResponse;
    };


    this.GetIDToAPI = function (url) {
        var response = {};
        try {
            $.ajax({
                type: "GET",
                url: url,
                cache: false,
                async: false,
                success: function (data) {
                    response = data['Data'];
                }
            });
        } catch (err) {
            console.log(err);
        }
        return response;
    };
     




    //Custom jquery actions
    $.put = function (url, data, callback) {
        if ($.isFunction(data)) {
            type = type || callback,
                callback = data,
                data = {}
        }
        return $.ajax({
            url: url,
            type: 'PUT',
            success: callback,
            data: JSON.stringify(data),
            contentType: 'application/json'
        });
    }




    $.get = function (url, data, callback) {
        if ($.isFunction(data)) {
            type = type || callback,
                callback = data,
                data = {}
        }
        return $.ajax({
            url: url,
            type: 'GET',
            success: callback,
            data: JSON.stringify(data),
            contentType: 'application/json'
        });
    }

    $.delete = function (url, data, callback) {
        if ($.isFunction(data)) {
            type = type || callback,
                callback = data,
                data = {}
        }
        return $.ajax({
            url: url,
            type: 'DELETE',
            success: callback,
            data: JSON.stringify(data),
            contentType: 'application/json'
        });
    };

}