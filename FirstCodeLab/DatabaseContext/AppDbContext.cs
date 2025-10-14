using FirstCodeLab.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstCodeLab.DatabaseContext;

public class AppDbContext(DbContextOptions<AppDbContext> _options)
  : DbContext(_options)
{
  public DbSet<Customer> Customer { get; set; }
  public DbSet<Product> Product { get; set; }
  public DbSet<Order> Order { get; set; }
  public DbSet<OrderItem> OrderItem { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

  }
}
