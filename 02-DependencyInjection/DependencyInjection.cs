using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ReflectOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * How to use DependencyInjection:
             * must using Microsoft.Extensions.DependencyInjection;
             * Dependency Injection has a container(ServiceCollection ), we can put type and interface into this container.
             */

            // ServiceCollection is a containter
            var ServiceContainter = new ServiceCollection();
            // register type in Service Containter
            ServiceContainter.AddScoped(typeof(ITank), typeof(MyTank));
            ServiceContainter.AddScoped(typeof(IVehicle),typeof(Car));
            ServiceContainter.AddScoped<Driver>();
            // define a Service Provider provide type information which registed in service containter
            var ServiceProvider = ServiceContainter.BuildServiceProvider();

            // Injection type from service containter to Implement
            ITank tank=ServiceProvider.GetService<ITank>();
            var driver = ServiceProvider.GetService<Driver>();

        }

        interface IVehicle
        {
            void Run();
            void Stop();
        }

        class Driver
        {
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
