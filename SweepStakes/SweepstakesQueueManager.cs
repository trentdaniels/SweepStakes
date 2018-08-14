using System;
using System.Collections.Generic;
using System.Linq;

namespace SweepStakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        // Member Variables
        private Queue<Sweepstakes> queueOfSweepstakes;

        public Queue<Sweepstakes> QueueOfSweepstakes { get => queueOfSweepstakes; set => queueOfSweepstakes = value; }

        // Constructors
        public SweepstakesQueueManager()
        {
            queueOfSweepstakes = new Queue<Sweepstakes>();
        }

        // Methods
        public Sweepstakes GetSweepstakes()
        {
            DisplaySweepstakes();
            Console.WriteLine("Which sweepstake would you like to go to?");
            string selectedSweepstake = Console.ReadLine();
            for (int i = 0; i < queueOfSweepstakes.Count; i++)
            {
                if (selectedSweepstake.ToLower() == queueOfSweepstakes.ElementAt(i).Name.ToLower())
                {
                    return queueOfSweepstakes.ElementAt(i);
                }
            }
            UserInterface.DisplayErrorMessage();
            return GetSweepstakes();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queueOfSweepstakes.Enqueue(sweepstakes);
        }

        public void DisplaySweepstakes()
        {
            foreach (Sweepstakes sweepstake in queueOfSweepstakes)
            {
                Console.WriteLine("Here are your current sweepstakes:");
                Console.WriteLine(sweepstake.Name);
            }
        }
    }
}
