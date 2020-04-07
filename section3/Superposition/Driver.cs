using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Superposition
{
    class Driver
    {
        static int NUMBER_OF_RUNS = 10_000;
        static void Main(string[] args)
        {
            var ones = 0;
            
            using (var qsim = new QuantumSimulator())
            {
               for(var i = 0; i <= NUMBER_OF_RUNS; i++)
               {
                   var result = Superposition.Run(qsim).Result;
                   if (result == Result.One) ones++;
               }
            }
            Console.WriteLine("Collapsed State");
            Console.WriteLine($"\t  One: {((double) ones / NUMBER_OF_RUNS) * 100.0D}%");
            Console.WriteLine($"\t Zero: {((double) (NUMBER_OF_RUNS - ones) / NUMBER_OF_RUNS) * 100.0D}%");
        }
    }
}