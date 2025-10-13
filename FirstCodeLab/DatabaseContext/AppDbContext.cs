using FirstCodeLab.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstCodeLab.DatabaseContext;

public class AppDbContext : DbContext
{
  public DbSet<Customer> Customer { get; set; }
  public DbSet<Item> Item { get; set; }
  public DbSet<Order> Order { get; set; }
  public DbSet<OrderItem> OrderItem { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Data Source=RELYNB4;Initial Catalog=MyTestDB;Integrated Security=True;Encrypt=False");
  }
}
