using System;
using System.Collections.Generic;

namespace MediatorChatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //creating users
            ChatMediator mediator = new ChatMediator();
            IUser peter = new BasicUser("Peter",mediator);
            IUser stark = new BasicUser("Stark", mediator);
            IUser steve = new PremiumUser("Steve", mediator);
            IUser scott = new PremiumUser("Scott", mediator);
            //adding to list of receiver
            mediator.AddUser(peter);
            mediator.AddUser(stark);
            mediator.AddUser(steve);
            mediator.AddUser(scott);
            //sending message
            stark.SendMessage("Avengers..");
            steve.SendMessage("Assemble");

            Console.ReadLine();
        }
    }

    public interface IChatMediator
    {
        void AddUser(IUser user);
        void SendMessage(IUser user, string message);
    }
    public interface IUser
    {
        void SendMessage(string message);
        void ReceiveMessage(string message);
    }
    public class ChatMediator : IChatMediator
    {
        private List<IUser> userList = new List<IUser>();  
        public void AddUser(IUser user)
        {
            
            userList.Add(user);
        }

        public void SendMessage(IUser user, string message)
        {
            //string userType = null;
            foreach (var u in userList)
            {
                // message should not be received by the user sending it
                if (u != user)
                {
                    u.ReceiveMessage(message);
                }
            }
        }
    }

    public class BasicUser : IUser
    {
        public IChatMediator chatMediator;
        public string name;
        public BasicUser(string name, IChatMediator mediator) 
        {
            this.chatMediator = mediator;
            this.name = name;
        }
        public void ReceiveMessage(string message)
        {
            Console.WriteLine(this.name + " (Basic User) " + ": Received Message:" + message);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine("\n" + this.name + " (Basic User) " + ": Sending Message=" + message + "\n");
            chatMediator.SendMessage(this,message);
        }
    }

    public class PremiumUser : IUser
    {
        public IChatMediator chatMediator;
        public string name;
        public PremiumUser(string name, IChatMediator mediator)
        {
            this.chatMediator = mediator;
            this.name = name;
        }
        public void ReceiveMessage(string message)
        {
            Console.WriteLine(this.name + " (Premium User) " + ": Received Message:" + message);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine("\n" + this.name + " (Premium User) " + ": Sending Message=" + message + "\n");
            chatMediator.SendMessage(this, message);
        }
    }
}
