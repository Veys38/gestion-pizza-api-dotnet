using ASP_Book_CRUD.ToolBox.Repositories;
using GestionPizza.DAL.Context;
using GestionPizza.DAL.Repositories.Interfaces;
using GestionPizza.DL.Entities;

namespace GestionPizza.DAL.Repositories;

public class OrderRepository : CrudRepository<Order> , IOrderRepository
{
    private readonly LibraryDbContext _dbContext;

    public OrderRepository(LibraryDbContext dbContext)
        : base(dbContext)
    {
    }
}