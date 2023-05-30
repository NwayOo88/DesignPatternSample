using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSample
{
    //The Decorator pattern allows for flexible and dynamic composition of objects
    //by adding or modifying their behavior at runtime without affecting other objects.
   
    // Component interface
    public interface ICar
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        string GetDescription();
        double GetCost();
    }
    
    // Concrete component
    public class BasicCar : ICar
    {
        public string GetDescription()
        {
            return "Basic Car";
        }

        public double GetCost()
        {
            return 20000;
        }
    }

    //Decorator
    //The CarDecorator is the base decorator class that implements the ICar interface and holds a reference to the component it decorates.
    public abstract class CarDecorator : ICar
    {
        protected ICar car;

        public CarDecorator(ICar car)
        {
            this.car = car;
        }

        public virtual string GetDescription()
        {
            return car.GetDescription();
        }

        public virtual double GetCost()
        {
            return car.GetCost();
        }
    }
    //The SportsCarDecorator and LuxuryCarDecorator are concrete decorators that inherit from the CarDecorator class.
    //They add additional functionality to the car by overriding the GetDescription and GetCost methods.

    //Concrete decorator
    public class SportsCarDecorator : CarDecorator
    {
        public SportsCarDecorator(ICar car) : base(car)
        {

        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Sports Package";
        }

        public override double GetCost()
        {
            return base.GetCost() + 5000;
        }
    }

    //Concrete decorator
    public class LuxuryCarDecorator : CarDecorator
    {
        public LuxuryCarDecorator(ICar car) : base(car)
        {

        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Luxury Package";
        }

        public override double GetCost()
        {
            return base.GetCost() + 10000;
        }
    }
}
