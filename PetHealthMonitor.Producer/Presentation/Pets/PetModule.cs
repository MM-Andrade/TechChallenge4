using PetHealthMonitor.Application.Pets;
using PetHealthMonitor.Domain.Pets;

namespace PetHealthMonitor.Producer.Presentation.Pets
{
    public static class PetModule
    {
        public static void AddPetEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/pets/{id}", (IPetService petService, Guid id) =>
            {
                var pet = petService.GetById(id);

                return pet is not null
                    ? Results.Ok(pet) : Results.NotFound("Pet not found.");

            }).AllowAnonymous();

            app.MapPost("/pets", (IPetService petService, Pet pet) =>
            {
                var result = petService.Create(pet);

                return Results.Ok(result);
            }).AllowAnonymous();
        }
    }
}