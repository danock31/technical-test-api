﻿using technical_test_api.Domain.Entities;
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

        public Task<IEnumerable<Product>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Product?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(Product product) => _repository.AddAsync(product);
        public Task UpdateAsync(Product product) => _repository.UpdateAsync(product);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
