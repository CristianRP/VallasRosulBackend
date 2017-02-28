var Marker = function (name, lat, long, parent) {
    var self = this;

    self.name = name;
    self.lat = ko.observable(lat);
    self.long = ko.observable(long);
    self.isDraggable = ko.observable(false);
    self.isSelected = ko.observable(false);
    self.isSelected.subscribe(function (value) {
        if (value) {
            self.marker_point.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png');
        } else {
            self.marker_point.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png');
        }
        self.marker_point.map.setCenter(self.marker_point.position);
    });

    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(lat, long),
        title: name,
        map: map,
        draggable: this.isDraggable()
    });

    self.marker_point = marker;

    self.toggle = function (data, event) {
        if (parent.selectedPoint) {
            parent.selectedPoint.isSelected(false);
        }
        parent.selectedPoint = self;
        self.isSelected(!self.isSelected());
    };

    self.clicked = function (data, event) {
        var $tr = $(event.target).parent();
        var $tbody = $tr.parent();
        $tbody.find('tr').removeClass('row-highligth');
        $tr.addClass('row-highligth');
        self.marker_point.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png');
        self.marker_point.map.setCenter(self.marker_point.position);
    };

    self.unhovered = function (data, event) {
        var $tr = $(event.target).parent();
        $tr.removeClass('hover');
        this.marker_point.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png');
    };

    google.maps.event.addListener(marker, 'click', function () {
        self.toggle();
    }.bind(self));

    google.maps.event.addListener(marker, 'mouseover', function () { }.bind(self));
}

var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 14,
    center: new google.maps.LatLng(25.6650267, -100.3539392),
    mapTypeId: google.maps.MapTypeId.ROADMAP
});

var DataTableMap = function () {
    var self = this;

    self.selectedPoint = null;

    self.points = ko.observableArray([
    new Marker('RichMarker  1', 25.6693267, -100.3560392, self),
    new Marker('RichMarker  2', 25.6653267, -100.3511392, self),
    new Marker('RichMarker  3', 25.6633267, -100.3532392, self),
    new Marker('RichMarker  4', 25.6643267, -100.3483392, self)]);

    self.lowlight = function () { };

    self.highligth = function (rowId) {
        ko.utils.arrayForEach(self.points(), function (point) {
        });
    };
};

ko.applyBindings(new DataTableMap());