using Microsoft.EntityFrameworkCore;
using PocApiSample.Domain;

namespace PocApiSample
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {

        }
        
        
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
