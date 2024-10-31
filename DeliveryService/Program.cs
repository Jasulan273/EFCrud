using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using DeliveryService.Events;
using MassTransit;
using DeliveryService.Consumers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
    });

    x.AddConsumer<OrderCreatedConsumer>();
});

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapPost("/orders/create-order", async context =>
    {
        var order = await context.Request.ReadFromJsonAsync<OrderCreatedEvent>();

        var bus = context.RequestServices.GetRequiredService<IBus>();
        await bus.Publish(order);
        await context.Response.WriteAsJsonAsync(new { message = "Order created successfully!" });
    });
});

app.Run();
