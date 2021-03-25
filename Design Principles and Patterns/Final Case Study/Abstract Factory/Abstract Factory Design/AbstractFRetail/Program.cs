using System;

namespace AbstractFRetail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            OrderFactory orderFactory = new OrderFactory();
            Order order1 = orderFactory.GenerateOrder("Electronic Products", "E-Commerce Website");
            Order order2 = orderFactory.GenerateOrder("Furniture", "Tele Caller Agents Application");
            Order order3 = orderFactory.GenerateOrder("Toys", "E-Commerce Website");

            
            order1.ProcessOrder();
            //Console.WriteLine("Order medium of order-1" + order1.Channel);
            order2.ProcessOrder();
            //Console.WriteLine("Order medium of order-2" + order2.Channel);
            order3.ProcessOrder();
            //Console.WriteLine("Order medium of order-3" + order3.Channel);
            Console.ReadLine();
        }
    }
}
