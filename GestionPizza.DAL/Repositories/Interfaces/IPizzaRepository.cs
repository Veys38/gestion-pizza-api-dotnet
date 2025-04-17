using ASP_Book_CRUD.ToolBox.Repositories;
using GestionPizza.DL.Entities;

namespace GestionPizza.DAL.Repositories.Interfaces;

public interface IPizzaRepository : ICrudRepository<Pizza>
{
    List<Pizza> FindAllWithIngredients();
}