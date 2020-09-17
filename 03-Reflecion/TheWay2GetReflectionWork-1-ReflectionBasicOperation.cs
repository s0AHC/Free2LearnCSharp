using System;
using System.Reflection;
namespace ReflectOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * normal interface
                IVehicle vehicle = new Car();
                Driver driver = new Driver(vehicle);
                driver.Drive();
             */


            //*reflection operate

          ITank _tank = new MyTank();

            //get mate data of tank's type
            var tank = _tank.GetType();

            //reflection the methods of MyTank type, Activator.CreateInstance(VariableName) is a syntax for relection
            object otank = Activator.CreateInstance(tank);
            // If you want to use the "MethodInfo", you must add Microsoft.Extention.DependenceInjection in NuGet
            MethodInfo FireMethod = tank.GetMethod("Fire");
            MethodInfo RunMethod = tank.GetMethod("Run");
            //Invoke run and fire methods
            FireMethod.Invoke(otank,null);
            RunMethod.Invoke(otank, null);   
        }

        interface IVehicle
        {
            void Run();
            void Stop();
        }

        class Driver
        {
            
            int IntField=20;
            private IVehicle _vehicle;
            public Driver(IVehicle vehicle)
            {
                _vehicle = vehicle;
            }

            public void Drive()
            {
                _vehicle.Run();
            }
        }

        interface IWeapon
        {
            void Fire();
        }

        class Car : IVehicle
        {
            public void Run()
            {
                Console.WriteLine("Car running ...");
            }

            public void Stop()
            {
                Console.WriteLine("Car stopped ...");
            }
        }

        interface ITank: IVehicle, IWeapon
        {
            //void Fire();
            //void Stop();
            //void Run();
        }

        class MyTank : ITank
        {
            public void Fire()
            { 
                Console.WriteLine("Tank firing ...");
            }

            public void Run()
            {
                Console.WriteLine("Tank running ...");
            }

            public void Stop()
            {
                Console.WriteLine("Tank stopped");
            }
        }
    }
}
