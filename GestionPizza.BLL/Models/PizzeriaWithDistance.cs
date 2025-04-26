namespace GestionPizza.BLL.Models;

public class PizzeriaWithDistance
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double DistanceKm { get; set; }
}