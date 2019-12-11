// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Initialize and add the map
function initMap() {
    var uluru = { lat: 44.412255, lng: -79.668131 };
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 9, center: uluru });
    var marker = new google.maps.Marker({ position: uluru, map: map });
}

