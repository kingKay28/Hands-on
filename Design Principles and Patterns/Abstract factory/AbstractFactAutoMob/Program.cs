using System;

namespace AbstractFactAutoMob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AutoFactory autoFactory = new AutoFactory();
            Factory car1 = autoFactory.GetFactory("Audi");
            Factory car2 = autoFactory.GetFactory("Mercedes");
            car1.makeHeadLight();
            car1.makeTire();
            car2.makeHeadLight();
            car2.makeTire();
            Console.ReadLine();
        }
    }
}
