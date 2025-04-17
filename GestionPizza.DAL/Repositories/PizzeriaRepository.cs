using ASP_Book_CRUD.ToolBox.Repositories;
using GestionPizza.DAL.Context;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;

namespace GestionPizza.DAL.Repositories;

public class PizzeriaRepository : CrudRepository<Pizzeria> , IPizzeriaRepository
{
    private readonly LibraryDbContext _dbContext;

    public PizzeriaRepository(LibraryDbContext dbContext)
        : base(dbContext)
    {
    }
}