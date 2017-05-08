var ViewModelDetallePublicidad = function () {

    var self = this;
    self.error = ko.observable();
    self.publicidades = ko.observableArray();
    self.imagenR = ko.observable();
    self.Latitud = ko.observable();
    self.Longitud = ko.observable();

    var host = '200.6.245.76:8095';

    var vallasDetailUri = 'http://'.concat(host, '/api/BackOffice/PublicidadDetail?');

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

    function getAllVisitas() {
        var url = window.location;
        var id = url.toString().split("=");
        //alert(id[1]);
        ajaxHelper(vallasDetailUri + 'codigoPublicidad=' + id[1], 'GET').done(function (data) {
            self.publicidades(data);
            //alert(JSON.stringify(ko.toJS(self.publicidades()[0].Latitud)));
            var item = self.publicidades()[0];
            self.Latitud(self.publicidades()[0].Latitud);
            self.Longitud(self.publicidades()[0].Longitud);
            var latLng = new google.maps.LatLng(parseFloat(self.Latitud()), parseFloat(self.Longitud()));
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: parseFloat(self.Latitud()), lng: parseFloat(self.Longitud()) },
                scrollwheel: false,
                zoom: 16
            });
            var marker = new google.maps.Marker({
                position: { lat: parseFloat(self.Latitud()), lng: parseFloat(self.Longitud()) },
                map: map,
                title: self.publicidades()[0].Descripcion
            });
            var coordInfoWindow = new google.maps.InfoWindow();
            coordInfoWindow.setContent(createInfoWindowContent(latLng, map.getZoom()));
            coordInfoWindow.setPosition(latLng);
            coordInfoWindow.open(map);

            map.addListener('zoom_changed', function () {
                coordInfoWindow.setContent(createInfoWindowContent(latLng, map.getZoom()));
                coordInfoWindow.open(map);
            });
            var TILE_SIZE = 256;

            function createInfoWindowContent(latLng, zoom) {
                var scale = 1 << zoom;

                var worldCoordinate = project(latLng);

                var pixelCoordinate = new google.maps.Point(
                    Math.floor(worldCoordinate.x * scale),
                    Math.floor(worldCoordinate.y * scale));

                var tileCoordinate = new google.maps.Point(
                    Math.floor(worldCoordinate.x * scale / TILE_SIZE),
                    Math.floor(worldCoordinate.y * scale / TILE_SIZE));

                return [
                  '<b>Descripción de valla:</b> ' + item.Descripcion,
                  '<b>Descripción contrato:</b> ' + '<br>' + item.DescripcionContrato,
                  '<b>Dirección: </b>' + item.Direccion,
                  '<b>Codigo de busqueda: </b>' + item.CodigoBusqueda,
                  '<b>Periodo: </b>' + item.Calendario_Periodo
                ].join('<br>');

                function project(latLng) {
                    var siny = Math.sin(latLng.lat() * Math.PI / 180);

                    // Truncating to 0.9999 effectively limits latitude to 89.189. This is
                    // about a third of a tile past the edge of the world tile.
                    siny = Math.min(Math.max(siny, -0.9999), 0.9999);

                    return new google.maps.Point(
                        TILE_SIZE * (0.5 + latLng.lng() / 360),
                        TILE_SIZE * (0.5 - Math.log((1 + siny) / (1 - siny)) / (4 * Math.PI)));
                }
            }
        });
    }

    getAllVisitas();

};

ko.applyBindings(new ViewModelDetallePublicidad());