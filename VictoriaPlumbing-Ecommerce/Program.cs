using Core.Services;
using Microsoft.EntityFrameworkCore;
using Victoria.Plumbing.Data;
using VictoriaPlumbing.Core.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddDbContext<DataDbContext>(builder =>
{
    builder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=VP_Orders;"); //wp - hardcoded move to settings if time allows 
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
