var ViewModleContratos = function () {
    var self = this;
    self.ContratosVistaSP = ko.observableArray();
    self.ContratoPagos = ko.observableArray();
    self.error = ko.observable();
    self.visitaDetail = ko.observable();
    self.ListadoVallas = ko.observableArray();
    self.PagosPublicidad = ko.observableArray();
    self.idPublicidad = ko.observable();

    var host = '200.6.245.76:8095';//document.location.host;
   
    var ContratosVistaSPUri = 'http://'.concat(host, '/api/CrudContratos/Contrato');
    var ContratoPagosUri = 'http://'.concat(host, '/api/CrudContratos/ContratoPago');
    var PagosUri = 'http://'.concat(host, '/api/CrudContratos/ContratoPagos');
    var PagosUpdateUri = 'http://'.concat(host, '/api/CrudContratos/UpdateContratoPagos');
    var ListadoVallasUri = 'http://'.concat(host, '/api/BackOffice/PublicidadContrato');
    var PagosPublicidadUri = 'http://'.concat(host, '/api/BackOffice/PublicidadPagos');
                                                  
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
        NoFactura: ko.observable(null),
        Estado: ko.observable(null)
    }

    ////INSERTA PAGO

    self.contratoCodigo = {
        CodigoContrato: ko.observable()
    }

    self.setContratoCodigo = function (item) {
        self.contratoCodigo.CodigoContrato(item.CodigoPublicidad);
    }

    self.addEvento = function (form,item)  {
        
        var e = {
            CodigoContrato: self.contratoCodigo.CodigoContrato(), ////observable
            Fecha: self.newEvento.Fecha(),
            Monto: self.newEvento.Monto(),
            Pagado: self.newEvento.Pagado(),
            NoFactura: self.newEvento.NoFactura(),
            Estado: self.newEvento.Estado()
        }
        ajaxHelper(PagosUri + '?codigoPublicidad=' + e.CodigoContrato + '&fecha=' + e.Fecha + '&monto=' + e.Monto + '&pagado=' + e.Pagado + '&noFactura=' + e.NoFactura + '&estado=' + e.Estado, 'POST').done(function (item) {
        
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
        id: ko.observable(),
        Fecha: ko.observable(),
        Monto: ko.observable(),
        Pagado: ko.observable(),
        NoFactura: ko.observable(),
        Estado: ko.observable()
    }

    //SELECCIONAR EVENTO
    self.selectEvent = function (item) {

        self.selectedEvent.id(item.id);
        self.selectedEvent.Fecha(item.Fecha);
        self.selectedEvent.Monto(item.Monto);
        self.selectedEvent.Pagado(item.Pagado);
        self.selectedEvent.NoFactura(item.NoFactura);
        self.selectedEvent.Estado(item.Estado);
        
    }
    //EDITAR EVENTO;
    self.updateEvent = function () {
        
        var e = {
               id: self.selectedEvent.id(),
               Fecha: self.selectedEvent.Fecha(),
               Monto: self.selectedEvent.Monto(),
               NoFactura: self.selectedEvent.NoFactura(),
               Pagado: self.selectedEvent.Pagado(),
               Estado: self.selectedEvent.Estado()
            //CategoriaId: self.selectedEvent.Categoria().Id
        }
        //alert(e.Fecha.split('T')[0] + ' ' + e.NoFactura);
        //ajaxHelper(EventosUri + self.selectedEvent.Id, 'PUT', e).done(function (data) {
        ajaxHelper(PagosUpdateUri + '?fecha=' + e.Fecha.split('T')[0] + '&monto=' + e.Monto + '&pagado=' + e.Pagado + '&noFactura=' + e.NoFactura + '&codigoPago=' + e.id + '', 'POST').done(function (item) {
            ajaxHelper(PagosPublicidadUri + '?codigoPublicidad=' + self.idPublicidad(), 'GET').done(function (data) {
                self.PagosPublicidad(data);
            });
        }).fail(function (item) {
            ajaxHelper(PagosPublicidadUri + '?codigoPublicidad=' + self.idPublicidad(), 'GET').done(function (data) {
                self.PagosPublicidad(data);
            });
        });

        
        
        $("#editarEvento").modal('hide');
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

    self.getListadoVallas = function (item) {
        ajaxHelper(ListadoVallasUri + '?codigoContrato=' + item.CodigoContrato, 'GET').done(function (data) {
            self.ListadoVallas(data);
        });
    }

    self.getPagosPublicidad = function (item) {
        self.idPublicidad(item.CodigoPublicidad);
        ajaxHelper(PagosPublicidadUri + '?codigoPublicidad=' + item.CodigoPublicidad, 'GET').done(function (data) {
            self.PagosPublicidad(data);
        });
    }
    // End Get Data

    // Recuperar datos iniciales
    getAllContratosVistaSP();

};

ko.applyBindings(new ViewModleContratos());