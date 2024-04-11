using HomeAssignment.Models;

namespace HomeAssignment.Database;

public class AnimalDatabase
{
    public static Dictionary<int, Animal> Animals { get; set; } = new();

    public static Animal AddAnimal(Animal animal)
    {
        Animals.Add(animal.Id, animal);
        return animal;
    }

    public static Animal RemoveAnimal(Animal animal)
    {
        Animals.Remove(animal.Id);
        return animal;
    }
}