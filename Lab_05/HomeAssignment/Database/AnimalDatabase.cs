using HomeAssignment.Models;

namespace HomeAssignment.Database;

public class AnimalDatabase
{
    public Dictionary<int, Animal> Animals { get; set; } = new();

    public Animal AddAnimal(Animal animal)
    {
        Animals.Add(animal.Id, animal);
        return animal;
    }
}