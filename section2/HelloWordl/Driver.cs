using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Simulators;

namespace HelloWordl
{
    class Driver
    {
        static void Main(string[] args)
        {
            using var qsim = new QuantumSimulator();
            HelloQ.Run(qsim).Wait();
        }
    }
}