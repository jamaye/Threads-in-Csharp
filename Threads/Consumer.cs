using System;
using System.Threading;

namespace Producer_Consumer_Pattern
{
    public class Consumer
    {
        public SyncQueue queue;
        private int noJobs;
        private int producedJobs = 0;

        public Consumer(SyncQueue queue, int noJobs)
        {
            this.queue = queue;
            this.noJobs = noJobs;
        }

        public void run()
        {
            while (this.producedJobs < this.noJobs)
            {
                checkIdle();
                JobNode node = this.queue.pop();
                this.producedJobs++;
                this.sleep(node);
            }
            checkIdle();
            exit();
        }

        private void sleep(JobNode node)
        {
            long timeNow = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (Thread.CurrentThread.Name == "Consumer 1") {
                Console.WriteLine($"{Thread.CurrentThread.Name}: Finished Process #{node.id} for {node.time}ms " +
                    $"at {timeNow}");

            }else Console.WriteLine($"            {Thread.CurrentThread.Name}: Finished Process #{node.id} for {node.time}ms " +
                $"at {timeNow}");
            Thread.Sleep(node.time);
        }

        private void checkIdle() {
            if (queue.getCapacity() == 0)
            {
                if (Thread.CurrentThread.Name == "Consumer 1")
                {
                    Console.WriteLine("[Consumer 1: is idle ...");
                }
                else if (Thread.CurrentThread.Name == "Consumer 2")
                {
                    Console.WriteLine("                                [Consumer 2: is idle ...");
                }
            }
        }

        //Method that makes consumer exit
        public void exit()
        {
            if (Thread.CurrentThread.Name == "Consumer 1")
            {
                Console.WriteLine("[Consumer 1: Exited with " + noJobs + " processes.]");
            }
            else if (Thread.CurrentThread.Name == "Consumer 2")
            {
                Console.WriteLine("                                [Consumer 2: Exited with " + noJobs + " processes]");
            }
            Thread.CurrentThread.Interrupt();
        }
    }
}