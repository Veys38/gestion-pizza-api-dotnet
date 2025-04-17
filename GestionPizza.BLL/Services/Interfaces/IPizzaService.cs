using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services.Interfaces;

public interface IPizzaService
{
    IEnumerable<Pizza> FindAll();
    Pizza FindById(Guid id);
    Pizza Save(Pizza pizza);
    void Update(Guid id, Pizza pizza);
    void Delete(Guid id);
    List<Pizza> GetAllWithIngredients();
}