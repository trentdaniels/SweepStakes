using System;
using System.Collections.Generic;

namespace SweepStakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        // Member Variables
        private Queue<Sweepstakes> queue;

        public Queue<Sweepstakes> Queue { get => queue; set => queue = value; }

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

        public void DisplaySweepstakes()
        {
            foreach (Sweepstakes sweepstake in queue)
            {
                Console.WriteLine("Here are your current sweepstakes:");
                Console.WriteLine(sweepstake);
            }
        }
    }
}
