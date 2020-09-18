using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1st Generation, Thread.
            //Thread.Sleep(200);

            // 2nd Generation Threadpool: readuce the thread creation, readuce the system resouce comsuption
            // Defects:  1. you can't control task's processing sequenance
            //          2. you can't get the thread status: cancel/ exception/ finish
            // for (int i = 1; i <=5; i++)
            // {
            //     // you can' to control sequence of thread inside the ThreadPool since it is out-of-order。
            //     // System.Console.WriteLine($"Task No.:{i}" ); try enable this one!!!
            //     ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {Console.WriteLine($"in taskpool: 第{obj}个执行任务");}),i);
            // }
            
            // 3rd generation: Task, there are three method to create and process task
            //  3.1 new a instance of Task，call Start() 
            Task taskMethod1 = new Task(() =>
                {
                    //Thread.Sleep(200);
                    Console.WriteLine($"1st method: new Task(Lambda expression), the thread id is {Thread.CurrentThread.ManagedThreadId}");
                }
            );
            taskMethod1.Start();

            //  3.2 Task.Factory.StartNew(Action action)
            Task taskMethod2 = Task.Factory.StartNew(() =>
            {
                //Thread.Sleep(200);
                Console.WriteLine($"2nd method: Task.Factory.StartNew(Lambda expression), the thread id is { Thread.CurrentThread.ManagedThreadId}");
            });

            //  3.3 put task in thread in queue by Task.Run(Action action), return and start a Task
            Task taskMethod3 = Task.Run(() =>
            {
                //Thread.Sleep(200);
                Console.WriteLine($"3rd method: Task.Run(Lambda expression)), the thread id is { Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("Process main thread!");          
        }
    }
}
