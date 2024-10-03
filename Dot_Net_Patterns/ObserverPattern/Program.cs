// See https://aka.ms/new-console-template for more information

using ObserverPattern;

Console.WriteLine("-=== Starting ===-");

var subject = new Subject();
var greenObserver = new Observer(ConsoleColor.Green);
var redObserver = new Observer(ConsoleColor.Red);
var yellowObserver = new Observer(ConsoleColor.Yellow);

subject.OnQuantityUpdated += greenObserver.ObserverQuantity;
subject.OnQuantityUpdated += redObserver.ObserverQuantity;
subject.OnQuantityUpdated += yellowObserver.ObserverQuantity;

subject.UpdateQuantity(12);
subject.UpdateQuantity(5);
