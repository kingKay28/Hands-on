using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonDBCon
{
    class DBConn
    {
        private static DBConn instance;
        private int count = 0;

        //restricting to create multiple instances using "new" keyword 
        private DBConn()
        {
            count++;
            Console.WriteLine("Count from DBconn constructor : " + count);
            //code to create data base connection
        }

        private static object syncLock = new object();
        public static DBConn Instance
        {
            get{
                lock (syncLock)       
                {
                    if (DBConn.instance == null)
                        DBConn.instance = new DBConn();
                    return DBConn.instance;
                }
            
            }
        }
        
        public void CallerMethod(int i)
        {
             //int i = 0;
            Console.WriteLine("Counter is at " + i + " times");

        }
    }
}
