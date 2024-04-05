using Lab_05.Models;

namespace Lab_05.Database;

public class MockDb
{
    public List<Animal> Animals { get; set; }

    public MockDb()
    {
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
    }
}