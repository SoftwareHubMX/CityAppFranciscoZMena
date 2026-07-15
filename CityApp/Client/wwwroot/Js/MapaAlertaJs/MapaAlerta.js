export function CargaMap(data) {
    var dataPushPin = data;
    try {
        var arrayPushPins = dataPushPin.split(" : ");

        if (arrayPushPins.count === 1) {
            arrayPushPins = data
        }
        var map = new Microsoft.Maps.Map(document.getElementById('myMap'), {
            /* No need to set credentials if already passed in URL */
            //center: new Microsoft.Maps.Location(19.9197644, -99.3980633)
        });
        var layer = new Microsoft.Maps.Layer();
        layer.clear();

        var countArray = arrayPushPins.length;

        var pushpins = [];

        for (var i = 0; i < countArray; i++) {
            var dataPushPin = arrayPushPins[i].split(", ");
            var pushpinTem = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(dataPushPin[1], dataPushPin[2]), {
                icon: dataPushPin[0],
                iconSize: { width: 40, height: 40 }
            });
            pushpins.push(pushpinTem);
        }

        var infobox = new Microsoft.Maps.Infobox(pushpins[0].getLocation(), { visible: false, autoAlignment: false });
        infobox.setMap(map);
        for (var i = 0; i < pushpins.length; i++) {
            var pushpin = pushpins[i];
            var dataPushPin = arrayPushPins[i].split(", ");

            var infoboxTemplate = '<div id="infobox" style="display: flex; flex-direction: column; background-color: #fff; border-radius: 10px; padding: 5px; width: 100%; border: 2px solid #8e8e8e;">' +
                '<b style="font-size: 10px; margin: 0 auto;">' + dataPushPin[3] + '</b>' +
                '<img src = "' + dataPushPin[0] + '" style = "width: 40%; margin: 5px auto;" />' +
                '<b style="font-size: 10px; margin: 0 auto;">' + dataPushPin[4] + '</b>' +
                '<b style="font-size: 10px; margin: 0; margin-left: auto;">' + dataPushPin[5] + '</b>' +
                '</div>';
            //Store some metadata with the pushpin
            pushpin.metadata = {
                htmlContent: infoboxTemplate
            };
            Microsoft.Maps.Events.addHandler(pushpin, 'click', function (args) {
                infobox.setOptions({
                    location: args.target.getLocation(),
                    showCloseButton: true,
                    title: "Alerta ciudadana",
                    maxHeight: 200,
                    offset: false,
                    description: args.target.metadata.htmlContent,
                    visible: true
                });
            });
        }
        layer.add(pushpins);
        map.layers.insert(layer);
    } catch (err) {
        alert("Error al tratar de cargar el mapa, compruebe su conexión a internet y recargue la pagina");
        location.reload();
    }
}