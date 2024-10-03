namespace Decorator;

public class AlertMessage : Message
{
    public AlertMessage(string text) : base(text)
    {
    }

    public override void PrintMessage()
    {
        Console.WriteLine("-=== Alert Updated ===-");
        Console.WriteLine(_text);
    }
}