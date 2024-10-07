namespace OOP;

public abstract class AbstractAnimal
{
    protected AnimalType AnimalType { get; set; }
    protected string Name { get; set; }

    public abstract void MakeSound();

    public void Eat()
    {
        Console.WriteLine("I'm eating");
    }
}