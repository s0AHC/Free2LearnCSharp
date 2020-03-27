using System;
//using System.Threading.Channels;

namespace AbstractInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle ivCar=new Car();
            ivCar.Fill();
            IVehicle ivTruck= new Truck();
            ivTruck.Running();
            Screen s=new LED();
            s.PowerOn();
        } 
        interface IVehicle
        {
            void Running();
            void Stop();
            void Fill();
        }

        public abstract class Vehicle:IVehicle
        {
            public virtual void Running()
            {
                Console.WriteLine("RUN FROM INTERFACE...");
            }

            public virtual  void Stop()
            {
                Console.WriteLine("stop from interface...");
            }

            public abstract void Fill();
        }

        class Car : Vehicle
        {
            public override void Fill()
            {
                Console.WriteLine("Fill in abstract class Vehicle is a abstract method");
            }

            public override void Stop()
            {
                Console.WriteLine("stop in abstract class Vehicle is a virtual but not abstract method");
            }

            public override void Running()
            {
                Console.WriteLine("running in abstract class Vehicle is a virtual but not abstract method");
            }
        }

        class Truck : Vehicle
        {
            /*
             *
             * If doesn't implement abstract method Fill() which defined by abstract class Vehicle,
             * will remind "abstract method not implement "
             * 
             */

            public override void Fill()
            {
                Console.WriteLine("test");
            }

            public override void Stop()
            {
                Console.WriteLine("Truck stop in abstract class Vehicle is a virtual but not abstract method");
            }

            public override void Running()
            {
                Console.WriteLine("Truck running in abstract class Vehicle is a virtual but not abstract method");
            }
        }

        abstract class Screen
        {
            public abstract void Appear();
            public abstract void refresh();
            public abstract void PowerOn();
        }

        class LED:Screen
        {
            public override void Appear()
            {
                Console.WriteLine("Output: Implement abstract method Appear");
            }

            public override void refresh()
            {
                Console.WriteLine("Output: Implement abstract method Refresh");
            }

            public override void PowerOn()
            {
                Console.WriteLine("Conclusion: derived class must implement all methods those have been defined in abstract class");
            }
        }
    }
}