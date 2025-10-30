using technical_test_api.Domain.Entities;
using technical_test_api.Domain.Interfaces;

namespace technical_test_api.Application.Services
{
    public class ProductService 
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        //Metodos Get
        public Task<IEnumerable<Product>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Product?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Product>> SearchAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Debe ingresar un nombre para buscar.");

            return await _repository.SearchAsync(name);
        }

        //Metodo Post
        public async Task AddAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("El nombre es obligatorio.");

            await _repository.AddAsync(product);
        }

        //Metodo Put
        public async Task UpdateAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("El nombre es obligatorio.");

            await _repository.UpdateAsync(product);
        }
        //Metodo Delete
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);

    }
}
