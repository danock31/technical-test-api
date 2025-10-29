using Microsoft.EntityFrameworkCore;
using technical_test_api.Domain.Interfaces;
using technical_test_api.Domain.Entities;
using technical_test_api.Infrastructure.Persistence;
using System.Security.AccessControl;

namespace technical_test_api.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicacionDbContext _context;
        public PersonaRepository(ApplicacionDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Persona>>GetAllAsync() => 
            await _context.personas.ToListAsync();
        public async Task<Persona?>GetByIdAsync(int id) =>
        await _context.personas.FindAsync(id);
        public async Task AddAsync (Persona persona) 
        { 
            _context.personas.Add(persona);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await _context.personas.FindAsync(id);
            if (persona != null)
            {
                _context.personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}
