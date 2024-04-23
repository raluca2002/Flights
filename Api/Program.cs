
using FlightPersistenceORM;
using Microsoft.EntityFrameworkCore;
using MPP_Csharp_Server_Client.FlightServerORM;
using MPP_Csharp_Server_Client.FlightsServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqliteKey"));
});

Console.WriteLine("connection string: " + builder.Configuration.GetConnectionString("sqliteKey"));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ZborRepository>();
builder.Services.AddScoped<BiletRepository>();
builder.Services.AddScoped<BiletTuristiRepository>();
builder.Services.AddScoped<IService, Service>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();