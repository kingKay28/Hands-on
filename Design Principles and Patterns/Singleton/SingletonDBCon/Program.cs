using System;

namespace SingletonDBCon
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine("Hello World!");
            DBConn conn1 = DBConn.Instance;
            DBConn conn2 = DBConn.Instance;
            conn1.CallerMethod(i++);
            conn2.CallerMethod(i++);
            Console.ReadLine();
        }
    }
}
