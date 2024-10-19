using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Добавление Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// Использование Ocelot
app.UseRouting();
app.UseAuthorization();
await app.UseOcelot();
app.Run();
