using Decorator;

var messages = new List<IMessage>
{
    new NormalDecorator(new SimpleMessage("First Message!")),
    new NormalDecorator(new AlertMessage("Second Message with a beep!")),
    new ErrorDecorator(new AlertMessage("Third Message with a Alert and in red!")),
    new SimpleMessage("Not Decorated...")
};

foreach (var message in messages)
{
    message.PrintMessage();
}