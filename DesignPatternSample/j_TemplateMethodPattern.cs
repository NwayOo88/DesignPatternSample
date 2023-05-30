using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    // Abstract class with template method
    public abstract class CoffeeBeverage
    {
        //Templage method
        public void PrepareBeverage()
        {
            BoilWater();
            BrewCoffee();
            PourInCup();
            AddCondiments();
        }

        protected void BoilWater()
        {
            Console.WriteLine("Boiling water");
        }
        protected abstract void BrewCoffee();
        protected virtual void  PourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }
        protected abstract void AddCondiments();
    }
    // Concrete class implementing the template method
    public class Cappucino : CoffeeBeverage
    {
        protected override void BrewCoffee()
        {
            Console.WriteLine("Brewing raw coffee");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding milk and sugar");
        }
    }

    // Concrete class implementing the template method
    public class Espresso : CoffeeBeverage
    {
        protected override void BrewCoffee()
        {
            Console.WriteLine("Brewing expresso");
        }

        protected override void PourInCup()
        {
            Console.WriteLine("Pouring into Expresso shot cup.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("No condiments added");
        }
    }


}
