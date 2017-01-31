var map;
function initMap() {
    //Creamos el objeto mapa. Le pasamos al constructor el elemento html en el que queremos que se establezca 
    //nuestro mapa.
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -42.026651, lng: 4.538598 },
        zoom: 16
    });

    //Creamos una ventana de informacion
    var infoWindow = new google.maps.InfoWindow({ map: map });
    
    //Try geolocalizacion html5

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            infoWindow.setPosition(pos);
            infoWindow.setContent("Te encontre!!!");
            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
    //No tenemos geolocalizacion
        handleLocationError(false, infoWindow, map.getCenter());
    }
}


//Controlamos los errorres que nos pueda dar.
function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        "Error: Fallo el servicio de geoloc." :
        "Tu navegador no soporta geoloc");
}