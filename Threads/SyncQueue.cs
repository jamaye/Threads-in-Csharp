using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Producer_Consumer_Pattern
{
  public class SyncQueue{
  
  private Queue<JobNode> q = new Queue<JobNode>();
  private int size;
  object locker = new object();

  public SyncQueue(int size){
    this.size = size;
  }

  public int getCapacity(){
    return this.size;
  }

  public JobNode pop(){
    JobNode item = new JobNode();
    lock(locker){
      while(q.Count == 0) Monitor.Wait(locker);
      item = q.Dequeue();
      Monitor.PulseAll(locker);
    }
    return item;
  }

  public void push(JobNode item){
    lock(locker){
      while (q.Count > this.size) Monitor.Wait(locker);
      q.Enqueue(item);
      Monitor.PulseAll(locker);
    }
  }

}
}