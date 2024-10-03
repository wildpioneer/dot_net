namespace Decorator;

public abstract class Message : IMessage
{
    protected string _text;

    protected Message(string text)
    {
        _text = text;
    }

    abstract public void PrintMessage();
}