// See https://aka.ms/new-console-template for more information

using OOP;

List<AbstractAnimal> animals = new List<AbstractAnimal>
{
    new Cat(),
    new Dog(),
    new Snake()
};

var animals1 = new List<AbstractAnimal>
{
    new Cat(),
    new Dog(),
    new Snake()
};

List<AbstractAnimal> animals2 = 
[
    new Cat(),
    new Dog(),
    new Snake()
];

foreach (var animal in animals)
{
    animal.MakeSound();
}

foreach (var animal in animals1)
{
    animal.MakeSound();
}

foreach (var animal in animals2)
{
    animal.MakeSound();
    animal.Eat();
    
    switch (animal)
    {
        case Dog dog:
            dog.Run();
            break;
        case Snake snake:
            snake.Move();
            break;
    }
}


Console.WriteLine("Hello, World!");