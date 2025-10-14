using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.DB.Entities;

[PrimaryKey(nameof(OrderNo))]
public class Order
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int OrderNo { get; set; }
  public decimal Amount { get; set; }
  [ForeignKey(nameof(Customer))]
  public required int CustomerId { get; set; }

  public required virtual Customer Customer { get; set; }
}
