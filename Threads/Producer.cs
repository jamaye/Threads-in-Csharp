using System;
using System.Threading;

namespace Producer_Consumer_Pattern
{
  public class Producer{
    public SyncQueue queue;
    private int noJobs;
    private int producedJobs = 0;

    public Producer(SyncQueue queue, int noJobs ){
      this.queue = queue;
      this.noJobs = noJobs;
    }

    public void run(){
      while(this.producedJobs < this.noJobs){
        Console.WriteLine($"\n  Producer: [Adding Jobs to the queue] \n");
        Array.ForEach(this.getNodes(queue.getCapacity()), node => queue.push(node));
        Console.WriteLine($"    Producer: [{this.queue.getCapacity()} Jobs in the queue]\n");

                if (producedJobs >= noJobs) {
                    Console.WriteLine("\n   Producer: [Done adding jobs.]\n");
                }else this.sleep();

        
      }
    }

    private JobNode[] getNodes(int numOfNodes){
      JobNode[] nodes = new JobNode[numOfNodes];
      Random rand = new Random();
      for(int i = 0; i < numOfNodes; i++){
        nodes[i] = new JobNode(
          producedJobs+1,
          rand.Next(
            100,
            500
          ));
        producedJobs++;
      }
      return nodes;
    }

    private void sleep(){
      Random rand = new Random();
      int sleepTime = rand.Next(
          1000,
          5000 
      );

      Thread.Sleep(sleepTime);
    }
  }
}