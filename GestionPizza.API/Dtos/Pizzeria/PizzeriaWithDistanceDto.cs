namespace GestionPizza.Dtos.Pizzeria;

public class PizzeriaWithDistanceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int DistanceKm { get; set; }
}