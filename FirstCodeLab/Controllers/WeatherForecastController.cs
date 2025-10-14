using FirstCodeLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodeLab.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
  ILogger<WeatherForecastController> _logger
  ) : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  [HttpGet("[action]")]
  public List<WeatherForecast> Forecast()
  {
    var infoList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToList();

    _logger.LogInformation("取得天氣預報成功。");
    return infoList;
  }

  [HttpPost("[action]")]
  public MsgObj TestDBConnection()
  {
    return new MsgObj
    {
      Success = true,
      Message = "測試成功",
      Severity = LogLevel.Information
    };

    return new MsgObj
    {
      Success = false,
      Message = "測試失敗",
      Severity = LogLevel.Error
    };
  }
}
