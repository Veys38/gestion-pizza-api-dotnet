using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.Dtos.Ingredient;
using GestionPizza.Mappeurs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionPizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    
    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<IngredientShortDto>> GetAll()
    {
        var result = _ingredientService.FindAll()
            .Select(i => i.ToShortDto())
            .ToList();
        
        return Ok(result);
    }
    
    
    
    [HttpGet("{id}")]
    public ActionResult<IngredientDetailsDto> GetById([FromRoute] Guid id)
    {
        IngredientDetailsDto dto = _ingredientService.FindById(id).ToIngredientDetailsDto();
        return Ok(dto);
    }

    [HttpPost]
    [Authorize("Auth")]
    public ActionResult Create([FromBody] IngredientFormDto form)
    {
        _ingredientService.Save(form.ToIngredient());
        return Accepted();
    }

    [HttpPut("{id}")]
    [Authorize("Auth")]
    public ActionResult Update([FromRoute] Guid id, [FromBody] IngredientFormDto form)
    {
        _ingredientService.Update(id, form.ToIngredient());
        return Accepted();
    }

    [HttpDelete("{id}")]
    [Authorize("Auth")]
    public ActionResult Delete([FromRoute] Guid id)
    {
        _ingredientService.Delete(id);
        return Accepted();
    }
    
}