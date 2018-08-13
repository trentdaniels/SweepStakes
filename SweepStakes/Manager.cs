using System;
namespace SweepStakes
{
    public abstract class Manager
    {
        public Manager()
        {
        }

        public virtual void DisplaySweepstakesManagerMenu()
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
                    selectedSweepstake.DisplayMenu();
                    break;
                default:
                    UserInterface.DisplayErrorMessage();
                    break;

            }
            DisplaySweepstakesManagerMenu();
            return;
        }

        public abstract void InsertSweepstakes(Sweepstakes sweepstakes);

        public abstract Sweepstakes GetSweepstakes();

        public Sweepstakes CreateSweepstake()
        {
            Console.WriteLine("What is the name of the sweepstake?");
            string sweepstakeName = Console.ReadLine();
            Sweepstakes newSweepstake = new Sweepstakes(sweepstakeName);
            return newSweepstake;
        }


    }




}
