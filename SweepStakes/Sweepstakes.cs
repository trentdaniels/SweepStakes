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
        Contestant winner;

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

        public void HandleContestantCreation()
        {
            Contestant contestant = new Contestant();
            UserInterface.GetNewContestantInformation(contestant);
            RegisterContestant(contestant);
            Console.WriteLine($"Registered {contestant.FullName}.");
        }

        public void DetermineWinner()
        {
            string winnerName;
            string contestWinner = PickWinner();
            for (int i = 0; i < contestants.Count; i++)
            {
                if (contestWinner == contestants[i].FullName)
                {
                    winner = contestants[i];
                    winnerName = contestants[i].FullName;
                    Console.WriteLine($"{winnerName} won the {name} sweepstakes!");
                    return;
                }
            }

        }


        public string PickWinner()
        {
            int winningRegistrationNumber;
            string contestWinner;

            winningRegistrationNumber = random.Next(1, contestants.Count);
            for (int i = 0; i < contestants.Count; i++)
            {
                if (winningRegistrationNumber == contestants[i].RegistrationNumber)
                {
                    contestWinner = contestants[i].FullName;
                    contestants[i].IsWinner = true;
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
