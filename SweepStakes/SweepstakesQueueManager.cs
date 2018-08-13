using System;
using System.Collections.Generic;

namespace SweepStakes
{
    public class SweepstakesQueueManager : Manager, ISweepstakesManager
    {
        // Member Variables
        private Queue<Sweepstakes> queue;

        public Queue<Sweepstakes> Queue { get => queue; set => queue = value; }

        // Constructors
        public SweepstakesQueueManager()
        {
            queue = new Queue<Sweepstakes>();
            DisplaySweepstakesManagerMenu();
        }

        // Methods
        public override Sweepstakes GetSweepstakes()
        {

            Sweepstakes newSweepstakes;
            string newSweepstakesName = UserInterface.GetSweepstakesName();
            newSweepstakes = new Sweepstakes(newSweepstakesName);
            return newSweepstakes;


        }

        public override void InsertSweepstakes(Sweepstakes sweepstakes)
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
