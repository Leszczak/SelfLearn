using System;
using System.Collections.Generic;
using System.Threading;

namespace DiningPhilosophers
{
    class Program
    {
        static int threadCount = 5;
        static void Main(string[] args)
        {
            Dictionary<int, string> chopsticks = new Dictionary<int, string>();
            List<Philosopher> philosophers = new List<Philosopher>();
            for(int i=0;i<threadCount;i++)
            {
                chopsticks[i] = "free";
                philosophers.Add(new Philosopher(new PhilosopherInfo(chopsticks, i, true)));
            }
            foreach (Philosopher p in philosophers)
                new Thread(new ParameterizedThreadStart(p.Live)).Start(5);

        }
    }
}
