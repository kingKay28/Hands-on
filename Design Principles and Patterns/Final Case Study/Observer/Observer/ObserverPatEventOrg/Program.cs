using System;
using System.Collections.Generic;

namespace ObserverPatEventOrg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var subject = new Subject();
            //subject.Tickets = 98;
            var adminA = new Observer("Admin A");
            var adminB = new Observer("Admin B");
            var adminC = new Observer("Admin C");

            Console.WriteLine("Intially sold ticket count " + subject.Tickets + " tickets");
            Console.WriteLine("\n");
            Console.WriteLine("Registering Admins A and B for future update");
            subject.registerObserver(adminA);
            subject.registerObserver(adminB);
            Console.WriteLine("New ticket sold\n");
            subject.Tickets++;
            Console.WriteLine("--\n");
            Console.WriteLine("Registering Admin C for future update and unregistering Admin B from the future updates");
            subject.registerObserver(adminC);
            subject.unregisterObserver(adminB);
            Console.WriteLine("New ticket sold\n");
            subject.Tickets++;
            Console.WriteLine("New ticket sold\n");
            subject.Tickets++;
            //Console.WriteLine("New ticket sold\n");
            //subject.Tickets++;
            Console.WriteLine("\n*******************************************************************************\n");           
            Console.WriteLine("Finally total sold ticket count " + subject.Tickets + "  \n");
            
        }
    }

    //Subject
    public interface ISubject
    {
        void registerObserver(Observer observer);
        void unregisterObserver(Observer observer);
        void notifyObservers();
    }

    //concrete subject
    public class Subject : ISubject
    {
        private List<Observer> Observers = new List<Observer>();
        //private int ticketCount = 1;
        private int ticketCount = 98;
        public int Tickets
        {
            get
            {
                return ticketCount;
            }
            set
            {
                ticketCount++;
                value = 98;
                if (ticketCount > 100)
                //if(value>10)
                {
                    
                    notifyObservers();
                }
            }
        }
        public void registerObserver(Observer observer)
        {
            Observers.Add(observer);
        }
        public void unregisterObserver(Observer observer)
        {
            Observers.Remove(observer);
        }
        public void notifyObservers()
        {
            foreach (var observer in Observers)
            {
                observer.Update();
            }
        }
    }

    //observer
    public interface IObserver
    {
        void Update();
    }
    //concrete observer
    public class Observer : IObserver
    {
        public string ObserverName;
        public Observer(string name)
        {
            ObserverName = name;
        }
        public void Update()
        {
            //Observer can update his system accordingly  
            Console.WriteLine("Hello " + ObserverName + ", sold ticket count has crossed 100.");
        }
    }
}
