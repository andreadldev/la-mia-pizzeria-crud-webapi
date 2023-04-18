using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizzas() 
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                IQueryable<Pizza> pizzas = ctx.Pizzas;
                return Ok(pizzas.ToList());
            }
        }
    }
}
