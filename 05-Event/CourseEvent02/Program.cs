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
            // 1. event source: eventSource
            HereIsEventSource eventSource=new HereIsEventSource();
            // 3. Event subscriber: eventSubscriber
            EventSubcriber eventSubscriber=new EventSubcriber();
            // 2. Event: EventName    
            //                5. += subscribe the event 
            //                                     SubscriberDoSomthing: action after event triggerred
            eventSource.EventName+=eventSubscriber.SubscriberDoSomthing;
            eventSource.EventSourceAction4TriggerEvent();
             
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
            // The event should has both the add and remove methods.
            add
            {
                this.delegateEventHandler+=value;
            }
            remove
            {
                this.delegateEventHandler-=value;
            }
        }

        // Event owned by event source and should trigger in the event source
        // So please don't forget to generate an action to trigger event
        public void EventSourceAction4TriggerEvent()
        {
            // Before you do something make sure eventhandler existed!
            if(this.delegateEventHandler!=null)
            {
                EventNameEventArgs e=new EventNameEventArgs();
                e.FirstArgs="You deal wiht 1st args";
                e.SecondArgs="You deal with 2nd args";
                this.delegateEventHandler.Invoke(this,e);
            }
        }
    }

    // 3. Event subscriber( or be called event responder)
    public class EventSubcriber
    {
        // eventSource tells EventSubscriber do for who
        // e tell EventSubscriber the action should base on something 
        public void SubscriberDoSomthing(HereIsEventSource eventSource,EventNameEventArgs e)
        {
            System.Console.WriteLine($"Event Suberscriber do something after Event source trigger the event!");
            System.Console.WriteLine($"Do something with 1st agrs: {e.FirstArgs} ");
            System.Console.WriteLine($"Do something with 2nd agrs: {e.SecondArgs} ");
        }
    }
}
