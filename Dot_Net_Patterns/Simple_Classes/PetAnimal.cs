namespace Simple_Classes;

public class PetAnimal
{
    private String PetName;
    private String PetColor;

    private int _hunger;

    public PetAnimal(string petName, string petColor)
    {
        PetName = petName;
        PetColor = petColor;
    }

    public virtual void Feed(IpetFood food)
    {
        Eat(food);
    }

    protected void Eat(IpetFood food)
    {
        _hunger -= food.Energy;
    }
}