using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class TaskAsyncAwaitV3
    {

        public TaskAsyncAwaitV3()
        {
            Test();
            Console.Read();
        }

        async static void Test()
        {
            await Calculate();
        }

        async static Task Calculate()
        {
            Calculate1_2();
            Calculate3();
        }

        async static void Calculate1_2()
        {
            var result1 = await Task.Run(() =>
            {
                return Calculate1();
            });

            Calculate2(result1);
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
