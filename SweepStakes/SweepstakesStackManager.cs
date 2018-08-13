using System;
using System.Collections.Generic;
using System.Linq;

namespace SweepStakes
{
    public class SweepstakesStackManager : ISweepstakesManager
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
        public Sweepstakes GetSweepstakes()
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

        public void InsertSweepstakes(Sweepstakes sweepstakes)
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


        public void DisplaySweepstakesManagerMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("[1]Create Sweepstake\n[2]Go To Sweepstake");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Sweepstakes newSweepstake = CreateSweepstake();
                    InsertSweepstakes(newSweepstake);
                    break;
                case "2":
                    Sweepstakes selectedSweepstake = GetSweepstakes();
                    DisplaySweepstakeMenu(selectedSweepstake);
                    break;
                default:
                    UserInterface.DisplayErrorMessage();
                    DisplaySweepstakesManagerMenu();
                    return;

            }
            DisplaySweepstakesManagerMenu();
            return;
        }


        public void DisplaySweepstakeMenu(Sweepstakes sweepstake)
        {
            Console.WriteLine($"Selected {sweepstake.Name}:");
            Console.WriteLine("What would you like to do?\n[1]Register Contestant\n[2]Pick Winner\n[3]Back to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    sweepstake.HandleContestant();
                    DisplaySweepstakeMenu(sweepstake);
                    return;
                case "2":
                    sweepstake.HandleWinner();
                    DisplaySweepstakeMenu(sweepstake);
                    return;
                case "3":
                    DisplaySweepstakesManagerMenu();
                    break;
            }
        }

        public Sweepstakes CreateSweepstake()
        {
            Console.WriteLine("What is the name of the sweepstake?");
            string sweepstakeName = Console.ReadLine();
            Sweepstakes newSweepstake = new Sweepstakes(sweepstakeName);
            return newSweepstake;
        }

    }
}
