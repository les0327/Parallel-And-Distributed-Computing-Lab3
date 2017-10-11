using System;
using System.Threading;

namespace ParallelAndDistributedComputingLab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = 2000;
            Threads threads = new Threads(size);
            
            Thread t1 = new Thread(threads.Task1, 1000);
            Thread t2 = new Thread(threads.Task2, 1000);
            Thread t3 = new Thread(threads.Task3, 1000);

            t1.Name = "Task1";
            t2.Name = "Task2";
            t3.Name = "Task3";
            
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Normal;
            t3.Priority = ThreadPriority.Lowest;
            
            Console.WriteLine("Main start");
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Main finish");
        }
    }
}