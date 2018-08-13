using System;
using System.Collections.Generic;

namespace SweepStakes
{
    public class Sweepstakes
    {
        // Member Variables
        private string name;
        private Dictionary<int, Contestant> contestants;
        private Random random;
        private Contestant winner;

        public string Name { get => name;}
        public Dictionary<int,Contestant> Contestants { get => contestants; set => contestants = value; }
        public Contestant Winner { get => winner; }

        // Constructor
        public Sweepstakes(string name)
        {
            this.name = name;
            contestants = new Dictionary<int, Contestant>();
            random = new Random();
        }


        // Methods
        public void RegisterContestant(Contestant contestant)
        {
            contestants.Add(contestants.Count, contestant);
            contestant.RegistrationNumber = contestants.Count;
        }

        public void HandleContestant()
        {
            Contestant contestant = new Contestant();
            RegisterContestant(contestant);
        }

        public void HandleWinner()
        {
            string contestWinner = PickWinner();
            for (int i = 1; i < contestants.Count; i++)
            {
                if (contestWinner == contestants[i].FullName)
                {
                    winner = contestants[i];
                }
            }
            Console.WriteLine($"{winner.FullName} won the {name} sweepstakes!");
        }


        public string PickWinner()
        {
            int winningRegistrationNumber;
            string contestWinner;

            winningRegistrationNumber = random.Next(0, contestants.Count);
            for (int i = 0; i < contestants.Count; i++)
            {
                if (winningRegistrationNumber == contestants[i].RegistrationNumber)
                {
                    contestWinner = contestants[i].FullName;
                    return contestWinner;

                }
            }
            return "No winner found.";
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine(contestant.FullName);
            Console.WriteLine(contestant.Email);
            Console.WriteLine(contestant.RegistrationNumber);
        }

        public void DisplayContestants()
        {
            Console.WriteLine("Current Contestants:");

            for (int i = 0; i < contestants.Count; i++)
            {
                Console.WriteLine(contestants[i].FullName);
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"Selected {Name}:");
            Console.WriteLine("What would you like to do?\n[1]Register Contestant\n[2]Pick Winner\n[3]View Contestants\n[4]View Contestant Information\n[5]Back to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    HandleContestant();
                    DisplayMenu();
                    break;
                case "2":
                    HandleWinner();
                    DisplayMenu();
                    break;
                case "3":
                    DisplayContestants();
                    DisplayMenu();
                    break;
                case "4":
                    
                    break;
                case "5":
                    break;
                default:
                    UserInterface.DisplayErrorMessage();
                    DisplayMenu();
                    break;
            }
            return;
        }

        public Contestant GetContestant()
        {
            string selectedContestantName = UserInterface.SelectContestant();
            for (int i = 0; i < contestants.Count; i++)
            {
                if (contestants[i].FullName == selectedContestantName)
                {
                    return contestants[i];
                }
            }
            UserInterface.DisplayErrorMessage();
            return GetContestant();
        }
    }
}
