using GestionPizza.BLL.Services.Interfaces;

namespace GestionPizza.BLL.Services;

public class GeoService :IGeoService
{
    private const double EarthRadiusKm = 6371.0;

    public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        double dLat = DegreesToRadians(lat2 - lat1);
        double dLon = DegreesToRadians(lon2 - lon1);

        double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                   Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                   Math.Pow(Math.Sin(dLon / 2), 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return EarthRadiusKm * c;
    }

    private double DegreesToRadians(double deg)
    {
        return deg * Math.PI / 180.0;
    }
}