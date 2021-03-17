using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPatternCar
{
    public interface Movable
    {
        double Speed();
        double Price();
    }

    public class BugattiVeyron : Movable
    {
        //Implementation class for Movable
        Movable Bugatti;
         public double Speed() 
        { 
            return 268; 
        }

        public double Price()
        {
            return 900000;
        }

    }

    public interface MovableAdapter
    {
        double Speed();
        double Price();
    }
    
    public class AdaptedBugatti : MovableAdapter
    {

        // Implementation class for MovableAdapter
        BugattiVeyron bugattiVeyron = new BugattiVeyron();
        public double Speed()
        {
            
            return ConvertMPHtoKMPH(bugattiVeyron.Speed());
        }

        private double ConvertMPHtoKMPH(double MPHSpeed)
        {
            return MPHSpeed * 1.60934;
        }

        public double Price()
        {
            return ConvertUSDtoEuro(bugattiVeyron.Price());
        }
        public double ConvertUSDtoEuro(double USDPrice)
        {
            return USDPrice * 0.84;
        }
    }
class Adapter
    {
    }
}
