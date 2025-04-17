using GestionPizza.DL.Entities;

namespace GestionPizza.BLL.Services.Interfaces
{
    public interface IPizzeriaService
    {
        IEnumerable<Pizzeria> FindAll();
        Pizzeria FindById(Guid id);
        Pizzeria Save(Pizzeria pizzeria);
        void Update(Guid id, Pizzeria pizzeria);
        void Delete(Guid id);
    }
}