using EventFirstLook.Models;
using System;

namespace EventFirstLook
{
    // Events enable a class or object to notify other classes or objects when something of interest occurs.

    // An event is dependent on a delegate and cannot be created without delegates.
    // Event is a wrapper around delegate instance to prevent users of the delegate
    // from resetting the delegate and its invocation list and
    // only allows adding or removing targets from the invocation list.
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handlers.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            Car.CarEngineHandler d = CarExploded;
            c1.Exploded += d;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            // Remove CarExploded method from invocation list.
            c1.Exploded -= d;
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();            
        }

        static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }

        static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", msg);
        }

        static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}