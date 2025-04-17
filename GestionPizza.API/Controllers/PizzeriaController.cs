using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.Dtos.Pizzeria;
using GestionPizza.Mappeurs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionPizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzeriaController : ControllerBase
{
    private readonly IPizzeriaService _pizzeriaService;

    public PizzeriaController(IPizzeriaService pizzeriaService)
    {
        _pizzeriaService = pizzeriaService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PizzeriaDto>> GetAll()
    {
        var result = _pizzeriaService.FindAll()
            .Select(p => p.ToPizzeriaDto())
            .ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<PizzeriaDto> GetById([FromRoute] Guid id)
    {
        var pizzeria = _pizzeriaService.FindById(id);
        return Ok(pizzeria.ToPizzeriaDto());
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult Create([FromBody] PizzeriaFormDto form)
    {
        _pizzeriaService.Save(form.ToPizzeria());
        return Accepted();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public ActionResult Update([FromRoute] Guid id, [FromBody] PizzeriaFormDto form)
    {
        _pizzeriaService.Update(id, form.ToPizzeria());
        return Accepted();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public ActionResult Delete([FromRoute] Guid id)
    {
        _pizzeriaService.Delete(id);
        return Accepted();
    }
}