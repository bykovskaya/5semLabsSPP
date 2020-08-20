using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyThreadPool
{
    public class ThreadPool
    {
        public delegate void TaskHandler();

        private static object locked = new object();

        private readonly List<TaskHandler> blockingQueue = new List<TaskHandler>();

        public ThreadPool(uint count)
        {
            for (var i = 0; i < count; i++)
            {
                var thread = new Thread(StartWork);
                thread.Start();
            }
        }

        public void Enqueue(TaskHandler taskHandler)
        {
            lock (locked)
            {
                blockingQueue.Add(taskHandler);
            }
        }

        private void StartWork()
        {
            while (true)
            {
                TaskHandler task;

                lock (locked)
                {
                    task = blockingQueue.FirstOrDefault();

                    if (task == null)
                    {
                        continue;
                    }

                    blockingQueue.RemoveAt(0);
                }

                try
                {
                    task();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}