using Microsoft.EntityFrameworkCore;
using OrderServiceApp.Data;
using OrderServiceApp.Controllers.Interfaces;
using OrderServiceApp.Services; 
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Настройка контекста базы данных
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервиса заказов
builder.Services.AddScoped<IOrderService, OrderService>();

// Регистрация контроллеров и Ocelot
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOcelot();

var app = builder.Build();

// Настройка Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Использование Ocelot
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//await app.UseOcelot(); // Добавьте это для использования Ocelot
app.Run();
