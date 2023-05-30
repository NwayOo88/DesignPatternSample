// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using DesignPatternSample;

// 1. Singleton Pattern
Logger logger1 = Logger.Instance;
logger1.LogMessage("First log message");

Logger logger2 = Logger.Instance;
logger2.LogMessage("Second log message");

Console.WriteLine(logger1 == logger2);
Console.WriteLine("");


// 2. Factory Pattern
PaymentProcessorFactory processorFactory = new PaymentProcessorFactory();

PaymentProcessor creditCardProcessor = processorFactory.CreatePaymentProcessor("CreditCard");
creditCardProcessor.ProcessPayment(100.50M);  

PaymentProcessor payPalProcessor = processorFactory.CreatePaymentProcessor("PayPal");
payPalProcessor.ProcessPayment(50.75M);  
Console.WriteLine("");

// 3. Abstract Factory Pattern
VehicleInsuranceFactory carFactory = new CarInsuranceFactory();
Vehicle car = carFactory.CreateVehicle();
Insurance carInsurance = carFactory.CreateInsurance();
car.Drive();            
carInsurance.Insure();  

VehicleInsuranceFactory motorcycleFactory = new MotorcycleInsuranceFactory();
Vehicle motorcycle = motorcycleFactory.CreateVehicle();
Insurance motorcycleInsurance = motorcycleFactory.CreateInsurance();
motorcycle.Drive();            
motorcycleInsurance.Insure();  
Console.WriteLine("");

//4. Builder Pattern
Chef chef = new Chef();

// Create a Margherita pizza
PizzaBuilder margheritaBuilder = new MargheritaPizzaBuilder();
chef.SetPizzaBuilder(margheritaBuilder);
chef.ConstructPizza();
Pizza margheritaPizza = chef.GetPizza();
margheritaPizza.Display();

// Create a Pepperoni pizza
PizzaBuilder pepperoniBuilder = new PepperoniPizzaBuilder();
chef.SetPizzaBuilder(pepperoniBuilder);
chef.ConstructPizza();
Pizza pepperoniPizza = chef.GetPizza();
pepperoniPizza.Display();
Console.WriteLine("");

//5. Prototype Pattern
SandwichMenu sandwichMenu = new SandwichMenu();

SandwichPrototype chickenSandwich = sandwichMenu.MakeChickenSandwich();
chickenSandwich.Display();

SandwichPrototype veggieSandwich = sandwichMenu.MakeVeggieSandwich();
veggieSandwich.Display();
Console.WriteLine("");

//6. Adapter Pattern

IAudioPlayer audioPlayer = new AudioPlayerAdapter(new Mp3Player());
audioPlayer.Play("MP3", "song.mp3");

audioPlayer = new AudioPlayerAdapter(new FlacPlayer());
audioPlayer.Play("FLAC", "song.flac");

audioPlayer.Play("wav", "song.wav");
Console.WriteLine("");

//7. Decorator Pattern

ICar basicCar = new BasicCar();
Console.WriteLine($"Description: {basicCar.GetDescription()}");
Console.WriteLine($"Price: {basicCar.GetCost()}");

ICar luxuryCar = new LuxuryCarDecorator(basicCar);
Console.WriteLine($"Description: {luxuryCar.GetDescription()}");
Console.WriteLine($"Price: {luxuryCar.GetCost()}");

ICar sportsLuxuryCar = new SportsCarDecorator(luxuryCar);
Console.WriteLine($"Description: {sportsLuxuryCar.GetDescription()}");
Console.WriteLine($"Price: {sportsLuxuryCar.GetCost()}");
Console.WriteLine("");

//8. Observe Pattern
INewsPublisher newsAgency = new NewsAgency();

INewsSubscriber subscriber1 = new EmailSubscriber("John");
INewsSubscriber subscriber2 = new EmailSubscriber("Emily");
INewsSubscriber subscriber3 = new SMSSubscriber("Michael");

newsAgency.AddSubscriber(subscriber1);
newsAgency.AddSubscriber(subscriber2);
newsAgency.AddSubscriber(subscriber3);

newsAgency.NotifySubscribers("Breaking News: COVID-19 vaccine rollout begins!");

newsAgency.RemoveSubscriber(subscriber2);

newsAgency.NotifySubscribers("Sports: Local team wins the championship!");
Console.WriteLine("");

//9. Strategy Pattern
ShoppingCart cart = new ShoppingCart();

// Select Credit Card payment strategy
IPaymentStrategy creditCardStrategy = new CreditCardPaymentStrategy("1234567890123456", "12/2023", "123");
cart.SetPaymentStrategy(creditCardStrategy);
cart.ProcessPayment(100.0);

// Select PayPal payment strategy
IPaymentStrategy paypalStrategy = new PayPalPaymentStrategy("example@gmail.com", "password123");
cart.SetPaymentStrategy(paypalStrategy);
cart.ProcessPayment(50.0);
Console.WriteLine("");

//10. Template Method Pattern
CoffeeBeverage espresso = new Espresso();
espresso.PrepareBeverage();


Console.WriteLine();

CoffeeBeverage cappuccino = new Cappucino();
cappuccino.PrepareBeverage();

//11. Iterator Pattern
Playlist playlist = new Playlist();
playlist.AddSong("Song 1");
playlist.AddSong("Song 2");
playlist.AddSong("Song 3");

ISongIterator iterator = playlist.CreateIterator();
while (iterator.HasNext())
{
    string? song = iterator.Next() as string;
    Console.WriteLine("Now playing: " + song);
}
Console.WriteLine();

Console.ReadLine();

