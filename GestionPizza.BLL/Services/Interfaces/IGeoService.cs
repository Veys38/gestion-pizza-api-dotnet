namespace GestionPizza.BLL.Services.Interfaces;

public interface IGeoService
{
    double CalculateDistance(double lat1, double lon1, double lat2, double lon2);

}