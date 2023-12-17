using PetHealthMonitor.Application.Pets;
using PetHealthMonitor.Application.Triages;
using PetHealthMonitor.Domain.Pets;
using PetHealthMonitor.Infrastructure.Pets;
using PetHealthMonitor.Producer.Presentation.Pets;
using PetHealthMonitor.Producer.Presentation.Triages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Adicionar em um método de extensão
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
app.AddTriageEndpoints();

app.Run();