using Microsoft.EntityFrameworkCore;
using OrderServiceApp.Controllers.Interfaces;
using OrderServiceApp.Data;
using OrderServiceApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
