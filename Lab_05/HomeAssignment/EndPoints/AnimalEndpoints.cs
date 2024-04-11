using HomeAssignment.Database;
using HomeAssignment.Models;

namespace HomeAssignment.EndPoints;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", () => Results.Ok(AnimalDatabase.Animals));

        app.MapPost("/animals", (Animal animal) => Results.Created("",AnimalDatabase.AddAnimal(animal)));

        app.MapGet("/animals/{id:int}", (int id) =>
        {
            var animal = AnimalDatabase.Animals.FirstOrDefault(a => a.Key == id).Value;
            return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
        });
        
        app.MapPut("/animals/{id:int}", (int id, Animal animal) =>
        {
            var animalToEdit = AnimalDatabase.Animals.FirstOrDefault(a => a.Key == id).Value;
            if (animalToEdit == null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            AnimalDatabase.Animals.Remove(animalToEdit.Id);
            AnimalDatabase.AddAnimal(animal);
            return Results.NoContent();
        });
        
        app.MapDelete("/animals/{id:int}", (int id) => { 
            var animal = AnimalDatabase.Animals.FirstOrDefault(a => a.Key == id).Value;
            if (animal == null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            AnimalDatabase.RemoveAnimal(animal);
            return Results.NoContent();
            
        });
        
        
    }
}