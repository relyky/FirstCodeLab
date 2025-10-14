using FirstCodeLab.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace FirstCodeLab.DB.DatabaseContext;

public class AppDbContext(DbContextOptions<AppDbContext> _options)
  : DbContext(_options)
{
  public DbSet<Customer> Customer { get; set; }
  public DbSet<Product> Product { get; set; }
  public DbSet<Order> Order { get; set; }
  public DbSet<OrderItem> OrderItem { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // 把【Description】也寫入DB的描述屬性。
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
      var entity = modelBuilder.Entity(entityType.ClrType);
      foreach (var prop in entityType.ClrType.GetProperties())
      {
        var desc = prop.GetCustomAttribute<DescriptionAttribute>()?.Description;
        if (desc != null)
          entity.Property(prop.Name).HasComment(desc);
      }
    }

    // 預設值
    var nowSql = Database.ProviderName switch
    {
      "Microsoft.EntityFrameworkCore.SqlServer" => "GETDATE()",
      "Npgsql.EntityFrameworkCore.PostgreSQL" => "NOW()",
      _ => throw new NotSupportedException($"Provider {Database.ProviderName} not supported.")
    };

    modelBuilder.Entity<Customer>()
        .Property(c => c.CreatedAt)
        .HasDefaultValueSql(nowSql) 
        .ValueGeneratedOnAdd();
  }

}
