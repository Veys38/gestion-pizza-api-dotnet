namespace GestionPizza.BLL.Services.Interfaces;

public interface IGeocodingService
{
        Task<(double Latitude, double Longitude)> GetCoordinatesFromAddressAsync(string address);
}