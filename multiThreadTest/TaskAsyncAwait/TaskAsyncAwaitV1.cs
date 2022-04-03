using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class TaskAsyncAwaitV1
    {

        public TaskAsyncAwaitV1()
        {

            var task1 = Task.Run(() =>
             {
                 return Calculate1();
             });

            var task2 = Task.Run(() =>
             {
                 return Calculate2();
             });


            Task.WaitAll(task1, task2);

            var awaiter1 = task1.GetAwaiter();
            var awaiter2 = task2.GetAwaiter();

            var result1 = awaiter1.GetResult();
            var result2 = awaiter2.GetResult();

            Calculate3(result1, result2);

        }






        static int Calculate1()
        {

            Thread.Sleep(3000);
            Console.WriteLine("Calculating result1");
            return 100;
        }

        static int Calculate2()
        {
            Console.WriteLine("Calculating result2");
            return 200;
        }

        static int Calculate3(int result1, int result2)
        {
            Console.WriteLine("Calculating result3");
            return result1 + result2;
        }

    }
}
