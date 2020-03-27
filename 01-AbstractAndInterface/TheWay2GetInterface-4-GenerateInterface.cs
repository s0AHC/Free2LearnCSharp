using system;

namespace GenerateInterface
{
    class program
    {
        static void Main(string[] args)
        {
            IVehicle myvhicle=new truck();
            myvhicle.running();
            IVehicle yourv=new Car();
            yourv.stopped();
            IVehicle hisv=new bus();
            hisv.fillingfuel();
        }        
    }
    
    /*
        how about Vehicle all methods set as virtual? We will introduce Interface
        如果把Vehicle全部的方法都改成虚方法呢？这时Interface就诞生了        
    */
    interface IVehicle
    {
        public void running();    
        public void stopped();
        public void fillingfuel();
    }

    abstract class Vehicle:IVehicle
    {
        public virtual void running()
        {
             Console.WriteLine("Method for vehicle running...");
        }    
        public virtual void stopped()
        {
            System.Console.WriteLine("Method for Vehicle stopped...");            
        } 

        abstract void fillingfuel();
    }

    class Car:Vehicle
    {
         public override void running()
         {
             Console.WriteLine("Method for car running...");
         }    
         public override void stopped()
         {
            System.Console.WriteLine("Method for car stopped...");            
         } 

        /* 
            fillingfule must be implemented in derived class otherwise derived class should be
            set as abstract
            子类如果不实现基类的abstract方法则子类也必须变成abstract
        */
        public override void fillingfule()
        {
            System.Console.WriteLine("car is filling fuel");
        }
    }

    class truck:Vehicle
    {
        public override void running()
        {
            Console.WriteLine("Method for truck running...");
        }    
        public override void stopped()
        {
            System.Console.WriteLine("Method for truck stopped...");            
        } 

        /* 
            fillingfule must be implemented in derived class otherwise derived class should be
            set as abstract
            子类如果不实现基类的abstract方法则子类也必须变成abstract
        */
        public override void fillingfule()
        {
            System.Console.WriteLine("truck is filling fuel");
        }
    }

    class bus :vehicle
    {
        public override void running()
        {
            Console.WriteLine("Method for bus running...");
        }    
        public override void stopped()
        {
            System.Console.WriteLine("Method for bus stopped...");            
        } 
        public override void fillingfule()
        {
            System.Console.WriteLine("bus is filling fuel");
        }
    }
}