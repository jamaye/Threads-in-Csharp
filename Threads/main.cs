/*
 * CS490
 * Programming Assignment#2
 * Program by: Anupam Dahal and Janilou Sy
 * Revision Date: April 9, 2022
 */



using System;
using System.Threading;

namespace Producer_Consumer_Pattern
{

    class PMain
    {
        static void Main(string[] args)
        {
            SyncQueue queue = new SyncQueue(25);
            Producer producer = new Producer(queue, 75);
            Consumer consumer = new Consumer(queue, 75);
            //Console.Write("Adding Jobs");
            Thread t1 = new Thread(consumer.run);
            Thread t2 = new Thread(consumer.run);
            Thread t3 = new Thread(producer.run);
            t1.Name = "Consumer 1";
            t2.Name = "Consumer 2";
            t3.Name = "Producer";

            t1.Start();
            Console.WriteLine("     ...[Consumer 1: Just started.]...");       //
            t2.Start();
            Console.WriteLine("                        ...[Consumer 2: Just started.]....");
            t3.Start();
            Console.WriteLine("...[Producer: Just started.]...");

            //t3.Join();
            // Console.Write(producer.queue);
        }
    }

}