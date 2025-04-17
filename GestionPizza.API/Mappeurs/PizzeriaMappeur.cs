using GestionPizza.DL.Entities;
using GestionPizza.Dtos.Pizzeria;

namespace GestionPizza.Mappeurs;

public static class PizzeriaMappeur
{
    public static PizzeriaDto ToPizzeriaDto(this Pizzeria p)
    {
        return new PizzeriaDto
        {
            Id = p.Id,
            Name = p.Name,
            Address = p.Address
        };
    }

    public static Pizzeria ToPizzeria(this PizzeriaFormDto dto)
    {
        return new Pizzeria
        {
            Name = dto.Name,
            Address = dto.Address
        };
    }
}