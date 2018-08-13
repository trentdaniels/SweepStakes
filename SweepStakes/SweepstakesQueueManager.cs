using System;
using System.Collections.Generic;
using System.Linq;

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
            DisplaySweepstakes();
            Console.WriteLine("Which sweepstake would you like to go to?");
            string selectedSweepstake = Console.ReadLine();
            for (int i = 0; i < queue.Count; i++)
            {
                if (selectedSweepstake.ToLower() == queue.ElementAt(i).Name.ToLower())
                {
                    return queue.ElementAt(i);
                }
            }
            UserInterface.DisplayErrorMessage();
            return GetSweepstakes();
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
                Console.WriteLine(sweepstake.Name);
            }
        }
    }
}
