using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services;

public class PizzeriaService : IPizzeriaService
{
    private readonly IPizzeriaRepository _pizzeriaRepository;

    public PizzeriaService(IPizzeriaRepository pizzeriaRepository)
    {
        _pizzeriaRepository = pizzeriaRepository;
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

    public Pizzeria Save(Pizzeria pizzeria)
    {
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
}