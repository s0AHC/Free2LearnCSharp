using System;

namespace CourseEvent02
{    
    /*
        4. Event handler delegate: remeber we use delegate to subscribe the Event.
            a. In the arguments list we use the HereIsEventSource to specify the event source, 
            b. the EventArgs specified which information should be send to event responder 
    */
    public delegate void DelegateEventHandler(HereIsEventSource eventSource, EventNameEventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            HereIsEventSource eventSource=new HereIsEventSource();
            EventResponder eventResponder=new EventResponder();
            eventSource.EventName+=eventResponder.Action;
             
        }
    }

    // Define details arguments for event, this class should derived from EventArgs
    public class EventNameEventArgs:EventArgs
    {

        public string FirstArgs{get;set;}
        public string SecondArgs{get;set;}
    }

    // 1. Event source: This class define a event source
    public class HereIsEventSource
    {
        /*
            Event below to the event source, so we generate event inside the Event Source
                Firstly we define a event handler delegate's field.
                首先我们声明一个事件处理器的字段
        */ 
        private DelegateEventHandler delegateEventHandler;

        /*
            2. Event: generate event, and specified this event constraint by which Event Handler delegate
            2. 事件: 生成事件，并指定此事件受哪个事件处理器代理的约束
        */
        public event DelegateEventHandler EventName
        {
            add
            {
                this.delegateEventHandler+=value;
            }
            remove
            {
                this.delegateEventHandler-=value;
            }
        }
    }

    public class EventResponder
    {
        public void Action(HereIsEventSource eventSource,EventNameEventArgs e)
        {
            System.Console.WriteLine(   "do something!");
        }
    }
}
