namespace OOP;

public class Dog : AbstractAnimal, IRunnable
{
    public Dog()
    {
        AnimalType = AnimalType.Dog;
        Name = "Taker";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }

    public void Run()
    {
        Console.WriteLine("I'm running.!");
    }
}