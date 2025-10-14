using FirstCodeLab.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace FirstCodeLab.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
  IConfiguration _config,
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
    try
    {
      var connStr = _config.GetConnectionString("MyTestDB");
      using var conn = new NpgsqlConnection(connStr);
      conn.Open();

      return new MsgObj
      {
        Success = true,
        Message = "PostgreSQL connection successful.",
        Severity = LogLevel.Information
      };
    }
    catch (Exception ex)
    {
      return new MsgObj
      {
        Success = false,
        Data = ex.Message,
        Message = "PostgreSQL connection failed.",
        Severity = LogLevel.Error
      };
    }
  }
}