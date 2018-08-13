﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SweepStakes
{
    public class SweepstakesStackManager : Manager, ISweepstakesManager
    {
        // Member Variables
        private Stack<Sweepstakes> stack;

        public Stack<Sweepstakes> Stack { get => stack; set => stack = value; }

        // Constructors
        public SweepstakesStackManager()
        {
            stack = new Stack<Sweepstakes>();
            DisplaySweepstakesManagerMenu();
        }

        // Methods
        public override Sweepstakes GetSweepstakes()
        {
            DisplaySweepstakes();
            Console.WriteLine("Which sweepstake would you like to go to?");
            string selectedSweepstake = Console.ReadLine();
            for (int i = 0; i < stack.Count; i++)
            {
                if (selectedSweepstake.ToLower() == stack.ElementAt(i).Name.ToLower())
                {
                    return stack.ElementAt(i);
                }
            }
            UserInterface.DisplayErrorMessage();
            return GetSweepstakes();
        }

        public override void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }

        public void DisplaySweepstakes()
        {
            Console.WriteLine("Here are your current sweepstakes:");
            foreach(Sweepstakes sweepstake in stack)
            {
                Console.WriteLine(sweepstake.Name);
            }
        }









    }
}
