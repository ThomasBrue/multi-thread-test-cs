using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyFirstProgram
{


    internal class ThreadExample1WithLock
    {
        static int Total = 0;


        public ThreadExample1WithLock()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();


            Thread thread1 = new Thread(ThreadExample1WithLock.AddOneMillion);
            Thread thread2 = new Thread(ThreadExample1WithLock.AddOneMillion);
            Thread thread3 = new Thread(ThreadExample1WithLock.AddOneMillion);


            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Total = " + Total);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);


        }

        static object _lock = new object();

        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                lock (_lock)
                {
                    Total++;

                }

            }
        }

    }
}




/*
 
C# Lock keyword ensures that one thread is executing a piece of code at one time. 
The lock keyword ensures that one thread does not enter a critical section of code while another thread is in that critical section. 

 */
