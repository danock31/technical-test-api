using technical_test_api.Domain.Entities;
namespace technical_test_api.Domain.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>>GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
    }
}
