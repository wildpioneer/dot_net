namespace Constructors;

public class ClassicalConstructor
{
    private string Name;
    private string Surname;

    internal ClassicalConstructor(string name)
    {
        Name = name;
    }

    public ClassicalConstructor()
    {
        Name = string.Empty;
    }
    
    public ClassicalConstructor(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}