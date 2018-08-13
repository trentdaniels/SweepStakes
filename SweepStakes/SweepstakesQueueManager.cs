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
        public Sweepstakes GetSweepstakes()
        {

            Sweepstakes newSweepstakes;
            string newSweepstakesName = UserInterface.GetSweepstakesName();
            newSweepstakes = new Sweepstakes(newSweepstakesName);
            return newSweepstakes;


        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queue.Enqueue(sweepstakes);
        }
    }
}
