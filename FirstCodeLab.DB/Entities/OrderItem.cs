using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.DB.Entities;

[PrimaryKey(nameof(Ssn))]
public class OrderItem
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Ssn {  get; set; }
  [ForeignKey(nameof(Order))]
  public int OrderNo { get; set; }
  [ForeignKey(nameof(Product))]
  public int ProductNo { get; set; }
  [Precision(18, 4)]
  public decimal UnitPrice { get; set; }
  public int Quantity { get; set; }
  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public decimal ExtendedPrice => UnitPrice * Quantity;
  public required virtual Product Product { get; set; }
  public required virtual Order Order { get; set; }
}
