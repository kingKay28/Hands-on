using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactAutoMob
{
    public abstract class Factory
    {
        public abstract HeadLight makeHeadLight();
        public abstract Tire makeTire();
    }
    public class Tire
    {

    }
    public class HeadLight
    {

    }
    public class AudiFactory : Factory
    {
        public override HeadLight makeHeadLight() 
        {
            HeadLight headLight = new HeadLight();
            Console.WriteLine("This produces HeadLight for Audi.");
            return headLight;
        }
        public override Tire makeTire()
        {
            Tire tire = new Tire();
            Console.WriteLine("This produces Tire for Audi.");
            return tire;
        }
    }

    public class MercedesFactory : Factory
    {
        public override HeadLight makeHeadLight()
        {
            HeadLight headLight = new HeadLight();
            Console.WriteLine("This produces HeadLight for Merecedes.");
            return headLight;
        }
        public override Tire makeTire()
        {
            Tire tire = new Tire();
            Console.WriteLine("This produces Tire for Merecedes.");
            return tire;
        }
    }

    public class AutoFactory
    {
        public Factory GetFactory(string factoryType)
        {
            if (factoryType == null)
            {
                return null;
            }
            else if(factoryType.Equals("Audi", StringComparison.InvariantCultureIgnoreCase))
            {
                return (new AudiFactory());
            }
            else if (factoryType.Equals("Mercedes", StringComparison.InvariantCultureIgnoreCase))
            {
                return (new MercedesFactory());
            }
            return null;
        }
    }
}
