namespace Decorator;

public abstract class MessageDecorator : IMessage
{
    protected Message _message;

    protected MessageDecorator(Message message)
    {
        _message = message;
    }

    public abstract void PrintMessage();
}