using Microsoft.EntityFrameworkCore;
using EventBookingSystem.Data;
using Pomelo.EntityFrameworkCore.MySql;
using System;


var AllowReactClients = "AllowReactClients";

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

builder.Services.AddDbContext<EventContext>(options =>
    
    options.UseMySql(connectionString, serverVersion)
);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowReactClients,
        policy =>
        {
            if (builder.Environment.IsDevelopment())
            {
               
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
            else
            {
                // In Production, restrict to specific known origins
                policy.WithOrigins("http://localhost:3003", "https://localhost:3003",
                                   "http://localhost:3004", "https://localhost:3004",
                                   "http://localhost:3005", "https://localhost:3005",
                                   "http://localhost:3006", "https://localhost:3006")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- 3. APPLY CORS POLICY (MUST be placed before UseAuthorization and MapControllers) ---
app.UseCors(AllowReactClients);

app.UseAuthorization();

app.MapControllers();

app.Run();
