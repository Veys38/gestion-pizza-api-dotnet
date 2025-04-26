using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GestionPizza.BLL.Services.Interfaces;

namespace GestionPizza.BLL.Utils;

public class GeocodingService : IGeocodingService
{
    private readonly HttpClient _httpClient;

    public GeocodingService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ProjetPizza/1.0"); // requis par Nominatim
    }

    public async Task<(double Latitude, double Longitude)> GetCoordinatesFromAddressAsync(string address)
    {
        var encodedAddress = Uri.EscapeDataString(address);
        var url = $"https://nominatim.openstreetmap.org/search?format=json&q={encodedAddress}";

        var response = await _httpClient.GetStringAsync(url);
        var json = JsonDocument.Parse(response);
        var firstResult = json.RootElement.EnumerateArray().FirstOrDefault();

        if (firstResult.ValueKind == JsonValueKind.Undefined)
            throw new Exception("Adresse non trouvée.");

        var lat = double.Parse(firstResult.GetProperty("lat").GetString(), CultureInfo.InvariantCulture);
        var lon = double.Parse(firstResult.GetProperty("lon").GetString(), CultureInfo.InvariantCulture);

        return (lat, lon);
    }

    private class NominatimResult
    {
        public string lat { get; set; }
        public string lon { get; set; }
    }
}