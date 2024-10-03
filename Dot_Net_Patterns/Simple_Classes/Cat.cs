namespace Simple_Classes;

public class Cat : PetAnimal, IAnimal
{
    public Cat(string petName, string petColor) : base(petName, petColor)
    {
    }
    
    public string MakeNoise()
    {
        return "Meouw";
    }
}