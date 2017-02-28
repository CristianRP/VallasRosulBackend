var ViewModleVisitas = function () {
    var self = this;
    self.visitas = ko.observableArray();
    self.Panel = ko.observableArray();
    self.error = ko.observable();
    self.visitaDetail = ko.observable();

    var host = '200.6.245.76:8095';//document.location.host;

    var visitasUri = 'http://'.concat(host, '/api/VistaVisitas');
    var PanelUri = 'http://'.concat(host, '/api/VistaPanel');

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

    ///self.contratos el objeto del grid 
    function getAllPanel(item) {
        //ajaxHelper(ContratoPagosUri + '?codigoContrato=' + item.CodigoContrato, 'GET').done(function (data) {
            ajaxHelper(PanelUri + '?fecha1=01/01/2000&fecha2=12/12/2099', 'GET').done(function (data) {
            self.Panel(data);
        });
    }
 

        // Get Data
    function getAllVisitas() {
        ajaxHelper(visitasUri + '?fecha1=01/01/2000&fecha2=12/12/2099', 'GET').done(function (data) {
            self.visitas(data);
        });
    }
    // End Get Data

        // Recuperar datos iniciales
    getAllVisitas();
    
    getAllPanel();
    };

    ko.applyBindings(new ViewModleVisitas());