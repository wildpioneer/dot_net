// See https://aka.ms/new-console-template for more information

using Constructors;

Console.WriteLine("Hello, World!");

ClassicalConstructor classicalConstructorEmpty = new ClassicalConstructor();
ClassicalConstructor classicalConstructorOneField = new ClassicalConstructor("Name");
ClassicalConstructor classicalConstructorFullFileds = new ClassicalConstructor("Name", "Surname");

PrimaryConstructor primaryConstructor = new PrimaryConstructor("Name", "Surname");

ChainConstructor chainConstructorEmpty = new ChainConstructor();
ChainConstructor chainConstructorOneField = new ChainConstructor("Name");
ChainConstructor chainConstructorFullFields = new ChainConstructor("Name", "Surname");