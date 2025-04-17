using ASP_Book_CRUD.ToolBox.Repositories;
using GestionPizza.DAL.Context;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionPizza.DAL.Repositories;

public class IngredientRepository : CrudRepository<Ingredient> , IIngredientRepository
{
    private readonly LibraryDbContext _dbContext;

    public IngredientRepository(LibraryDbContext dbContext)
        : base(dbContext)
    {
    }
    
    
    
}