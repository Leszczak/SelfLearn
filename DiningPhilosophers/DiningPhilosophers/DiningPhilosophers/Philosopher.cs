using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers
{
    class Philosopher
    {
        public PhilosopherInfo Info { get; private set; }
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
            int iterations = (int)iterationsCount;
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
}
