using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.DB.Entities;

[PrimaryKey(nameof(ProductNo))]
public class Product
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ProductNo { get; set; }
  [StringLength(50)]
  public required string Name { get; set; }
  [Precision(18, 4)]
  public decimal Price { get; set; }
}
