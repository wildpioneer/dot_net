// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations.Schema;
using Simple_Classes;

Console.WriteLine("Staring...");

Dog dog = new Dog("Васька", "Черный");
dog.Feed(new Fish());
dog.Feed(new Kibble());

Console.WriteLine("Feeding...");
PetFeeder.FeedPet(dog, new Fish());

Console.WriteLine("Make Noise....");
var animals = new List<IAnimal> { new Cat("Cat1", "black"), new Dog("Dog1", "white")};
foreach (var animal in animals)
{
    Console.WriteLine(animal.MakeNoise());
}