using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatternSample
{
    //The Abstract Factory pattern provides an interface for creating families of related or dependent objects 
    //without specifying their concrete classes.

    //The Abstract Factory pattern allows for creating and working
    //with related objects without tightly coupling the client code to specific classes,
    //promoting flexibility and extensibility.

    //Abstract Product A
    public abstract class Vehicle
    {
        public abstract void Drive();
    }

    // Concrete Product A1
    public class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving a car");
        }
    }

    // Concrete Product A2
    public class Motorcycle : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving a Motorcycle");
        }
    }

    // Abstract Product B
    public abstract class Insurance
    {
        public abstract void Insure();
    }

    // Concrete Product B1
    public class CarInsurance : Insurance
    {
        public override void Insure()
        {
            Console.WriteLine("Insuring a car");
        }
    }

    // Concrete Product B1
    public class MotorcycleInsurance : Insurance
    {
        public override void Insure()
        {
            Console.WriteLine("Insuring a Motorcycle");
        }
    }

    // Abstract Factory
    public abstract class VehicleInsuranceFactory
    {
        public abstract Vehicle CreateVehicle();
        public abstract Insurance CreateInsurance();
    }

    // Concrete Factory 1
    public class CarInsuranceFactory : VehicleInsuranceFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Car();
        }

        public override Insurance CreateInsurance()
        {
            return new CarInsurance();
        }
    }

    // Concrete Factory 2
    public class MotorcycleInsuranceFactory : VehicleInsuranceFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Motorcycle();
        }

        public override Insurance CreateInsurance()
        {
            return new MotorcycleInsurance();
        }
    }

}
