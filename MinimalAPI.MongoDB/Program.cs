using MinimalAPI.MongoDB.Data.Contexts;
using MinimalAPI.MongoDB.Data.Repository;
using MinimalAPI.MongoDB.Data.Service;
using MinimalAPI.MongoDB.Domain.Interfaces;
using MinimalAPI.MongoDB.Domain.Interfaces.Service;
using MinimalAPI.MongoDB.Models;
using MinimalAPI.MongoDB.Models.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ClientesDatabaseSettings>(
    builder.Configuration.GetSection("ClienteDatabase"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoContext>();
builder.Services.AddScoped<IDataService, DataService>();
//builder.Services.AddScoped<IRepositoryClientes, RepositoryClientes>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cliente/{id}", async (IDataService _repo, string id) =>
{
    return await _repo.Clientes.ObterPorPredicado(x => x.Id == id);
})
.WithName("GetClientes");

app.MapPost("/cliente", async (IDataService _repo, Cliente cliente) =>
{
    await _repo.Clientes.Inserir(new Cliente(cliente.Nome, cliente.Documento, cliente.Ativo));
})
.WithName("InsertClientes");

app.Run();