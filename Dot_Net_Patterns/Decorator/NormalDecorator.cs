namespace Decorator;

public class NormalDecorator : MessageDecorator
{
    public NormalDecorator(Message message) : base(message)
    {
    }

    public override void PrintMessage()
    {
        var defaultColor = Console.ForegroundColor;  
        
        Console.ForegroundColor = ConsoleColor.Green;
        _message.PrintMessage();
        Console.ForegroundColor = defaultColor;
    }
}