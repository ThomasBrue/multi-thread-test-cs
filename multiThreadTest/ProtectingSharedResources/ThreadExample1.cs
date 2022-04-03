using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{


    internal class ThreadExample1
    {
        static int Total = 0;


        public ThreadExample1()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();


            Thread thread1 = new Thread(ThreadExample1.AddOneMillion);
            Thread thread2 = new Thread(ThreadExample1.AddOneMillion);
            Thread thread3 = new Thread(ThreadExample1.AddOneMillion);


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

        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Total++;
            }
        }





    }
}
