using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyFirstProgram
{


    internal class ThreadExample1WithMonitor
    {
        static int Total = 0;
        public ThreadExample1WithMonitor()
        {

            Thread thread1 = new Thread(ThreadExample1WithMonitor.AddOneMillion);
            Thread thread2 = new Thread(ThreadExample1WithMonitor.AddOneMillion);
            Thread thread3 = new Thread(ThreadExample1WithMonitor.AddOneMillion);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Total = " + Total);
        }

        static object _lock = new object();

        public static void AddOneMillion()
        {

            for (int i = 1; i <= 1000000; i++)
            {
                bool lockTaken = false;

                Monitor.Enter(_lock, ref lockTaken);
                try
                {
                    Total++;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
            }
        }

    }
}



/*

Monitor provides a mechanism that synchronizes access to objects. 
It can be done by acquiring a significant lock so that only one thread can enter in a given piece of code at one time. 

Monitor is no different from lock but the monitor class provides 
more control over the synchronization of various threads 
trying to access the same lock of code.
 
 */