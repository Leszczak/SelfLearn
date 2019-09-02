using System.Collections.Generic;
using System.Threading;

namespace DiningPhilosophers
{
    class DiningPhilosophersRunner
    {
        private int numberOfPhilosophers;
        private int numberOfRuns;
        private Dictionary<int, string> chopsticks;
        private List<Philosopher> philosophers;
        public DiningPhilosophersRunner(int numberOfPhilosophers, int numberOfRuns)
        {
            this.numberOfPhilosophers = numberOfPhilosophers;
            this.numberOfRuns = numberOfRuns;
            chopsticks = new Dictionary<int, string>();
            philosophers = new List<Philosopher>();
            Setup();
        }
        /// <summary>
        /// Sets right number of chopsticks and philosophers (lat one is left-handed)
        /// </summary>
        private void Setup()
        {
            for (int i = 0; i < numberOfPhilosophers; i++)
            {
                chopsticks.Add(i, "free");
                philosophers.Add(new Philosopher(new PhilosopherInfo(chopsticks, i, true)));
            }
            philosophers[philosophers.Count - 1].Info.IsRighthanded = false;
        }
        /// <summary>
        /// Runs whole simulation, ends after number of cycles given in constructor
        /// </summary>
        public void Run()
        {
            List<Thread> threads = new List<Thread>();
            foreach (Philosopher p in philosophers)
                threads.Add(new Thread(new ParameterizedThreadStart(p.Live)));
            foreach (Thread t in threads)
                t.Start(numberOfRuns);
            foreach (Thread t in threads)
                t.Join();
        }
    }
}
