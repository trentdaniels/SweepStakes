using System;
using System.Collections.Generic;

namespace SweepStakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        // Member Variables
        private Stack<Sweepstakes> stack;

        // Constructors
        public SweepstakesStackManager()
        {
            stack = new Stack<Sweepstakes>();
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
            stack.Push(sweepstakes);
        }
    }
}
