using Microsoft.AspNetCore.Mvc;
using technical_test_api.Application.Services;
using technical_test_api.Domain.Entities;

namespace technical_test_api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _service;
        public PersonaController(PersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _service.GetByIdAsync(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Persona persona)
        {
            await _service.AddAsync(persona);
            return CreatedAtAction(nameof(GetById), new {id = persona.Id },persona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Persona persona)
        {
            if(id != persona.Id) return BadRequest();
            await _service.UpdateAsync(persona);
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
