using Microsoft.EntityFrameworkCore;
using technical_test_api.Domain.Interfaces;
using technical_test_api.Domain.Entities;
using technical_test_api.Infrastructure.Persistence;
using System.Security.AccessControl;

namespace technical_test_api.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicacionDbContext _context;
        public ProductRepository(ApplicacionDbContext context) 
        { 
            _context = context;
        }
        //Metodos Get
        public async Task<IEnumerable<Product>>GetAllAsync() => 
            await _context.products.ToListAsync();

        public async Task<Product?>GetByIdAsync(int id) =>
        await _context.products.FindAsync(id);

        public async Task<IEnumerable<Product>> SearchAsync(string name)
        {
            var result = await _context.products
            .Where(p => p.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();

            return result;
        }

        //Metodo Post
        public async Task AddAsync (Product product) 
        { 
            _context.products.Add(product);
            await _context.SaveChangesAsync();
        }

        //Metodo Put
        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Metodo Delete
        public async Task DeleteAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
