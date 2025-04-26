using GestionPizza.BLL.Models;
using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.BLL.Utils;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;



namespace GestionPizza.BLL.Services;

public class PizzeriaService : IPizzeriaService
{
    private readonly IPizzeriaRepository _pizzeriaRepository;
    private readonly IGeocodingService _geocodingService;
    private readonly IGeoService _geoService;



    public PizzeriaService(IPizzeriaRepository pizzeriaRepository,IGeocodingService geocodingService, IGeoService geoService)
    {
        _pizzeriaRepository = pizzeriaRepository;
        _geocodingService = geocodingService;
        _geoService = geoService;

    }

    public IEnumerable<Pizzeria> FindAll()
    {
        return _pizzeriaRepository.FindMany();
    }

    public Pizzeria FindById(Guid id)
    {
        var pizzeria = _pizzeriaRepository.FindOne(id);
        if (pizzeria == null)
            throw new Exception($"Pizzeria with id {id} not found");
        return pizzeria;
    }

    
    
    
    public async Task<Pizzeria> Save(Pizzeria pizzeria)
    {
        var (lat, lon) = await _geocodingService.GetCoordinatesFromAddressAsync(pizzeria.Address);
        pizzeria.Latitude = lat;
        pizzeria.Longitude = lon;
        return _pizzeriaRepository.Save(pizzeria);
    }



    
    
    
    
    public void Update(Guid id, Pizzeria updated)
    {
        var existing = _pizzeriaRepository.FindOne(id);
        if (existing == null)
            throw new Exception($"Pizzeria with id {id} not found");

        existing.Name = updated.Name;
        existing.Address = updated.Address;

        _pizzeriaRepository.Update(existing);
    }

    public void Delete(Guid id)
    {
        var pizzeria = _pizzeriaRepository.FindOne(id);
        if (pizzeria == null)
            throw new Exception($"Pizzeria with id {id} not found");

        _pizzeriaRepository.Delete(pizzeria);
    }
    
    public List<PizzeriaWithDistance> GetAllWithDistance(double userLat, double userLon)
    {
        var pizzerias = _pizzeriaRepository.FindMany()
            .Where(p => p.Latitude.HasValue && p.Longitude.HasValue)
            .Select(p => new PizzeriaWithDistance
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                Latitude = p.Latitude.Value,
                Longitude = p.Longitude.Value,
                DistanceKm = _geoService.CalculateDistance(userLat, userLon, p.Latitude.Value, p.Longitude.Value)
            })
            .OrderBy(p => p.DistanceKm) // facultatif : tri par distance
            .ToList();

        return pizzerias;
    }

}