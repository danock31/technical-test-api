using Microsoft.EntityFrameworkCore;
using technical_test_api.Domain.Entities;

namespace technical_test_api.Infrastructure.Persistence
{
    public class ApplicacionDbContext : DbContext
    {
        public ApplicacionDbContext(DbContextOptions<ApplicacionDbContext> options):base(options){}
        public DbSet<Product>products { get; set; }
    }
}
