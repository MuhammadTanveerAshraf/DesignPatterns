using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class AbstractFactory
    {
        public AbstractFactory()
        {
            Console.WriteLine("The Abstract design pattern provides an Interface for creating families of related or dependent objects without" +
                " specifying their concrete classes");

            ContinentFactory america = new AmericaFactory();
            AnimalWorld world = new AnimalWorld(america);
            world.RunFoodChain();

            ContinentFactory africa = new AfricaFacory();
            world = new AnimalWorld(africa);
            world.RunFoodChain();

        }
    }

    //Abstract Factory
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    //Concrete Factory
    class AmericaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
    }

    class AfricaFacory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }

        public override Herbivore CreateHerbivore()
        {
            return new WildBeast();
        }
    }

    //Abstract Product
    abstract class Herbivore
    {
    }

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    //Product
    class WildBeast : Herbivore
    {
    }

    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
        }
    }

    class Bison : Herbivore
    {
    }

    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
        }
    }

    //Client
    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _herbivore = factory.CreateHerbivore();
            _carnivore = factory.CreateCarnivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
