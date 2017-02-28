var ViewModleContratos = function () {
    var self = this;
    self.ContratosVistaSP = ko.observableArray();
    self.ContratoPagos = ko.observableArray();
    self.error = ko.observable();
    self.visitaDetail = ko.observable();

    var host = '200.6.245.76:8095';//document.location.host;
   
    var ContratosVistaSPUri = 'http://'.concat(host, '/api/CrudContratos/Contrato');
    var ContratoPagosUri = 'http://'.concat(host, '/api/CrudContratos/ContratoPago');
    var PagosUri = 'http://'.concat(host, '/api/CrudContratos/ContratoPagos');
    var PagosUpdateUri = 'http://'.concat(host, '/api/CrudContratos/UpdateContratoPagos');
                                                  
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

     

    // RECIBE LOS DATOS DEL HMTL
    self.newEvento = {

        CodigoContrato:   ko.observable(null),
        id: ko.observable(null),
        Fecha: ko.observable(null),//"2017-07-27T20:00:00"
        Monto: ko.observable(null),
        Pagado: ko.observable(null),
        NoFactura: ko.observable(null)
    }

    ////INSERTA PAGO

    self.contratoCodigo = {
        CodigoContrato: ko.observable()
    }

    self.setContratoCodigo = function (item) {
        self.contratoCodigo.CodigoContrato(item.CodigoContrato);
    }

    self.addEvento = function (form,item)  {
        
        var e = {
            CodigoContrato: self.contratoCodigo.CodigoContrato(), ////observable
            Fecha: self.newEvento.Fecha(),
            Monto: self.newEvento.Monto(),
            Pagado: self.newEvento.Pagado(),
            NoFactura: self.newEvento.NoFactura(),
        }
        ajaxHelper(PagosUri + '?codigoContrato=' + e.CodigoContrato + '&fecha=' + e.Fecha + '&monto=' + e.Monto + '&pagado=' + e.Pagado + '&noFactura=' + e.NoFactura + '', 'POST').done(function (item) {
        
        getAllEvents();

        });

        $("#agregarEvento").modal('hide');
     }

    ///self.contratos el objeto del grid 
    self.contratosPagos = function getAllContratoPagos(item) {
        ajaxHelper(ContratoPagosUri + '?codigoContrato=' + item.CodigoContrato, 'GET').done(function (data) {
            self.ContratoPagos(data);
        });
    }

    self.selectedEvent = {
        Codigo_Contrato: ko.observable(),
        id: ko.observable(),
        Fecha: ko.observable(),
        Monto: ko.observable(),
        NoFactura: ko.observable(),
        Pagado: ko.observable()
    }

    //SELECCIONAR EVENTO
    self.selectEvent = function (item) {
         
        self.selectedEvent.Codigo_Contrato(item.Codigo_Contrato);
         
        self.selectedEvent.id(item.id);

        self.selectedEvent.Fecha(item.Fecha);
        self.selectedEvent.Monto(item.Monto);
        self.selectedEvent.Pagado(item.Pagado);
        self.selectedEvent.noFactura(item.noFactura);
    }
    //EDITAR EVENTO
    self.updateEvent = function () {
        var e = {
            Codigo_Contrato: self.selectedEvent.Codigo_Contrato(),
            id: self.selectedEvent.id(),
               Fecha: self.selectedEvent.Fecha(),
               Monto: self.selectedEvent.Monto(),
               Pagado: self.selectedEvent.Pagado(),
               noFactura: self.selectedEvent.noFactura(),
            //CategoriaId: self.selectedEvent.Categoria().Id
        }
        //ajaxHelper(EventosUri + self.selectedEvent.Id, 'PUT', e).done(function (data) {
        ajaxHelper(PagosUpdateUri + '?codigoContrato=' + e.codigoContrato + '&fecha=' + e.Fecha + '&monto=' + e.Monto + '&pagado=' + e.Pagado + '&noFactura=' + e.noFactura + '&codigoPago=' + e.id + '', 'PUT').done(function (item) {
             getAllEvents();
            $("#editarEvento").modal('hide');
        });
    }


     

    // Get Data
    function getAllContratosVistaSP()  {
        ajaxHelper(ContratosVistaSPUri, 'GET').done(function (data) {
            self.ContratosVistaSP(data);
        });
     }

    function getAllContratoPagos()  {
        ajaxHelper(ContratoPagosUri + '?codigoContrato=8888888', 'GET').done(function (data) {
            self.ContratoPagos(data);
        });
    }
    // End Get Data

    // Recuperar datos iniciales
    getAllContratosVistaSP();

};

ko.applyBindings(new ViewModleContratos());