using System;
using System.Threading;

namespace MyFirstProgram
{
    class SpinLockDemo
    {


        public SpinLockDemo()
        {
            Thread th = new Thread(process);
            th.Start();
        }


        SpinLock spLock = new SpinLock();
        public void process()
        {
            bool lockTaken = false;
            try
            {
                spLock.Enter(ref lockTaken);
                Console.WriteLine("process method acquire the lock::  (process will run for 2 seconds)");
                Thread.Sleep(2000);

            }
            finally
            {
                if (lockTaken) spLock.Exit();
                Console.WriteLine("process method Release the lock::");
            }
        }



    }


}


// Readme link for spinlocks
// https://www.c-sharpcorner.com/UploadFile/1d42da/spinlock-class-in-threading-C-Sharp/
