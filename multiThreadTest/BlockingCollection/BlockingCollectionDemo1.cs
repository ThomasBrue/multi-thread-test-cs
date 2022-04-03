using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class BlockingCollectionDemo1
    {

        public BlockingCollectionDemo1()
        {
            new Thread(Producer).Start();
            new Thread(Consumer).Start();

            Console.ReadKey();
        }

        private static BlockingCollection<int> data = new BlockingCollection<int>(3);



        private static void Producer()
        {
            for (int ctr = 0; ctr < 10; ctr++)
            {
                data.Add(ctr);
                Thread.Sleep(200); // Process that takes 200 ms to finish
            }
        }

        private static void Consumer()
        {
            foreach (int item in data.GetConsumingEnumerable())
            {
                Console.WriteLine(item);
            }
        }

    }
}


/*


Consider a scenario where multiple threads would be reading and writing to a queue. 

More specifically, you might have at the same point of time, 
multiple producers storing data and multiple consumers retrieving them from a common data store. 

Hence, you would need a proper synchronization mechanism so as to synchronize the access to this data.

Here's exactly where the BlockingCollection class comes to the rescue. 

Although there are many other ways, 
this class provides one of the most efficient ways to synchronize access to your data.




What is a BlockingCollection?

The BlockingCollection is a thread-safe collection in which you can have multiple threads add and remove data concurrently. 
It is represented in .Net through the BlockingCollection class; you can use this class to implement a producer-consumer pattern.



Explanation from the Microsoft Page:

Multiple threads or tasks can add items to the collection concurrently, 
and if the collection reaches its specified maximum capacity, 
the producing threads will block until an item is removed. 

Multiple consumers can remove items concurrently, 
and if the collection becomes empty, 
the consuming threads will block until a producer adds an item.


 */