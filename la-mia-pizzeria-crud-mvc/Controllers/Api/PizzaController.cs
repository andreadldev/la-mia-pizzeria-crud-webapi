using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_mvc.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizzas([FromQuery] string? name) 
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                var pizzas = ctx.Pizzas
                .Where(p => name == null || p.Name.ToLower().Contains(name.ToLower()))
                .ToList();

                return Ok(pizzas);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                var pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

                if (pizza == null)
                {
                    return NotFound();
                }

                return Ok(pizza);
            }
        }
    }
}
