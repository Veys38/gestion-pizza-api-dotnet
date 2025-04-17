using GestionPizza.BLL.Services;
using GestionPizza.DTOs.Order;
using GestionPizza.Mappeurs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionPizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<List<OrderShortDto>> GetAll()
    {
        var result = _orderService.FindAll()
            .Select(order => OrderMapper.ToShortDto(order))
            .ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<OrderDetailsDto> GetById([FromRoute] Guid id)
    {
        var dto = OrderMapper.ToDetailsDto(_orderService.FindById(id));
        return Ok(dto);
    }

    [HttpPost]
    [Authorize("Auth")]
    public ActionResult Create([FromBody] OrderFormDto form)
    {
        var entity = OrderMapper.ToEntity(form);
        _orderService.Save(entity);
        return Accepted();
    }

    [HttpPut("{id}")]
    [Authorize("Auth")]
    public ActionResult Update([FromRoute] Guid id, [FromBody] OrderFormDto form)
    {
        var entity = OrderMapper.ToEntity(form);
        _orderService.Update(id, entity);
        return Accepted();
    }

    [HttpDelete("{id}")]
    [Authorize("Auth")]
    public ActionResult Delete([FromRoute] Guid id)
    {
        _orderService.Delete(id);
        return Accepted();
    }
}