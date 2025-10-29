using technical_test_api.Domain.Entities;
using technical_test_api.Domain.Interfaces;

namespace technical_test_api.Application.Services
{
    public class PersonaService 
    {
        private readonly IPersonaRepository _repository;

        public PersonaService(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Persona>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Persona?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Persona persona) => _repository.AddAsync(persona);
        public Task UpdateAsync(Persona persona) => _repository.UpdateAsync(persona);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
