using System;
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
        /// <summary>
        /// Main loop of the instance.
        /// </summary>
        /// <param name="iterationsCount"></param>
        public void Live(object iterationsCount)
        {
            int iterations = (int) iterationsCount;
            while (iterations-- > 0)
            {
                Eat();
                Think();
            }
        }
        /// <summary>
        /// Simulates eating by locking 2 nearest chopsticks for random amount of time.
        /// </summary>
        private void Eat()
        {
            //everybody but one person starts from right chopstick
            //this way there is no deadlock
            int firstChopstickNumber, secondChopstickNumber;
            if(Info.IsRighthanded)
            {
                firstChopstickNumber = (Info.Number + 1) % Info.Chopsticks.Count;
                secondChopstickNumber = Info.Number;
            }
            else
            {
                firstChopstickNumber = Info.Number;
                secondChopstickNumber = (Info.Number + 1) % Info.Chopsticks.Count;
            }

            State = "Taking first chopstick";
            lock (Info.Chopsticks[firstChopstickNumber])
            {
                Info.Chopsticks[firstChopstickNumber] = "taken";
                State = "Taking second chopstick";
                lock (Info.Chopsticks[secondChopstickNumber])
                {
                    Info.Chopsticks[secondChopstickNumber] = "taken";
                    State = "Eating";
                    Thread.Sleep(new Random().Next() % 1500 + 1500);
                    Info.Chopsticks[firstChopstickNumber] = "free";
                }
                Info.Chopsticks[firstChopstickNumber] = "free";
            }
        }
        /// <summary>
        /// Simulates thinking by sleeping for random amount of time.
        /// </summary>
        private void Think()
        {
            State = "Thinking";
            Thread.Sleep(new Random().Next() % 1500 + 1500);
        }
    }
}
