using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services.Interfaces;

public interface IIngredientService
{
    IEnumerable<Ingredient> FindAll();
    Ingredient FindById(Guid id);
    Ingredient Save(Ingredient ingredient);
    void Update(Guid id, Ingredient ingredient);
    void Delete(Guid id);
}