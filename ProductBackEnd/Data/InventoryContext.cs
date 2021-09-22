using Microsoft.EntityFrameworkCore;
using ProductBackEnd.Models;

namespace ProductBackEnd.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
    }
}