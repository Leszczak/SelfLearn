using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            int iterations = (int) iterationsCount;
            while (iterations-- > 0)
            {
                Eat();
                Think();
            }
        }
        private void Eat()
        {
            State = "Eating";
            Thread.Sleep(3000);
        }
        private void Think()
        {
            State = "Thinking";
            Thread.Sleep(3000);
        }
    }
}
