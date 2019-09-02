using System;
using System.Collections.Generic;
using System.Text;

namespace DiningPhilosophers
{
    class PhilosopherInfo
    {
        public PhilosopherInfo(Dictionary<int, string> chopsticks, int number, bool isRighthanded)
        {
            Chopsticks = chopsticks;
            Number = number;
            IsRighthanded = isRighthanded;
        }
        Dictionary<int, string> Chopsticks;
        int Number;
        public bool IsRighthanded { get; set; }
    }
}
