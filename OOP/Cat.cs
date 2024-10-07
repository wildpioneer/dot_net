namespace OOP;

public class Cat : AbstractAnimal
{
    public Cat()
    {
        AnimalType = AnimalType.Cat;
        Name = "Barsik";
    }
    
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}