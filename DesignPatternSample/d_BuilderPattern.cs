using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    // Product
    public class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public string Toppings { get; set; }

        public void Display()
        {
            Console.WriteLine($"Pizza with Dough: {Dough}, Sauce: {Sauce}, Toppings: {Toppings}");
        }
    }

    // Builder
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public void CreateNewPizza()
        {
            pizza = new Pizza();
        }

        public Pizza GetPizza()
        {
            return pizza;
        }

        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildToppings();
    }

    // Concrete Builder 1
    public class MargheritaPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.Dough = "Thin Crust";
        }

        public override void BuildSauce()
        {
            pizza.Sauce = "Tomato";
        }

        public override void BuildToppings()
        {
            pizza.Toppings = "Mozzarella Cheese, Basil";
        }
    }

    // Concrete Builder 2
    public class PepperoniPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.Dough = "Thick Crust";
        }

        public override void BuildSauce()
        {
            pizza.Sauce = "Tomato";
        }

        public override void BuildToppings()
        {
            pizza.Toppings = "Pepperoni, Cheese, Bell Peppers, Onions";
        }
    }

    // Director
    public class Chef
    {
        private PizzaBuilder pizzaBuilder;

        public void SetPizzaBuilder(PizzaBuilder builder)
        {
            pizzaBuilder = builder;
        }

        public Pizza GetPizza()
        {
            return pizzaBuilder.GetPizza();
        }

        public void ConstructPizza()
        {
            pizzaBuilder.CreateNewPizza();
            pizzaBuilder.BuildDough();
            pizzaBuilder.BuildSauce();
            pizzaBuilder.BuildToppings();
        }
    }

}
