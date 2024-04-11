using HomeAssignment.Database;
using HomeAssignment.Models;

namespace HomeAssignment.EndPoints;

public static class VisitEndpoints
{

    public static void MapVisitEndpoints(this WebApplication app)
    {
        app.MapGet("/visits/{id:int}", (int id) =>
        {
            var visits = VisitDatabase.Visits.Where(v => v.Animal.Id == id).ToList();
            return visits.Count == 0 ? Results.NotFound($"Visits with animal with id {id} were not found") : Results.Ok(visits);
        });

        app.MapPost("/visits", (Visit visit) =>
        {
            VisitDatabase.Visits.Add(visit);
            return Results.Created("" ,visit);
        });
    }
}