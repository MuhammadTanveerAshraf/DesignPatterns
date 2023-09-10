using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Example
{
    //Abstract Product
    public interface IPizza
    {
        string Eat();
    }
    public interface IBurger
    {
        string Eat();
    }

    //Concrete Product
    public class VegPizza : IPizza
    {
        public string Eat()
        {
            return "Eating Veg Pizza";
        }
    }

    public class NonVegPizza : IPizza
    {
        public string Eat()
        {
            return "Eating non veg pizza";
        }
    }
    public class VegBurger : IBurger
    {
        public string Eat()
        {
            return "Eating Veg Burger";
        }
    }

    public class NonVegBurger : IBurger
    {
        public string Eat()
        {
            return "Eating non Veg Burger";
        }
    }

    //Abstract Factory
    public interface ICheff
    {
        IPizza PreparePizza();
        IBurger PrepareBurger();
    }

    //Factory
    public class VegCheffFactory : ICheff
    {
        public IBurger PrepareBurger()
        {
            return new VegBurger();
        }

        public IPizza PreparePizza()
        {
            return new VegPizza();
        }
    }

    public class NonVegCheffFactory : ICheff
    {
        public IBurger PrepareBurger()
        {
            return new NonVegBurger();
        }

        public IPizza PreparePizza()
        {
            return new NonVegPizza();
        }
    }

    //Client
    public class Waiter
    {
        private ICheff foodFactory;
        public Waiter(string pref)
        {
            if (pref == "Veg")
                foodFactory = new VegCheffFactory();
            else
                foodFactory = new NonVegCheffFactory();
        }

        public IPizza GetPizza()
        {
            return foodFactory.PreparePizza();
        }

        public IBurger GetBurger()
        {
            return foodFactory.PrepareBurger();
        }
    }
}
