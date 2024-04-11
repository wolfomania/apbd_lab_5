using HomeAssignment.Database;
using HomeAssignment.Models;

namespace HomeAssignment.EndPoints;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", () => Results.Ok(new AnimalDatabase().Animals));

        app.MapPost("/animals", (Animal animal) => Results.Created("",new AnimalDatabase().AddAnimal(animal)));

        app.MapGet("/animals/{id:int}", (int id) =>
        {
            var animal = new AnimalDatabase().Animals.FirstOrDefault(a => a.Key == id).Value;
            return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
        });
        
        app.MapPut("/animals/{id:int}", (int id, Animal animal) =>
        {
            var animalToEdit = new AnimalDatabase().Animals.FirstOrDefault(a => a.Key == id).Value;
            if (animalToEdit == null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            new AnimalDatabase().Animals.Remove(animalToEdit.Id);
            new AnimalDatabase().AddAnimal(animal);
            return Results.NoContent();
        });
        
        app.MapDelete("/animals/{id:int}", (int id) => { 
            var animal = new AnimalDatabase().Animals.FirstOrDefault(a => a.Key == id).Value;
            if (animal == null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            new AnimalDatabase().Animals.Remove(animal.Id);
            return Results.NoContent();
            
        });
        
        /*var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

//Minimal API

        app.MapGet("/animals-minapi", (int id) =>
        {
            if (id == 1)
            {
                return Results.NotFound();
            }
            //do smth
            return Results.Ok("animals");
        });

        app.MapPost("/animals-minapi", (Animal animal) =>
        {
            return Results.Created("", animal);
        });*/

    }
}