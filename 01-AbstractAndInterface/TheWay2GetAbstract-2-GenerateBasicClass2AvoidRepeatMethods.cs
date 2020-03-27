using system;

namespace AbstractClass
{
    class program
    {
        static void Main(string[] args)
        {
            Vehicle myvhicle=new truck();
            myvhicle.running();
            Vehicle yourv=new Car();
            yourv.stopped();
            Vehicle hisv=new bus();
            hisv.fillingfuel();
            /*
                Vehicel never been instance，how to deal with this?
                Vehicel从未被实例化，如何处理?
            */

        }        
    }
    /*
        in below code running and stopped method repeated，how to optimize it
        下面的代码中您发现running和stopped方法重复了,如何去优化呢？
        Generate basic class and put methods in then virtual methods for derived method override
        生成基类把方法虚化,由子类重写
    */
    
    class Vehicle
    {
        public virtual void running()
        {
             Console.WriteLine("Method for vehicle running...");
        }    
        public virtual void stopped()
        {
            System.Console.WriteLine("Method for Vehicle stopped...");            
        } 

        public virtual void fillingfuel()
        {
            System.Console.WriteLine("Vehicle is filling fuel...");

        }
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
    }

    class bus:vehicle
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