using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstCodeLab.DB.Entities;

public class Customer
{
  [Description("我是Id欄位說明")]
  public int Id { get; set; }

  [Description("我是Name欄位說明")]
  [MaxLength(20)]
  public required string Name { get; set; }

  [Description("我是Email欄位說明")]
  [MaxLength(50)]
  public required string Email { get; set; }

  public DateTime CreatedAt { get; set; }
}
