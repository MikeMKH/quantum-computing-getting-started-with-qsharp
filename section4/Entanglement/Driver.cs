using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Entanglement
{
    class Driver
    {
        static int NUMBER_OF_RUNS = 10_000;
        static void Main(string[] args)
        {
            var ones = 0;
            var matched = 0;
            
            using (var qsim = new QuantumSimulator())
            {
                for(var i = 0; i <= NUMBER_OF_RUNS; i++)
                {
                    var (r1, r2) = Entanglement.Run(qsim).Result;
                    
                    if (r1 == Result.One) ones++;
                    if (r1 == r2) matched++;
                } 
            }
            Console.WriteLine("Collapsed State");
            Console.WriteLine($"\t  One: {((decimal) ones / NUMBER_OF_RUNS) * 100.000M}%");
            Console.WriteLine($"\t Zero: {(((decimal) NUMBER_OF_RUNS - ones) / NUMBER_OF_RUNS)  * 100.000M}%");
            Console.WriteLine($"\tMatch: {((decimal) matched / NUMBER_OF_RUNS) * 100.000M}%");
        }
    }
}