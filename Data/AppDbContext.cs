using Microsoft.EntityFrameworkCore;
using proyecto1.Models;


namespace proyecto1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<Producto> Productos { get; set; }
    }


    
}


