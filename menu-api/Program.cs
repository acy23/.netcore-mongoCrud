using menu_api.Models;
using menu_api.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MenuDatabaseSettings>(
    builder.Configuration.GetSection("MenuDatabase"));
builder.Services.Configure<MenuDatabaseSettings>(
    builder.Configuration.GetSection("OrderDatabase"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.TryAddTransient<MenuItemService>();
builder.Services.TryAddTransient<OrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
