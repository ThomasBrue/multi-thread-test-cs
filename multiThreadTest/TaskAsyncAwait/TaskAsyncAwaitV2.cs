using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class TaskAsyncAwaitV2
    {

        public TaskAsyncAwaitV2()
        {

            var task1 = Task.Run(() =>
             {
                 return Calculate1();
             });

            var awaiter1 = task1.GetAwaiter();


            // Callback Function
            awaiter1.OnCompleted(() =>
            {
                var result1 = awaiter1.GetResult();
                Calculate2(result1);
            });

            Calculate3();

            Thread.Sleep(4000);
        }


        static int Calculate1()
        {

            Thread.Sleep(3000);
            Console.WriteLine("Calculating result1");
            return 100;
        }

        static int Calculate2(int result1)
        {
            Console.WriteLine("Calculating result2");
            return result1 * 2;
        }

        static int Calculate3()
        {
            Console.WriteLine("Calculating result3");
            return 300;
        }

    }
}
