using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
        public IActionResult GetPizzaByID(int id)
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

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                ctx.Pizzas.Add(pizza);
                ctx.SaveChanges();

                return Ok(pizza);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutPizza(int id, [FromBody] Pizza pizza)
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                var _pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

                if (_pizza is null)
                {
                    return NotFound();
                }

                _pizza.Name = pizza.Name;
                _pizza.Description = pizza.Description;
                _pizza.Price = pizza.Price;
                _pizza.Img = pizza.Img;
                _pizza.CategoryId = pizza.CategoryId;

                ctx.SaveChanges();

                return Ok();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            using (PizzaContext ctx = new PizzaContext())
            {
                var _pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

                if (_pizza is null)
                {
                    return NotFound();
                }

                ctx.Pizzas.Remove(_pizza);
                ctx.SaveChanges();

                return Ok();
            }
        }
    }
}
