var ViewModelVisitasDetalle = function () {
    var self = this;
    self.visitasDetalle = ko.observableArray();
    self.ProyectosUbicaciones = ko.observableArray();
    self.error = ko.observable();
    self.visitaDetail = ko.observable();
    self.imagenR = ko.observable();
    self.Latitud = ko.observableArray();
    self.Longitud = ko.observableArray();
    self.selectedProject = ko.observable();

    var host = '200.6.245.76:8095';//document.location.host;

    ////http://192.168.16.13:8095/api/DetalleVisitas?CodigoVisita=9

    var visitasUri = 'http://'.concat(host, '/api/Publicidad/ZonasMapa');
    var ProyectosUbicacionesUri = 'http://'.concat(host, '/api/Publicidad/ProyectosZonasMapa');
    
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
    function getAllVisitas(codigoProyecto) {
        var url = window.location;
        var id = url.toString().split("=");
       
        //ajaxHelper(visitasUri + '?CodigoVisita=' + id[1], 'GET').done(function (data) {
        ajaxHelper(visitasUri + '?codigoProyecto=' + codigoProyecto, 'GET').done(function (data) {
            self.visitasDetalle(data);
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: parseFloat(self.visitasDetalle()[0].Latitud), lng: parseFloat(self.visitasDetalle()[0].Longitud) },
                scrollwheel: false,
                zoom: 10
            });
            for (i = 0; i < self.visitasDetalle().length; i++) {
              
              //  alert(self.visitasDetalle()[i].Valla);
                if (self.visitasDetalle()[i].Valla.toString() == "Si        ") {
                   // alert("entro");
                    var marker = new google.maps.Marker({
                        position: { lat: parseFloat(self.visitasDetalle()[i].Latitud), lng: parseFloat(self.visitasDetalle()[i].Longitud) },
                        map: map,
                        //icon: "/Content/AdminLTE/img/Location-32.png",
                        //icon: "/Content/AdminLTE/img/Location_delete-32.png",
                        icon: "/Content/AdminLTE/img/user-17-48.png",
                        title: self.visitasDetalle()[i].Ancho
                       });
                }

                if (self.visitasDetalle()[i].Valla.toString() == "No        ") {
                   // alert("entro");
                    var marker = new google.maps.Marker({
                        position: { lat: parseFloat(self.visitasDetalle()[i].Latitud), lng: parseFloat(self.visitasDetalle()[i].Longitud) },
                        map: map,
                        //icon: "/Content/AdminLTE/img/Location-32.png",
                        icon: "/Content/AdminLTE/img/green_flag-48.png",
                        //icon: "/Content/AdminLTE/img/GEOACTIVO.png",
                        title: self.visitasDetalle()[i].Ancho
                    });
                }
               
            }
        });
    }
    // End Get Data
 
    ///self.contratos el objeto del grid 
    function getAllProyectosUbicaciones(item) {
        //ajaxHelper(ContratoPagosUri + '?codigoContrato=' + item.CodigoContrato, 'GET').done(function (data) {
        ajaxHelper(ProyectosUbicacionesUri , 'GET').done(function (data) {
            self.ProyectosUbicaciones(data);
        });
    }

    self.selectedProject.subscribe(function(data) {
        //alert(ko.toJSON({ selectedProject: self.selectedProject() }));
        //alert(self.selectedProject())
        getAllVisitas(self.selectedProject());
    });

    
    // Recuperar datos iniciales
    //getAllVisitas();
    getAllProyectosUbicaciones();
};

ko.applyBindings(new ViewModelVisitasDetalle());