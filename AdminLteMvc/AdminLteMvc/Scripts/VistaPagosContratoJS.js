var ViewModleContratoPagos = function () {
    var self = this;
    self.ContratoPagos = ko.observableArray();
    self.error = ko.observable();
    self.visitaDetail = ko.observable();

    var host = '200.6.245.76:8095';//document.location.host;

    var ContratoPagosUri = 'http://'.concat(host, '/api/CrudContratos/ContratoPago');

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

    // Get Data
    function getAllContratoPagos() {
        ajaxHelper(ContratoPagosUri + '?codigoContrato=1', 'GET').done(function (data) {
            self.ContratoPagos(data);
        });
    }
    // End Get Data

    // Recuperar datos iniciales
    getAllContratoPagos();

};

ko.applyBindings(new ViewModleContratoPagos());