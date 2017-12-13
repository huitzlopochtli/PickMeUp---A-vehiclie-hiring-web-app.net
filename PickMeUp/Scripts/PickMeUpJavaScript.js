<script src="https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyCiBz3TAUhgB2cXAZBztFNLZy593SpJLOk"></script>

google.maps.event.addDomListener(window, 'load', function () {
    var places = new google.maps.places.Autocomplete(document.getElementById('txtSource'));
    places = new google.maps.places.Autocomplete(document.getElementById('txtDestination'));
    google.maps.event.addListener(places, 'place_changed', function () {
        var place = places.getPlace();
        var address = place.formatted_address;
        var latitude = place.geometry.location.lat();
        var longitude = place.geometry.location.lng();
        var mesg = "Address: " + address;
        mesg += "\nLatitude: " + latitude;
        mesg += "\nLongitude: " + longitude;
        //alert(mesg);
    });
});

var source, destination;
var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
google.maps.event.addDomListener(window, 'load', function () {
    new google.maps.places.SearchBox(document.getElementById('txtSource'));
    new google.maps.places.SearchBox(document.getElementById('txtDestination'));
    directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });
});

function GetRoute() {
    document.getElementById('StartLocation').value = document.getElementById("txtSource").value;
    document.getElementById('startLocation').innerHTML = document.getElementById("txtSource").value;

    document.getElementById('EndLocation').value = document.getElementById("txtDestination").value;
    document.getElementById('endLocation').innerHTML = document.getElementById("txtDestination").value;


    var dhaka = new google.maps.LatLng(23.794887, 90.402476);
    var mapOptions = {
        zoom: 13,
        center: dhaka
    };
    map = new google.maps.Map(document.getElementById('dvMap'), mapOptions);
    directionsDisplay.setMap(map);
    directionsDisplay.setPanel(document.getElementById('dvPanel'));

    //*********DIRECTIONS AND ROUTE**********************//
    source = document.getElementById("txtSource").value;
    destination = document.getElementById("txtDestination").value;

    var request = {
        origin: source,
        destination: destination,
        travelMode: google.maps.TravelMode.DRIVING
    };
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
        }
    });

    //*********DISTANCE AND DURATION**********************//
    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix({
        origins: [source],
        destinations: [destination],
        travelMode: google.maps.TravelMode.DRIVING,
        unitSystem: google.maps.UnitSystem.METRIC,
        avoidHighways: false,
        avoidTolls: false
    }, function (response, status) {
        if (status == google.maps.DistanceMatrixStatus.OK && response.rows[0].elements[0].status != "ZERO_RESULTS") {
            var distance = response.rows[0].elements[0].distance.text;

            var duration = response.rows[0].elements[0].duration.text;
            var Distance = document.getElementById("distance");
            Distance.innerHTML = "";
            Distance.innerHTML += "Distance: " + distance + "<br />";
            Distance.innerHTML += "Duration:" + duration;
            //document.getElementById('Expense').value = document.getElementById('Distance') * document.getElementById('FareRate');
            //document.getElementById('expense').innerHTML = distance * document.getElementById('FareRate').value;

            document.getElementById('Distance').value = parseFloat(distance);

        } else {
            alert("Unable to find the distance via road.");
        }
    });
}
