using System;
using System.Timers;

namespace CourseEvent01
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Event source: timer is an Event source.
            Timer timer=new Timer();  
            timer.Interval=1500;
            
            Class4MethedDoSomething c4ds=new Class4MethedDoSomething();

            // Eventhandler for multicast subscribe event, actually due to we use delegate to subscribe the event!
            Class4Multicast c4m =new Class4Multicast();
            
            // 2. Event: Elapsed就是timer这个事件拥有者的事件
            // 5. 事件订阅: boy.Action方法的作为事件处理器，订阅了timer的Elapsed事件。订阅符号是+=。
            timer.Elapsed+=c4ds.Action;
            // multicast subscribe event.
            timer.Elapsed+=c4m.Action;

            timer.Start();
            Console.ReadLine();
        }        
    }

    // 3. Event responder: event responder should has an Event handler to Subscribe the Event
    // 事件响应者，事件响应者应该有一个方法叫事件处理器用于订阅事件
    class Class4MethedDoSomething
    {
        // 4. Event handler: Action是Boy这个事件响应者的事件处理器方法
        internal void Action(object sender, ElapsedEventArgs e)
        {
            // Event handler: do somethings
            System.Console.WriteLine("I'm event handler, I subscriberred event 'timer.Elapsed', you saw this means I was called!");
        }
    }

    class Class4Multicast
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            System.Console.WriteLine("This is multicast, I subscriberrd event by delegate multicast!");
        }
    }
}
