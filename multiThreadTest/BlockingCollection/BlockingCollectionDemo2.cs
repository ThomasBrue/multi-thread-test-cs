using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class BlockingCollectionDemo2
    {

        public BlockingCollectionDemo2()
        {
            BlockingCollection<int> bc = new BlockingCollection<int>();

            // Spin up a Task to populate the BlockingCollection
            Task t1 = Task.Run(() =>
            {
                bc.Add(1);
                bc.Add(2);
                bc.Add(3);
                bc.CompleteAdding();
            });

            // Spin up a Task to consume the BlockingCollection
            Task t2 = Task.Run(() =>
            {
                try
                {
                    // Consume consume the BlockingCollection
                    while (true) Console.WriteLine(bc.Take());

                }
                catch (InvalidOperationException)
                {
                    // An InvalidOperationException means that Take() was called on a completed collection
                    Console.WriteLine("That's All!");
                }
            });

            Task.WhenAll(t1, t2);

        }
    }
}
