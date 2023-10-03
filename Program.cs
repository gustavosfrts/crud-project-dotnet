using estudo_dotnet.Data;
using estudo_dotnet.Data.Context;
using estudo_dotnet.Interfaces.Entities;
using estudo_dotnet.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

// Configurando o banco de dados
var connectionString = builder.Configuration.GetConnectionString("ProductConnection");

builder.Services.AddDbContext<EstudoContext>(opts => opts.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Seeder();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
