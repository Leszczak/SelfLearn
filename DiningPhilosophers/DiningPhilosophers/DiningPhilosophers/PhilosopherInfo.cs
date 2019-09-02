using System.Collections.Generic;

namespace DiningPhilosophers
{
    /// <summary>
    /// Wrapper class for all important information for Philosopher.
    /// </summary>
    class PhilosopherInfo
    {
        /// <summary>
        /// Wrapper for all important information for Philosopher.
        /// </summary>
        /// <param name="chopsticks">Dictionary containing chopstick to be used by philosopher</param>
        /// <param name="number">Philosopher's number</param>
        /// <param name="isRighthanded">Right-handed philosophers start eating by taking right chopstick, left-handed otherwise.
        ///                             Important for fighting death-locks.</param>
        public PhilosopherInfo(Dictionary<int, string> chopsticks, int number, bool isRighthanded)
        {
            Chopsticks = chopsticks;
            Number = number;
            IsRighthanded = isRighthanded;
        }
        public Dictionary<int, string> Chopsticks { get; private set; }
        public int Number { get; private set; }
        public bool IsRighthanded { get; set; }
    }
}
