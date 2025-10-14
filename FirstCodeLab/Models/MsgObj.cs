namespace FirstCodeLab.Models;

public record MsgObj
{
  public bool Success { get; init; }
  public dynamic? Data { get; init; }
  public string? Message { get; init; }
  public LogLevel? Severity { get; init; }
}
