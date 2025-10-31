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
        public Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return _repository.GetAllAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocurrio un error al obtener los datos: {ex.Message}");
            }
            
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            try
            {
                return _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception($"Ocurrio un error al obtener los datos: {ex.Message}");
            }
            
        }

        public async Task<IEnumerable<Product>> SearchAsync(string name)
        {
            try
            {   
                //Valida si el dato viene vacio
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Debe ingresar un nombre para buscar.");

                return await _repository.SearchAsync(name);
            }
            catch (ArgumentException ex)
            {

                throw new Exception($"Error al buscar el producto: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al realizar su busqueda: {ex.Message}");
            }
        }

        //Metodo Post
        public async Task AddAsync(Product product)
        {
            try
            {
                //Valida si el dato viene vacio
                if (string.IsNullOrWhiteSpace(product.Name))
                    throw new ArgumentException("El nombre es obligatorio.");

                await _repository.AddAsync(product);
            }
            catch (ArgumentException ex)
            {

                throw new Exception($"Error de validacion: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al crear el producto: {ex.Message}", ex);
            }
        }

        //Metodo Put
        public async Task UpdateAsync(Product product)
        {
            try
            {
                //Valida si el dato viene vacio
                if (string.IsNullOrWhiteSpace(product.Name))
                    throw new ArgumentException("El nombre es obligatorio.");

                await _repository.UpdateAsync(product);
            }
            catch (ArgumentException ex)
            {

                throw new Exception($"Error en la validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al actualizar el producto: {ex.Message}", ex);
            }
        }
        //Metodo Delete
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);

    }
}
