using System;
using System.Collections.Generic;
using System.Threading;

namespace DiningPhilosophers
{
    class Watcher
    {
        Dictionary<int, string> chopsticks;
        List<Philosopher> philosophers;
        /// <summary>
        /// Set true to stop watcher tread
        /// </summary>
        public bool IsStop { set; get; }
        /// <summary>
        /// Refresh interval of info of chopsticks and philosophers states in seconds
        /// </summary>
        public int Interval { set; get; }
        public Watcher(Dictionary<int,string> chopsticks, List<Philosopher> philosophers)
        {
            this.chopsticks = chopsticks;
            this. philosophers = philosophers;
            IsStop = false;
            Interval = 1;
        }
        /// <summary>
        /// Starts displaying information in set intervals till ISStop is true.
        /// </summary>
        public void StartDisplaying()
        {
            while(!IsStop)
            {
                Console.WriteLine("---------------------------------------");
                foreach (KeyValuePair<int, string> p in chopsticks)
                    Console.WriteLine($"Chopstick {p.Key} is {p.Value}");
                foreach (Philosopher p in philosophers)
                    Console.WriteLine($"Philosopher {p.Info.Number} is {p.State}");
                Thread.Sleep(Interval * 1000);
            }
        }
    }
}
