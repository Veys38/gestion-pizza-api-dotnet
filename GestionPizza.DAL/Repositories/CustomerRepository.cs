using ASP_Book_CRUD.ToolBox.Repositories;
using GestionPizza.DAL.Context;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionPizza.DAL.Repositories;

public class CustomerRepository : CrudRepository<Customer>, ICustomerRepository
{
    private readonly LibraryDbContext _dbContext;

    public CustomerRepository(LibraryDbContext dbContext)
        : base(dbContext)
    {
    }
}
