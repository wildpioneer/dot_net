namespace Constructors;

public class ChainConstructor(string name, string surname)
{
    private string _name = name;
    private string _surname = surname;

    internal ChainConstructor(string name) : this(name, string.Empty)
    {
    }

    public ChainConstructor() : this(string.Empty, string.Empty)
    {
    }
}