
using Contracts;
using MassTransit;
using MassTransit.Futures;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.API.Database;
using User.API.Extentions;
using User.API.UseCases.Consumers;

namespace User.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

        builder.Services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseNpgsql(connectionString);
        });

        builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();


            busConfigurator.AddConsumer<CreatedOrderConsumer>();
            busConfigurator.AddConsumer<CreatedProductConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            { 
                configurator.Host(new Uri(builder.Configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(builder.Configuration["MessageBroker:Username"]!);
                    h.Password(builder.Configuration["MessageBroker:Password"]!);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ApplyMigrations();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.UseAuthorization();

        app.Run();
    }
}
