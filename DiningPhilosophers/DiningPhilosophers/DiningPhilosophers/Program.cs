using System;
using System.Collections.Generic;
using System.Threading;

namespace DiningPhilosophers
{
    struct PhilosopherInfo
    {
        public PhilosopherInfo(Dictionary<int,string> chopsticks, int number, bool isRighthanded)
        {
            Chopsticks = chopsticks;
            Number = number;
            IsRighthanded = isRighthanded;
        }
        Dictionary<int,string> Chopsticks;
        int Number;
        bool IsRighthanded;
    }

    class Philosopher
    {
        private PhilosopherInfo Info;
        private volatile string _state;
        public string State
        {
            get { return _state; }
            private set { _state = value; }

        }

        public Philosopher(PhilosopherInfo info)
        {
            Info = info;
            State = "Born";
        }
        public void Live(object iterationsCount)
        {
            int iterations = (int) iterationsCount;
            while (iterations == -1 || iterations-- > 0)
            {
                State = "Live" + iterations;
                Console.WriteLine(State);
            }
        }
        public void Live()
        {
            Live(-1);
        }
    }

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
