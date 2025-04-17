using GestionPizza.API.Utils;
using GestionPizza.BLL.Services.Interfaces;
using GestionPizza.DL.Entities;
using GestionPizza.Dtos.Customer;
using GestionPizza.Mappeurs;
using Microsoft.AspNetCore.Mvc;

namespace GestionPizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly JwtUtils _jwtUtils;

    public CustomerController(ICustomerService customerService, JwtUtils jwtUtils)
    {
        _customerService = customerService;
        _jwtUtils = jwtUtils;
    }

    [HttpPost("register")]
    public ActionResult Register([FromBody] RegisterFormDto form)
    {
        _customerService.Register(form.ToCustomer());
        return NoContent();
    }

    [HttpPost("login")]
    public ActionResult<CustomerTokenDto> Login([FromBody] LoginFormDto form)
    {
        Customer customer = _customerService.Login(form.PhoneNumber, form.Password);

        CustomerTokenDto tokenDto = new CustomerTokenDto
        {
            Customer = customer.ToCustomerDto(),
            Token = _jwtUtils.GenerateToken(customer)
        };

        return Ok(tokenDto);
    }
}