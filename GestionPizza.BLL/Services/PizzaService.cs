using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;

    public PizzaService(IPizzaRepository pizzaRepository)
    {
        _pizzaRepository = pizzaRepository;
    }

    public IEnumerable<Pizza> FindAll()
    {
        return _pizzaRepository.FindMany();
    }

    public Pizza FindById(Guid id)
    {
        Pizza? pizza = _pizzaRepository.FindOne(id);
        if (pizza == null)
        {
            throw new Exception($"Pizza with id {id} doesn't exist");
        }

        return pizza;
    }

    public Pizza Save(Pizza pizza)
    {
        if (_pizzaRepository.Any(p => p.PizzaName == pizza.PizzaName))
        {
            throw new Exception($"Pizza with name '{pizza.PizzaName}' already exists");
        }

        return _pizzaRepository.Save(pizza);
    }

    public void Update(Guid id, Pizza pizza)
    {
        Pizza? existingPizza = _pizzaRepository.FindOne(id);
        if (existingPizza == null)
        {
            throw new Exception($"Pizza with id {id} doesn't exist");
        }

        existingPizza.PizzaName = pizza.PizzaName;
        existingPizza.Price = pizza.Price;

        _pizzaRepository.Update(existingPizza);
    }

    public void Delete(Guid id)
    {
        Pizza? pizza = _pizzaRepository.FindOne(id);
        if (pizza == null)
        {
            throw new Exception($"Pizza with id {id} doesn't exist");
        }

        _pizzaRepository.Delete(pizza);
    }

    public List<Pizza> GetAllWithIngredients()
    {
        return _pizzaRepository.FindAllWithIngredients();
    }
}













