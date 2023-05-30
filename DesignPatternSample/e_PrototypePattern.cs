using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatternSample
{
    //The Prototype pattern creates new objects by cloning existing ones, 
    //    thus avoiding the need for explicit instantiation.

    // Prototype
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype Clone();
        public abstract void Display();
    }

    // Concrete Prototype 1
    public class ChickenSandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;

        public ChickenSandwich(string bread, string meat, string cheese)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine("Cloning a Chicken Sandwich...");
            return MemberwiseClone() as SandwichPrototype;
        }

        public override void Display()
        {
            Console.WriteLine($"Chicken Sandwich with Bread: {bread}, Meat: {meat}, Cheese: {cheese}");
        }
    }

    // Concrete Prototype 2
    public class VeggieSandwich : SandwichPrototype
    {
        private string bread;
        private string vegetables;
        private string sauce;

        public VeggieSandwich(string bread, string vegetables, string sauce)
        {
            this.bread = bread;
            this.vegetables = vegetables;
            this.sauce = sauce;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine("Cloning a Veggie Sandwich...");
            return MemberwiseClone() as SandwichPrototype;
        }

        public override void Display()
        {
            Console.WriteLine($"Veggie Sandwich with Bread: {bread}, Vegetables: {vegetables}, Sauce: {sauce}");
        }
    }

    // Client
    public class SandwichMenu
    {
        private readonly SandwichPrototype chickenSandwich;
        private readonly SandwichPrototype veggieSandwich;

        public SandwichMenu()
        {
            chickenSandwich = new ChickenSandwich("Wheat Bread", "Grilled Chicken", "Cheddar Cheese");
            veggieSandwich = new VeggieSandwich("Multigrain Bread", "Lettuce, Tomato, Onion", "Mayonnaise");
        }

        public SandwichPrototype MakeChickenSandwich()
        {
            return chickenSandwich.Clone();
        }

        public SandwichPrototype MakeVeggieSandwich()
        {
            return veggieSandwich.Clone();
        }

    }
}
