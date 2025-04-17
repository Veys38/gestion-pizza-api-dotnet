using ASP_Book_CRUD.ToolBox.Repositories;
using GestionPizza.DAL.Context;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionPizza.DAL.Repositories;

public class PizzaRepository : CrudRepository<Pizza> , IPizzaRepository
{
    private readonly LibraryDbContext _dbContext;

    public PizzaRepository(LibraryDbContext dbContext)
        : base(dbContext)
    {
    }

    public List<Pizza> FindAllWithIngredients()
    {
        return _entities
            .Include(p => p.Ingredients)
            .ToList();
    }
    
}