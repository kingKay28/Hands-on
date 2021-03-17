using System;

namespace AdapterPatternCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Movable bugatti = new BugattiVeyron();
            MovableAdapter bugattiAdapted = new AdaptedBugatti();
            Console.WriteLine("Speed in MPH : "+bugatti.Speed());
            Console.WriteLine("Speed in KMPH : "+bugattiAdapted.Speed());
            Console.WriteLine("MPH speed * 1.60934 : " + bugatti.Speed() * 1.60934);
            Console.WriteLine("Price in USD : " + bugatti.Price());
            Console.WriteLine("Price in Euro : " + bugattiAdapted.Price());
            Console.WriteLine("Price in USD * 0.84 : " + bugatti.Price() * 0.84);
            Console.ReadLine();
        }
    }
}
