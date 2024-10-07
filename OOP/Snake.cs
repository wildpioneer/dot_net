namespace OOP;

public class Snake : AbstractAnimal, IMovable
{
    public override void MakeSound()
    {
        Console.WriteLine("Silent Snake");
    }

    public void Move()
    {
        Console.WriteLine("Snake Move");
    }
}