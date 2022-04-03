using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class MutexDemo
    {

        static Mutex _mutex = new Mutex();

        public MutexDemo()
        {
            new Thread(Write).Start();
            new Thread(Write).Start();
            //new Thread(Write).Start();
            //new Thread(Write).Start();

            Console.ReadKey();
        }

        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Start: _mutex.WaitOne()");
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting: Sleep (performing a long process)");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} End: _mutex.ReleaseMutex()");
            _mutex.ReleaseMutex();

        }

    }
}
