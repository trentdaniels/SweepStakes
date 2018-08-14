using System;
using System.Collections.Generic;
using System.Linq;

namespace SweepStakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        // Member Variables
        private Stack<Sweepstakes> stackOfSweepstakes;

        public Stack<Sweepstakes> StackOfSweepstakes { get => stackOfSweepstakes; set => stackOfSweepstakes = value; }

        // Constructors
        public SweepstakesStackManager()
        {
            stackOfSweepstakes = new Stack<Sweepstakes>();
        }

        // Methods
        public Sweepstakes GetSweepstakes()
        {
            DisplaySweepstakes();
            Console.WriteLine("Which sweepstake would you like to go to?");
            string selectedSweepstake = Console.ReadLine();
            for (int i = 0; i < stackOfSweepstakes.Count; i++)
            {
                if (selectedSweepstake.ToLower() == stackOfSweepstakes.ElementAt(i).Name.ToLower())
                {
                    return stackOfSweepstakes.ElementAt(i);
                }
            }
            UserInterface.DisplayErrorMessage();
            return GetSweepstakes();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stackOfSweepstakes.Push(sweepstakes);
        }

        public void DisplaySweepstakes()
        {
            Console.WriteLine("Here are your current sweepstakes:");
            foreach(Sweepstakes sweepstake in stackOfSweepstakes)
            {
                Console.WriteLine(sweepstake.Name);
            }
        }









    }
}
