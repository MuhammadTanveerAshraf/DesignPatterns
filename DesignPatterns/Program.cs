// See https://aka.ms/new-console-template for more information
using DesignPatterns;
using DesignPatterns.Example;

Console.WriteLine("Hello, World!");

//Builder builder = new Builder();

//Factory factory = new();

//AbstractFactory absFactory = new AbstractFactory();

Waiter waiter = new Waiter("Veg");
IPizza pizza = waiter.GetPizza();
IBurger burger = waiter.GetBurger();

Console.WriteLine(pizza.Eat());
Console.WriteLine(burger.Eat());

Console.ReadLine();