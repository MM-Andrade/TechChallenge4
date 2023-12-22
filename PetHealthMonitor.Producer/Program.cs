using MassTransit;
using PetHealthMonitor.Application.Pets;
using PetHealthMonitor.Application.Triages;
using PetHealthMonitor.Domain.Pets;
using PetHealthMonitor.Infrastructure.Pets;
using PetHealthMonitor.Producer.Extensions;
using PetHealthMonitor.Producer.Presentation.Pets;
using PetHealthMonitor.Producer.Presentation.Triages;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configuration);
// TODO: Adicionar em um m�todo de extens�o
builder.Services.AddSingleton<IPetRepository, PetInMemoryRepository>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<ITriageService, TriageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
app.AddPetEndpoints();
app.AddTriageEndpoints(configuration);

app.Run();