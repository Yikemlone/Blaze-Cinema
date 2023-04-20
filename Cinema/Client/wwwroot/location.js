export function load_map() {
   
    let map = L.map("map").setView([54.95212256082817, -7.7209027774341905], 13);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
    var marker = L.marker([54.95245451, -7.72099947]).addTo(map);
    var polygon = L.polygon([
        [54.95054416, -7.72262086],
        [54.95002867, -7.72192643],
        [54.94965567, -7.72246566],
        [54.95023935, -7.72327501]
    ],
        {
            color: 'green',
            fillOpacity: 0.25
        }).addTo(map);

    marker.bindPopup("<b>Blaze Cinema</b>");
    return "";
}