using System;

namespace ChainOfResponsibilityLeave
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ILeaveRequestHandler hr = new HR();
            ILeaveRequestHandler projectManager = new ProjectManager();
            ILeaveRequestHandler superVisor = new Supervisor();

            LeaveRequest leaveRequest01 = new LeaveRequest 
            {
                Employee = "Steve", LeaveDays = 3
            };
            superVisor.HandleRequest(leaveRequest01.LeaveDays);
            LeaveRequest leaveRequest02 = new LeaveRequest
            {
                Employee = "Stark",
                LeaveDays = 5
            };
            superVisor.HandleRequest(leaveRequest02.LeaveDays);
            LeaveRequest leaveRequest03 = new LeaveRequest
            {
                Employee = "Peter",
                LeaveDays = 2
            };
            superVisor.HandleRequest(leaveRequest03.LeaveDays);
            //ProjectManager projectManager = new ProjectManager();
            //Supervisor supervisor = new Supervisor();

            //LeaveRequest leaveRequest = new LeaveRequest();
            //Console.WriteLine("Applying leave for 2 days");
            //leaveRequest.ApplyLeave(2);
            //Console.WriteLine("Applying leave for 3 days");
            //leaveRequest.ApplyLeave(3);
            //Console.WriteLine("Applying leave for 5 days");
            //leaveRequest.ApplyLeave(5);
            //Console.ReadLine();
        }
    }

   // public abstract class ILeaveRequestHandler
    public interface ILeaveRequestHandler
    {
        //public ILeaveRequestHandler nextHandler;
        //public ILeaveRequestHandler NextHandler { get; set; }
         ILeaveRequestHandler NextHandler { get;}
        //public void SetNextHandler(ILeaveRequestHandler nextHandler)
        //{
        //    NextHandler = nextHandler;
        //}
        public void HandleRequest(int days);
        
    }

    public class HR : ILeaveRequestHandler
    {
        public ILeaveRequestHandler NextHandler => null;
        public void HandleRequest(int days)
        {
            Console.WriteLine("\n ****** HR ******");
            Console.WriteLine("Leave request for : " + days + "days. Approve ? ");
            if(Console.ReadLine().Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                Console.WriteLine(days + " days of leave approved by HR");
            else
                Console.WriteLine(days + " days of leave rejected by HR");
        }
    }
    
    public class ProjectManager : ILeaveRequestHandler
    {
        public ILeaveRequestHandler NextHandler => new HR();

        public void HandleRequest(int days)
        {
            
            if(days>=3 && days < 5)
            {
                Console.WriteLine("\n ****** Project Manager ******");
                Console.WriteLine("Leave request for : " + days + "days. Approve ? ");
                if (Console.ReadLine().Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine(days + " days of leave approved by Project Manager");
                else
                    Console.WriteLine(days + " days of leave rejected by Project Manager");
            }
            
            else
            {
                NextHandler.HandleRequest(days);
            }
        }
    }
    public class Supervisor : ILeaveRequestHandler
    {
        public ILeaveRequestHandler NextHandler => new ProjectManager();

        public void HandleRequest(int days)
        {
            if (days < 3)
            {
                Console.WriteLine("\n ****** Supervisor ******");
                Console.WriteLine("Leave request for : " + days + "days. Approve ? ");
                if (Console.ReadLine().Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                    Console.WriteLine(days + " days of leave approved by Supervisor");
                else
                    Console.WriteLine(days + " days of leave rejected by Supervisor");
            }
            
            else
            {
                NextHandler.HandleRequest(days);
            }
        }
        
    }

    public class LeaveRequest
    {
        public string Employee { get; set; }
        public int LeaveDays { get; set; }
        //HR hr = new HR();
        //ProjectManager projectManager = new ProjectManager();
        //Supervisor supervisor = new Supervisor();
        //public LeaveRequest()
        //{
        //    supervisor.SetNextHandler(projectManager);
        //    projectManager.SetNextHandler(hr);
        //}
        //public void ApplyLeave(int days)
        //{
        //    supervisor.HandleRequest(days);
        //}
     
    }
}
