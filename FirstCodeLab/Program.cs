using FirstCodeLab.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<LogLevel>());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
  var databaseProvider = builder.Configuration.GetValue("DatabaseProvider", "SqlServer");
  if (databaseProvider == "Npgsql")
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyTestDB_Npgsql"));
  else
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyTestDB_SqlServer"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();

  //※ To create DB schema in the development environment.
  using var scope = app.Services.CreateScope();
  using var dbctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  dbctx.Database.EnsureDeleted();
  dbctx.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
