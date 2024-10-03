namespace Decorator;

public class ErrorDecorator : MessageDecorator
{
    public ErrorDecorator(Message message) : base(message)
    {
    }

    public override void PrintMessage()
    {
        var defaultColor = Console.ForegroundColor;  
        
        Console.ForegroundColor = ConsoleColor.Red;
        _message.PrintMessage();
        Console.ForegroundColor = defaultColor;
    }
}