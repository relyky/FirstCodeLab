using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.Entities;

public class Order
{
  public int OrderNo { get; set; }
  public decimal Amount { get; set; }
  [ForeignKey(nameof(Customer))]
  public required string CustomerId { get; set; }

  public required virtual Customer Customer { get; set; }
}
