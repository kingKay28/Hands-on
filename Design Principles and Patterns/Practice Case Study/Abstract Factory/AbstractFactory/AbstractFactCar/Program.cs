using System;

namespace AbstractFactCar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Carfactory carfactory = new ConcreteCarFactory();
            CarClient carClient = new CarClient(carfactory);
            carClient.BuildMicroCar(Location.USA);
            carClient.BuildMiniCar(Location.INDIA);
            carClient.BuildLuxaryCar(Location.DEFAULT);
        }

        #region Car Related - Product and its parent abstract class

        public enum CarType
        {
            Micro,
            Mini,
            Luxary
        }

        public enum Location
        {
            DEFAULT, USA, INDIA
        }

        public abstract class Car
        {
            public CarType CarType { get; set; }
            public Location Location { get; set; }

            public Car(CarType carType, Location location)
            {
                CarType = carType;
                Location = location;
            }

            public abstract void Construct();

            public override string ToString()
            {
                return "CarModel - " + CarType.ToString() + " located in - " + Location.ToString();
            }
        }

        private class LuxaryCar : Car
        {
            public LuxaryCar(CarType carType, Location location) : base(CarType.Luxary, location)
            {
                Construct();
            }

            public override void Construct()
            {
                Console.WriteLine("Connecting to Luxary Car");
                Console.WriteLine(base.ToString());
            }
        }

        private class MiniCar : Car
        {
            public MiniCar(CarType carType, Location location) : base(CarType.Mini, location)
            {
                Construct();
            }

            public override void Construct()
            {
                Console.WriteLine("Connecting to Mini Car");
                Console.WriteLine(base.ToString());
            }
        }

        private class MicroCar : Car
        {
            public MicroCar(CarType carType, Location location) : base(CarType.Micro, location)
            {
                Construct();
            }

            public override void Construct()
            {
                Console.WriteLine("Connecting to Micro Car");
                Console.WriteLine(base.ToString());
            }
        }

        #endregion Car Related - Product and its parent abstract class

        #region Abstract Factory To expose to client

        private abstract class Carfactory
        {
            //public abstract void BuildMicroCar(Location location);
            //public abstract void BuildMiniCar(Location location);
            //public abstract void BuildLuxaryCar(Location location);
            public abstract void LuxaryCarGenerator(Location location);

            public abstract void MiniCarGenerator(Location location);

            public abstract void MicroCarGenerator(Location location);
        }

        private class ConcreteCarFactory : Carfactory
        {
            public override void LuxaryCarGenerator(Location location)
            {
                new LuxaryCar(CarType.Luxary, location);
            }

            public override void MicroCarGenerator(Location location)
            {
                new MicroCar(CarType.Micro, location);
            }

            public override void MiniCarGenerator(Location location)
            {
                new MiniCar(CarType.Mini, location);
            }
        }

        private class CarClient
        {
            private Carfactory carfactory;

            public CarClient(Carfactory carfactory)
            {
                this.carfactory = carfactory;
            }

            public void BuildMicroCar(Location location)
            {
                carfactory.MicroCarGenerator(location);
            }

            public void BuildMiniCar(Location location)
            {
                carfactory.MiniCarGenerator(location);
            }

            public void BuildLuxaryCar(Location location)
            {
                carfactory.LuxaryCarGenerator(location);
            }
        }

        #endregion Abstract Factory To expose to client
    }
}
