using system;

namespace AbstractClass
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellow World!");
        }        
    }
    /*
        in below code running and stopped method repeated，how to optimize it
        下面的代码中您发现running和stopped方法重复了,如何去优化呢？

    */
    
    class Car
    {
         public void running()
         {
             Console.WriteLine("Method for car running...");
         }    
         public void stopped()
         {
            System.Console.WriteLine("Method for car stopped...");            
         } 
    }

    class truck
    {
        public void running()
        {
            Console.WriteLine("Method for truck running...");
        }    
        public void stopped()
        {
            System.Console.WriteLine("Method for truck stopped...");            
        } 
    }

    class bus
    {
        public void running()
        {
            Console.WriteLine("Method for bus running...");
        }    
        public void stopped()
        {
            System.Console.WriteLine("Method for bus stopped...");            
        } 
    }

}