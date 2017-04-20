var ViewModelLogin = function () { 
    var self = this;
    self.supervisores = ko.observableArray();
    self.error = ko.observable();

    var host = '200.6.245.76:8095';

    var SupervisorApi = 'http://'.concat(host, '/api/Supervisores/User');

    function ajaxHelper(uri, method, data) {
        self.error(''); // Borra mensaje de error
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
            console.log(errorThrown);
        });
    }


    self.username = ko.observable();
    self.password = ko.observable();

    self.onclicklogin = function login() {
        ajaxHelper(SupervisorApi + '?username=' + self.username() + '&password=' + self.password(), 'POST').done(function (data) {
            alert(data);
        });
    }

}

ko.applyBindings(new ViewModelLogin());