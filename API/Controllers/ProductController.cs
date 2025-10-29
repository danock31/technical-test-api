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

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new {id = product.Id },product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Product product)
        {
            if(id != product.Id) return BadRequest();
            await _service.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
