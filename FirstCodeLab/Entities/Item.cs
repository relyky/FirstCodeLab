using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCodeLab.Entities;

[PrimaryKey(nameof(Id))]
public class Item
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public required string Name { get; set; }
  public decimal Price { get; set; }
  public int Quantity { get; set; }
}
