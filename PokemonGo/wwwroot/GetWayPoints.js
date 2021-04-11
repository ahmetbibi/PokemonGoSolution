async function getPointsAsync() {

    var gyms, exgyms, stops;

    let points;

    try {
        let response = await fetch("https://localhost:44376/api/map/");
        points = await response.json();


        gyms = points
            .filter(p => p.type == "GYM")
            .map(p => {
                return {
                    "loc": [p.latitude, p.longitude],
                    "title": p.title
                };
            });
        exgyms = points
            .filter(p => p.type == "EX GYM")
            .map(p => {
                return {
                    "loc": [p.latitude, p.longitude],
                    "title": p.title
                };
            });
        stops = points
            .filter(p => p.type == "STOP")
            .map(p => {
                return {
                    "loc": [p.latitude, p.longitude],
                    "title": p.title
                };
            });

        console.log(gyms)

    } catch (e) {
        console.log(e);
    }

    // Map opzetten
    var map = new L.Map('map',
        {
            zoom: 15,
            center: new L.latLng(gyms[0].loc),
            zoomControl: false,
            attributionControl: false
        });

    // Map baselayer
    map.addLayer(new L.TileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png'), { detectRetina: true });

    // Layer voor gezochte markers
    var markersLayer = new L.LayerGroup();


    // Layer markers type GYM
    var gymLayer = new L.LayerGroup();
    map.addLayer(gymLayer);

    // Layer markers type EX GYM
    var exgymLayer = new L.LayerGroup();
    map.addLayer(exgymLayer);

    // Layer markers type EX GYM
    var stopLayer = new L.LayerGroup();
    map.addLayer(stopLayer);

    var controlSearch = new L.Control.Search({
        position: 'topleft',
        layer: markersLayer,
        initial: false,
        zoom: 17,
        marker: false
    });

    var gym = L.icon(
        {
            iconUrl: 'images/gym.png',
            iconSize: [20, 20],
            iconAnchor: [10, 10],
            popupAnchor: [0, 0]
        });

    var gymEX = L.icon(
        {
            iconUrl: 'images/gymex.png',
            iconSize: [20, 20],
            iconAnchor: [10, 10],
            popupAnchor: [0, 0]
        });

    var stop = L.icon(
        {
            iconUrl: 'images/stop.png',
            iconSize: [20, 20],
            iconAnchor: [10, 10],
            popupAnchor: [0, 0]
        });

    map.addControl(controlSearch);
    controlSearch.on('search:locationfound', function (event) {
        event.layer.openPopup();
    });


    for (i in gyms) {
        var title = gyms[i].title,	//value searched
            loc = gyms[i].loc,		//position found
            marker = new L.Marker(new L.latLng(loc), { icon: gym, title: title });//se property searched
        marker.bindPopup(title + "<br> <a href='https://www.google.com/maps/search/?api=1&query=" + gyms[i].loc + "' target='_blank'>Navigate</a>");
        gymLayer.addLayer(marker);
        markersLayer.addLayer(marker);

    }
    for (i in exgyms) {
        var title = exgyms[i].title,	//value searched
            loc = exgyms[i].loc,		//position found
            marker = new L.Marker(new L.latLng(loc), { icon: gymEX, title: title });//se property searched
        marker.bindPopup(title + "<br> <a href='https://www.google.com/maps/search/?api=1&query=" + exgyms[i].loc + "' target='_blank'>Navigate</a>");
        exgymLayer.addLayer(marker);
        markersLayer.addLayer(marker);
    }
    for (i in stops) {
        var title = stops[i].title,	//value searched
            loc = stops[i].loc,		//position found
            marker = new L.Marker(new L.latLng(loc), { icon: stop, title: title });//se property searched
        marker.bindPopup(title + "<br> <a href='https://www.google.com/maps/search/?api=1&query=" + stops[i].loc + "' target='_blank'>Navigate</a>");
        stopLayer.addLayer(marker);
        markersLayer.addLayer(marker);
    }

    // Waypoints plaatsen in zoekfunctie op basis van actieve layers
    $(".leaflet-right").click(function () {

        controlSearch.autoCollapse = true;
        var gymActive = map.hasLayer(gymLayer);
        var exgymActive = map.hasLayer(exgymLayer);
        var stopActive = map.hasLayer(stopLayer);

        markersLayer.clearLayers();
        gymLayer.clearLayers();
        exgymLayer.clearLayers();
        stopLayer.clearLayers();

        if (gymActive == true) {

            for (i in gyms) {
                var title = gyms[i].title,	//value searched
                    loc = gyms[i].loc,		//position found
                    marker = new L.Marker(new L.latLng(loc), { icon: gym, title: title });//se property searched
                marker.bindPopup(title + "<br> <a href='https://www.google.com/maps/search/?api=1&query=" + gyms[i].loc + "' target='_blank'>Navigate</a>");
                gymLayer.addLayer(marker);
                markersLayer.addLayer(marker);
            }
        }
        if (exgymActive == true) {
            for (i in exgyms) {
                var title = exgyms[i].title,	//value searched
                    loc = exgyms[i].loc,		//position found
                    marker = new L.Marker(new L.latLng(loc), { icon: gymEX, title: title });//se property searched
                marker.bindPopup(title + "<br> <a href='https://www.google.com/maps/search/?api=1&query=" + exgyms[i].loc + "' target='_blank'>Navigate</a>");
                exgymLayer.addLayer(marker);
                markersLayer.addLayer(marker);
            }
        }
        if (stopActive == true) {
            for (i in stops) {
                var title = stops[i].title,	//value searched
                    loc = stops[i].loc,		//position found
                    marker = new L.Marker(new L.latLng(loc), { icon: stop, title: title });//se property searched
                marker.bindPopup(title + "<br> <a href='https://www.google.com/maps/search/?api=1&query=" + stops[i].loc + "' target='_blank'>Navigate</a>");
                stopLayer.addLayer(marker);
                markersLayer.addLayer(marker);
            }
        }


    });

    var overlays =
    {
        "<img src='images/gym.png' height='20px'>&nbsp;Gyms": gymLayer,
        "<img src='images/gymex.png' height='20px'>&nbsp;EX gyms": exgymLayer,
        "<img src='images/stop.png' height='20px'>&nbsp;Pokéstops": stopLayer
    };

    var layercontrol = L.control.layers(null, overlays, { collapsed: false }, { position: 'bottomleft' }).addTo(map);

    lc = L.control.locate({
        strings:
        {
            title: "Show your position on map."
        }
    }).addTo(map);

    console.log("----------------------------------------");
    console.log("Statistics:")
    console.log("----------------------------------------");
    console.log("Amount of pokéstops: " + stops.length);
    console.log("Amount of gyms: " + gyms.length);
    console.log("Amount of EX gyms: " + exgyms.length);
    console.log("----------------------------------------");
}

getPointsAsync();