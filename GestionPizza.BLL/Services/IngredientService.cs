using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.DAL.Repositories;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    
    
    
    public IEnumerable<Ingredient> FindAll()
    {
        return _ingredientRepository.FindMany();
    }
    
    public void Delete(Guid id)
    {
        Ingredient? existingIngredient = _ingredientRepository.FindOne(id);
        if(existingIngredient == null)
        {
            throw new Exception($"Ingredient with id {id} doesn't exist");
        }
        _ingredientRepository.Delete(existingIngredient);
    }

    public Ingredient FindById(Guid id)
    {
        Ingredient? ingredient = _ingredientRepository.FindOne(id);
        if(ingredient == null)
        {
            throw new Exception($"Ingredient with id {id} doesn't exist");
        }
        return ingredient;
    }

    public Ingredient Save(Ingredient ingredient)
    {
        if(_ingredientRepository.Any(i => i.Name == ingredient.Name))
        {
            throw new Exception($"Ingredient with id {ingredient.Name} already exist");
        }
        return _ingredientRepository.Save(ingredient);
    }

    public void Update(Guid id, Ingredient ingredient)
    {
        Ingredient? existingIngredient = _ingredientRepository.FindOne(id);
        if(existingIngredient == null)
        {
            throw new Exception($"Book with id {id} doesn't exist");
        }

        existingIngredient.Name = ingredient.Name;
        

        _ingredientRepository.Update(existingIngredient);
    }
}
