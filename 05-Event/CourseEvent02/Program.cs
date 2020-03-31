using System;

namespace CourseEvent02
{    
    /*
        Step 6. Define Event handler delegate: remeber we use delegate to subscribe the Event.
            a. In the arguments list we use the HereIsEventSource to specify the event source, 
            b. the EventArgs specified which information should be send to event responder
        第六步. 定义事件处理器委托：记住我们使用代理来订阅事件
            a. 我们在代理的参数列表中指定事件拥有者
            b. 同样在代理的参数列表中指定传入的事件参数
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

    /*
        Event belong to the event source, we generate event inside the Event Source，so first we need event source
        事件属于事件拥有者，如果我们要有事件就必须在事件拥有者内部定义事件，所以首先我们要有事件拥有者

        Step 1. Define an Event source: This class define a event source
        第一步. 定义一个事件拥有者：下面这个class用于定义一个事件拥有者
    */ 
    public class HereIsEventSource
    {
        /*
            Step 2. We define a event handler delegate's field. We'll define event handler delegate in Step 6
            第二步. 我们声明一个事件处理器的字段；当然, 现在这个事件处理器还不存在，我们在后面需要定义(见第6步 )
        */
        private DelegateEventHandler delegateEventHandler;

        /*
            Step 3. Event: Define event, and specified this event constraint by which Event Handler delegate
            第三步. 事件: 生成事件，并指定此事件受哪个事件处理器代理的约束
            Attentino: 
                1. Define event must have event keyword
                2. Must specified constraint by which event handler
                3. Event must has the add and remove methods.
            注意: 
                1. 定义事件必须用event关键字
                2. 必须指定由那个事件处理器约束
                3. 必须包含add和remove方法
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

        /*
            Step 4. Event source owned the event，so should define an event trigger method inside the event source
                    So please don't forget to generate an action to trigger event
            第四步. 事件要能发送消息，请别忘了在事件拥有者中建一个方法用于事件触发       
        */        
        public void EventSourceAction4TriggerEvent()
        {
            // Before you do something make sure the event handler existed!
            if(this.delegateEventHandler!=null)
            {
                // Pass event parameters，we will generate Event Args properties class at Step 7
                // 传入事件参数，当然现在还没有Event args的属性类，我们将在第7步定义一个Event参数属性类
                EventNameEventArgs e=new EventNameEventArgs();
                e.FirstArgs="You deal wiht 1st args";
                e.SecondArgs="You deal with 2nd args";

                // Event handler invoke
                // 例用事件处理器调用
                this.delegateEventHandler.Invoke(this,e);
            }
        }
    }

    // Step 5. Event subscriber( or be called event responder)，subscriber do something when it get event message from event source 
    // 第五步. 事件订阅者 (或者称为事件响应者 )，订阅者对订阅的事件做出反应(或者说动作 )
    public class EventSubcriber
    {
        // Due to subscribe event via delegate, so the method's signature must same as eventhandler delegate
        //  - eventSource tells EventSubscriber do for which Event Source
        //  - tell EventSubscriber the action should base on which parameters 
        public void SubscriberDoSomthing(HereIsEventSource eventSource,EventNameEventArgs e)
        {
            System.Console.WriteLine($"Event Suberscriber do something after Event source trigger the event!");
            System.Console.WriteLine($"Do something with 1st agrs: {e.FirstArgs} ");
            System.Console.WriteLine($"Do something with 2nd agrs: {e.SecondArgs} ");
        }
    }

    // Step 7. Define details arguments for event, this class should derived from EventArgs
    // 第7步. 定义Event的属性类，明确传入的参数；这个类派生自EventArgs
    public class EventNameEventArgs:EventArgs
    {
        public string FirstArgs{get;set;}
        public string SecondArgs{get;set;}
    }
}
