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
    self.vencimiento = ko.observableArray();
    self.selectedVencimiento = ko.observable();

    var host = '200.6.245.76:8095';//document.location.host;

    ////http://192.168.16.13:8095/api/DetalleVisitas?CodigoVisita=9
     

    var visitasUri = 'http://'.concat(host, '/api/Publicidad/ZonasMapa');
    var ProyectosUbicacionesUri = 'http://'.concat(host, '/api/Publicidad/ProyectosZonasMapa');
    var VistaSuperversionUri = 'http://'.concat(host, '/api/Visitas/VistaSuperversion?codigoZona=');
    var VistaSuperversionDetalleUri = 'http://'.concat(host, '/api/Visitas/VistaSupervisionDetalle');
    var VistamapaContrato = 'http://'.concat(host, '/api/Visitas/VistaContratos'); //'Visitas/VistaContratos?codigozona=8'

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
    function getAllVisitas(codigozona, VencimientoTarea) {
     
        ajaxHelper(VistaSuperversionDetalleUri + '?codigozona=' + codigozona + '&vencimientoTarea=' + VencimientoTarea, 'GET').done(function (data) {
            
            //alert("Visita" + VistaSuperversionDetalleUri + '?codigozona=' + VencimientoTarea + '&vencimientoTarea=' + codigozona);
            self.visitasDetalle(data);
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: parseFloat(self.visitasDetalle()[0].Latitud), lng: parseFloat(self.visitasDetalle()[0].Longitud) },
                scrollwheel: false,
                zoom: 10
            });
          //  alert(self.visitasDetalle().length);
                
        

            for (i = 0; i < self.visitasDetalle().length; i++)

             

            {
             
                if (self.visitasDetalle()[i].VencimientoTarea == 'ACTIVO') {
                    var marker = new google.maps.Marker({
                        position: { lat: parseFloat(self.visitasDetalle()[i].Latitud), lng: parseFloat(self.visitasDetalle()[i].Longitud) },
                        map: map,
                        //icon: "/Content/AdminLTE/img/Location-32.png",
                        //icon: "/Content/AdminLTE/img/Location_delete-32.png",
                        icon: "/Content/AdminLTE/img/GEOACTIVO.png",
                        title: self.visitasDetalle()[i].DescripcionPublicidad
                    });
                }

                if (self.visitasDetalle()[i].VencimientoTarea == 'POR VENCER') {
                    var marker = new google.maps.Marker({
                        position: { lat: parseFloat(self.visitasDetalle()[i].Latitud), lng: parseFloat(self.visitasDetalle()[i].Longitud) },
                        map: map,
                        icon: "/Content/AdminLTE/img/GEOPORVENCER.png",
                        //icon: "/Content/AdminLTE/img/Location_delete-32.png",
                        //icon: "/Content/AdminLTE/img/OK-32.png",
                        title: self.visitasDetalle()[i].DescripcionPublicidad
                    });
                }

                if (self.visitasDetalle()[i].VencimientoTarea == 'VENCIDO') {
                    var marker = new google.maps.Marker({
                        position: { lat: parseFloat(self.visitasDetalle()[i].Latitud), lng: parseFloat(self.visitasDetalle()[i].Longitud) },
                        map: map,
                        //icon: "/Content/AdminLTE/img/Location-32.png",
                        icon: "/Content/AdminLTE/img/GEVENDIDO1.png",
                        //icon: "/Content/AdminLTE/img/OK-32.png",
                        title: self.visitasDetalle()[i].DescripcionPublicidad
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

    ///evento Zona_id combobox
    self.selectedProject.subscribe(function(data) {
        //alert(ko.toJSON({ selectedProject: self.selectedProject() }));
        //alert(self.selectedProject())
        getVencimiento(self.selectedProject());
        
    });

    self.selectedVencimiento.subscribe(function (data) {
        //alert(ko.toJSON({ selectedProject: self.selectedProject() }));     
        //alert(self.selectedProject());
        //alert(self.selectedVencimiento());
        ////getVencimiento(self.selectedProject());
        getAllVisitas(self.selectedProject(), self.selectedVencimiento());
    });

 

    function getVencimiento(item) {
        ajaxHelper(VistaSuperversionUri + item, 'GET').done(function (data) {
           // alert(VistaSuperversionUri + item);
            self.vencimiento(data);
           
        });
    }
    
    // Recuperar datos iniciales
    //getAllVisitas();
    getAllProyectosUbicaciones();
};

ko.applyBindings(new ViewModelVisitasDetalle());