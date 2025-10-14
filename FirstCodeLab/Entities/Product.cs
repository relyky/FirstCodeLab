using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.Entities;

[PrimaryKey(nameof(ProductNo))]
public class Product
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ProductNo { get; set; }
  public required string Name { get; set; }
  public decimal Price { get; set; }
}
