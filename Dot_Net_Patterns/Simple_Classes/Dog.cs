namespace Simple_Classes;

public class Dog : PetAnimal, IAnimal
{
    public Dog(string petName, string petColor) : base(petName, petColor)
    {
    }

    public override void Feed(IpetFood food)
    {
        if (food is Kibble)
        {
            Eat(food);
        }
        else
        {
            Console.WriteLine("Я не ем такое...");
        }
    }

    public string MakeNoise()
    {
        return "Woof";
    }
}