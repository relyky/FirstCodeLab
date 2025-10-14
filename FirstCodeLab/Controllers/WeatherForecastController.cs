using FirstCodeLab.DB.DatabaseContext;
using FirstCodeLab.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace FirstCodeLab.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
  AppDbContext _dbctx,
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

  [HttpGet("[action]")]
  public MsgObj GetDbProviderName()
  {
    return new MsgObj
    {
      Success = true,
      Data = _dbctx.Database.ProviderName,
    };
  }

  [HttpPost("[action]")]
  public MsgObj TestDBConnection()
  {
    try
    {
      bool Success = _dbctx.Database.CanConnect();
      return new MsgObj
      {
        Success = Success,
        Message = "Database connection successful.",
        Severity = LogLevel.Information
      };
    }
    catch (Exception ex)
    {
      return new MsgObj
      {
        Success = false,
        Data = ex.Message,
        Message = "Database connection failed.",
        Severity = LogLevel.Error
      };
    }
  }
}