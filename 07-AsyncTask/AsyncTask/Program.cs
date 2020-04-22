using System;
using System.Threading;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. introduce taskpool: you can't control task's processing sequenance
            for (int i = 1; i <=10; i++)
            {
                //ThreadPool执行任务, 你无法控制处理的顺序，乱序的。
                //System.Console.WriteLine($"Task No.:{i}" );
                ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {
                    Console.WriteLine($"in taskpool: 第{obj}个执行任务");
                }),i);
            }
            Console.ReadKey();            
        }
    }
}
