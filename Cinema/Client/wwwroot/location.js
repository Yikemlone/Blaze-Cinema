export function load_map()
{
    let map = L.map("map").setView([54.95212256082817, -7.7209027774341905], 17);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
    var marker = L.marker([54.95245451, -7.72099947]).addTo(map);

    marker.bindPopup("<b>Blaze Cinema</b><br><b>Port Road</b><br><b>Letterkenny</b><br><b>Co.Donegal</b><br><b>F92 FC93</b>");
    return "";
}
