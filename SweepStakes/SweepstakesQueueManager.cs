using System;
using System.Collections.Generic;

namespace SweepStakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        // Member Variables
        private Queue<Sweepstakes> queue;

        // Constructors
        public SweepstakesQueueManager()
        {
            queue = new Queue<Sweepstakes>();
        }

        // Methods
        public void GetSweepstakes()
        {
            
        }

        public Sweepstakes InsertSweepstakes(Sweepstakes sweepstakes)
        {
            
        }
    }
}
