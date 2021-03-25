using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFRetail
{
    class AbstractFact
    {
    }
    public abstract class Order
    {
        public string ProductType { get; set; }
        public string Channel { get; set; }
        public Order(string prodType, string channel)
        {
            this.ProductType = prodType;
            this.Channel = channel;
        }
        public Order()
        {

        }
        public abstract void ProcessOrder();
        public override string ToString()
        {
            return "Product type : " + ProductType + ". Channel : " + Channel;
        }
    }

    public class ElectronicOrder : Order
    {
        public ElectronicOrder(string prodType, string channel)
        {
            base.ProductType = prodType;
            base.Channel = channel;
        }
        public override void ProcessOrder()
        {
            //Order order = new FurnitureOrder();
            //Console.WriteLine("Processing order of type Electronics, ordered through " + order.Channel + " medium");
            //Console.WriteLine("Processing order of type Furniture");
            Console.WriteLine("Processing order of " + ToString());
        }
    }
    public class FurnitureOrder : Order
    {
        public FurnitureOrder(string prodType, string channel)
        {
            base.ProductType = prodType;
            base.Channel = channel;
        }
        public override void ProcessOrder()
        {
            //Order order = new FurnitureOrder();
            //Console.WriteLine("Processing order of type Furnitures, ordered through " + order.Channel + " medium");
            //Console.WriteLine("Processing order of type Furniture");
            Console.WriteLine("Processing order of " + ToString());
        }
    }
    public class ToysOrder : Order
    {
        public ToysOrder(string prodType, string channel)
        {
            base.ProductType = prodType;
            base.Channel = channel;
        }
        public override void ProcessOrder()
        {
            //Order order = new FurnitureOrder();
            //Console.WriteLine("Processing order of type Toys, ordered through " + order.Channel + " medium");
            //Console.WriteLine("Processing order of type Furniture");
            Console.WriteLine("Processing order of " + ToString());
        }
    }
    public class OrderFactory
    {
        public Order GenerateOrder(string prodType, string channel)
        {
            if (prodType == null)
            {
                return null;
            }
            else if (prodType.Equals("Electronic Products", StringComparison.InvariantCultureIgnoreCase))
            {
                Order order = new ElectronicOrder(prodType, channel);
                order.Channel = channel;
                return order;
                //return (new ElectronicOrder());
            }
            else if (prodType.Equals("Furniture", StringComparison.InvariantCultureIgnoreCase))
            {
                Order order = new FurnitureOrder(prodType, channel);
                order.Channel = channel;
                return order;
            }
            else if (prodType.Equals("Toys", StringComparison.InvariantCultureIgnoreCase))
            {
                Order order = new ToysOrder(prodType, channel);
                order.Channel = channel;
                return order;
            }
            return null;
        }
    }
}
