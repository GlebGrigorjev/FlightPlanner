using FlightPlanner.Handlers;
using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerData;
using FlightPlannerServices;
using FlightPlannerUseCases;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlightPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            // Add services to the container.

            builder.Services.AddControllers();
            // configure basic authentication 
            builder.Services.AddAuthentication("AuthenticationHandler")
                .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("AuthenticationHandler", null);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FlightPlannerDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddTransient<IFlightPlannerDBContext, FlightPlannerDBContext>();
            builder.Services.AddTransient<IDBService, DBService>();
            builder.Services.AddTransient<IEntityService<Airport>, EntityService<Airport>>();
            builder.Services.AddTransient<IEntityService<Flight>, EntityService<Flight>>();
            builder.Services.AddTransient<IFlightService, FlightService>();
            builder.Services.AddTransient<IAirportService, AirportService>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.Services.AddAutoMapper(assembly);
            builder.Services.AddValidatorsFromAssembly(assembly);

            builder.Services.AddServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
