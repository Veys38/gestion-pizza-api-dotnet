using GestionPizza.BLL.Services;
using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.Dtos.Pizza;
using GestionPizza.Mappeurs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionPizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public ActionResult<List<PizzaShortDto>> GetAll()
    {
        List<PizzaShortDto> result = _pizzaService.FindAll()
            .Select(p => PizzaMapper.ToShortDto(p))
            .ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<PizzaDetailsDto> GetById([FromRoute] Guid id)
    {
        PizzaDetailsDto dto = PizzaMapper.ToDetailsDto(_pizzaService.FindById(id));
        return Ok(dto);
    }

    [HttpPost]
    [Authorize("Auth")]
    public ActionResult Create([FromBody] PizzaFormDto form)
    {
        _pizzaService.Save(PizzaMapper.ToEntity(form));
        return Accepted();
    }

    [HttpPut("{id}")]
    [Authorize("Auth")]
    public ActionResult Update([FromRoute] Guid id, [FromBody] PizzaFormDto form)
    {
        _pizzaService.Update(id, PizzaMapper.ToEntity(form));
        return Accepted();
    }

    [HttpDelete("{id}")]
    [Authorize("Auth")]
    public ActionResult Delete([FromRoute] Guid id)
    {
        _pizzaService.Delete(id);
        return Accepted();
    }

    [HttpGet("with-ingredients")]
    public ActionResult<List<PizzaShortDto>> GetWithIngredients()
    {
        var pizzas = _pizzaService.GetAllWithIngredients();
        
        var result = pizzas.Select(PizzaMapper.ToWithIngredientDto).ToList();
        
        return Ok(pizzas);
    }
}