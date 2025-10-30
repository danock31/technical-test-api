using technical_test_api.Domain.Entities;
namespace technical_test_api.Domain.Interfaces
{
    public interface IProductRepository
    {
        //Metodos GET
        Task<IEnumerable<Product>>GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> SearchAsync(string name);
        //Metodo POST
        Task AddAsync(Product product);
        
        //Metodos PUT
        Task UpdateAsync(Product product);
        //Metodo DELETE
        Task DeleteAsync(int id);

    }
}
