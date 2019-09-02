using System;
using System.Collections.Generic;
using System.Threading;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            new DiningPhilosophersRunner(2, 5).Run();
        }
    }
}
