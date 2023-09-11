using estudo_dotnet.Data;
using estudo_dotnet.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
