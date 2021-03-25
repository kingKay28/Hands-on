using System;
using System.Collections.Generic;

namespace ObserverIT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var notificationService = new NotificationService();
            //subject.Tickets = 98;
            var john = new JohnObserver("John");
            var steve = new SteveObserver("Steve");

            notificationService.registerObserver(john);
            notificationService.registerObserver(steve);
            notificationService.NotifySubscriber();
            Console.WriteLine("Removing Steve ffrom subscribers list");
            notificationService.unregisterObserver(steve);
            notificationService.NotifySubscriber();
        }
    }

    //subject
    public interface INotificationService
    {
        void registerObserver(INotificationObserver observer);
        void unregisterObserver(INotificationObserver observer);
        void NotifySubscriber();
    }


    //concrete subject
    public class NotificationService : INotificationService
    {
        private List<INotificationObserver> Observers = new List<INotificationObserver>();
        public void NotifySubscriber()
        {
            foreach (var observer in Observers)
            {
                observer.OnServerDown();
            }
        }

        public void registerObserver(INotificationObserver observer)
        {
            Observers.Add(observer);
        }

        public void unregisterObserver(INotificationObserver observer)
        {
            Observers.Remove(observer);
        }
    }

    //observer

    public interface INotificationObserver
    {
        //void Update();
        string Name { get; set; }
        void OnServerDown();
    }

    //concrete observer
    public class SteveObserver : INotificationObserver
    {
       // public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
        public SteveObserver(string name)
        {
            Name = name;
        }
        public void OnServerDown()
        {
            Console.WriteLine("Notification received to :" + Name);
        }
    }

    public class JohnObserver : INotificationObserver
    {
        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
        public JohnObserver(string name)
        {
            Name = name;
        }
        public void OnServerDown()
        {
            Console.WriteLine("Notification received to :" + Name);
        }
    }

}
