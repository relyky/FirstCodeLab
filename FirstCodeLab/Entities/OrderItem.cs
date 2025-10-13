using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.Entities;

[Keyless]
public class OrderItem
{
  [ForeignKey(nameof(Item))]
  public int ItemId { get; set; }
  [ForeignKey(nameof(Order))]
  public int OrderId { get; set; }
  public required virtual Item Item { get; set; }
  public required virtual Order Order { get; set; }
}
