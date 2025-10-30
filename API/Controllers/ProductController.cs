using Microsoft.AspNetCore.Mvc;
using technical_test_api.Application.Services;
using technical_test_api.Domain.Entities;

namespace technical_test_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        //Metodos GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            if (!products.Any())
                return NotFound("No hay productos registrados.");

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) 
                return NotFound($"No se encontró un producto con el ID {id}.");
            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            //Validacion para la busqueda
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Debe ingresar un nombre para realizar la búsqueda.");
           
            var products = await _service.SearchAsync(name);
            //Validacion del resultado de la busqueda
            if (products == null || !products.Any())
                return NotFound("No se encontraron productos con ese nombre.");

            return Ok(products);
        }

        //Metodo POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            //Validaciones para el Create, estas son las que estan en la entidad
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new {id = product.Id },product);
        }

        //Metodo PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            //Validaciones para el Update
            if (id != product.Id)
                return BadRequest("El ID del producto no coincide");
            //Igual usa las validaciones que estan en la entidad
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            //Valida la existencia del producto eb la DB
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"No se encontró un producto con el ID {id}.");

            await _service.UpdateAsync(product);
            return Ok("Producto actualizado correctamente");
        }

        //Metodo DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Valida la existencia del producto eb la DB
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound($"No se encontró un producto con el ID {id}.");
            await _service.DeleteAsync(id);
            return Ok("Producto eliminado correctamente");
        }


    }
}
