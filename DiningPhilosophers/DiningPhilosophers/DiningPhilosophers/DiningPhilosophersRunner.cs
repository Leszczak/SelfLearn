using System;
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
            Watcher watcher = new Watcher(chopsticks, philosophers);
            Thread watcherTread = new Thread(new ThreadStart(watcher.StartDisplaying));
            watcherTread.Start();
            foreach (Thread t in threads)
                t.Join();
            watcher.IsStop = true;
            watcherTread.Join();
        }
        /// <summary>
        /// Used with command lines arguments input for simpler parsing.
        /// Creates appropriate DiningPhilosophersRunner instance and runs it.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Starter(string[] args)
        {
            int philosophersNumber = 5;
            int iterationsNumber = 5;
            switch (args.Length)
            {
                default:
                    Console.WriteLine("Wrong arguments. Write -help for help.");
                    return;
                case 2:
                    try
                    {
                        iterationsNumber = int.Parse(args[1]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong arguments. Write -help for help.");
                        return;
                    }
                    goto case 1;
                case 1:
                    if (args[0].Equals("-help"))
                    {
                        Console.WriteLine("Non argument call defaults number of philosophers and iterations to 5.\n" +
                                            "First argument (int) sets number of philosophers.\n" +
                                            "Second argument (int) sets number of iterations.");
                        return;
                    }
                    else
                        try
                        {
                            philosophersNumber = int.Parse(args[0]);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Wrong arguments. Write -help for help.");
                            return;
                        }
                    break;
                case 0:
                    break;

            }
            new DiningPhilosophersRunner(3, 5).Run();
        }
    }
}
