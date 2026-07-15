window.mapInstance = null;

export function CargaMap(data) {
    try {
        // Resetear el mapa si ya existe
        if (window.mapInstance) {
            window.mapInstance.remove();
        }

        // Crear el mapa
        window.mapInstance = L.map('myMap').setView([17.5999529, -99.1967888], 13);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(window.mapInstance);

        const arrayPushPins = data.split(" : ");

        arrayPushPins.forEach(item => {
            const dataPushPin = item.split(", ");
            if (dataPushPin.length < 7) return;

            const icono = dataPushPin[0];
            const lat = parseFloat(dataPushPin[1]);
            const lng = parseFloat(dataPushPin[2]);
            const tipo = dataPushPin[3];
            const versiones = dataPushPin[4];
            const fecha = dataPushPin[5];
            const imagenBase64 = dataPushPin[6];

            // Crear ícono personalizado
            const customIcon = L.icon({
                iconUrl: icono,
                iconSize: [40, 40],
                iconAnchor: [20, 40],
                popupAnchor: [0, -40]
            });

            // Crear contenido del popup (infobox)
            const html = `
                <div style="display: flex; flex-direction: column; background-color: #fff; border-radius: 10px; padding: 5px; width: 100%; border: 2px solid #8e8e8e;">
                    <b style="font-size: 15px; margin: 5px auto; color: #000;">${tipo}</b>
                    <img src="data:image/png;base64, ${imagenBase64}" style="width: 70%; margin: 5px auto;" />
                    <div style="display: flex;">
                        <b style="font-size: 10px; margin: 0; margin-right: auto;">${versiones}</b>
                        <b style="font-size: 10px; margin: 0; margin-left: auto;">${fecha}</b>
                    </div>
                </div>
            `;

            // Agregar marcador al mapa
            L.marker([lat, lng], { icon: customIcon })
                .addTo(window.mapInstance)
                .bindPopup(html);
        });
    } catch (err) {
        alert("Error al tratar de cargar el mapa, compruebe su conexión a internet y recargue la página.");
        location.reload();
    }
}

//export function CargaMap(data) {
//    var dataPushPin = data;
//    try {
//        var arrayPushPins = dataPushPin.split(" : ");

//        if (arrayPushPins.count === 1) {
//            arrayPushPins = data
//        }
//        var map = new Microsoft.Maps.Map(document.getElementById('myMap'), {
//            /* No need to set credentials if already passed in URL */
//            center: new Microsoft.Maps.Location(17.5999529, -99.1967888)
//        });
//        var layer = new Microsoft.Maps.Layer();
//        layer.clear();

//        var countArray = arrayPushPins.length;

//        var pushpins = [];

//        for (var i = 0; i < countArray; i++) {
//            var dataPushPin = arrayPushPins[i].split(", ");
//            var pushpinTem = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(dataPushPin[1], dataPushPin[2]), {
//                icon: dataPushPin[0],
//                iconSize: { width: 40, height: 40 }
//            });
//            pushpins.push(pushpinTem);
//        }

//        var infobox = new Microsoft.Maps.Infobox(pushpins[0].getLocation(), { visible: false, autoAlignment: false });
//        infobox.setMap(map);
//        for (var i = 0; i < pushpins.length; i++) {
//            var pushpin = pushpins[i];
//            var dataPushPin = arrayPushPins[i].split(", ");

//            var infoboxTemplate = '<div id="infobox" style="display: flex; flex-direction: column; background-color: #fff; border-radius: 10px; padding: 5px; width: 100%; border: 2px solid #8e8e8e;">' +
//                '<b style="font-size: 15px; margin: 5px auto; color: #000;">' + dataPushPin[3] + '</b>' +
//                '<img src = "data:image/png;base64, ' + dataPushPin[6] + '" style = "width: 70%; margin: 5px auto;" />' +
//                '<div style="display: flex;">' +
//                '<b style="font-size: 10px; margin: 0; margin-right: auto;">' + dataPushPin[4] + '</b>' +
//                '<b style="font-size: 10px; margin: 0; margin-left: auto;">' + dataPushPin[5] + '</b>' +
//                '</div >' +
//                '</div>';
//            //Store some metadata with the pushpin
//            pushpin.metadata = {
//                htmlContent: infoboxTemplate
//            };
//            Microsoft.Maps.Events.addHandler(pushpin, 'click', function (args) {
//                infobox.setOptions({
//                    location: args.target.getLocation(),
//                    showCloseButton: true,
//                    maxHeight: 300,
//                    offset: false,
//                    description: args.target.metadata.htmlContent,
//                    visible: true
//                });
//            });
//        }
//        layer.add(pushpins);
//        map.layers.insert(layer);
//    //map.entities.push(pushpins);
//    } catch (err) {
//        alert("Error al tratar de cargar el mapa, compruebe su conexión a internet y recargue la pagina");
//        location.reload();
//    }

//}


/*{
            icon: dataPushPin[0],
            anchor: new Microsoft.Maps.Point(12, 39)
        }*/