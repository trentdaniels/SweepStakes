using System;
using System.Collections.Generic;

namespace SweepStakes
{
    public class Sweepstakes
    {
        // Member Variables
        private string name;
        private Dictionary<int, Contestant> dictionary;
        private int numberOfContestants;
        private Random random;
        private Contestant winner;

        public string Name { get => name;}
        public Dictionary<int,Contestant> Dictionary { get => dictionary; set => dictionary = value; }
        public Contestant Winner { get => winner; }

        // Constructor
        public Sweepstakes(string name)
        {
            this.name = name;
            dictionary = new Dictionary<int, Contestant>();
            numberOfContestants = 01;
            random = new Random();
        }


        // Methods
        public void RegisterContestant(Contestant contestant)
        {
            contestant.RegistrationNumber = numberOfContestants;
            dictionary.Add(contestant.RegistrationNumber, contestant);
            numberOfContestants++;
            
        }

        public void HandleContestant()
        {
            Contestant contestant = new Contestant();
            RegisterContestant(contestant);
        }

        public void HandleWinner()
        {
            string contestWinner = PickWinner();
            for (int i = 1; i < dictionary.Count; i++)
            {
                if (contestWinner == dictionary[i].FullName)
                {
                    winner = dictionary[i];
                }
            }
            Console.WriteLine($"{winner.FullName} won the {name} sweepstakes!");
        }


        public string PickWinner()
        {
            int winningRegistrationNumber;
            string contestWinner;

            winningRegistrationNumber = random.Next(1, numberOfContestants + 1);
            for (int i = 1; i < numberOfContestants; i++)
            {
                if (winningRegistrationNumber == dictionary[i].RegistrationNumber)
                {
                    contestWinner = dictionary[i].FullName;
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

        public void DisplayMenu()
        {
            Console.WriteLine($"Selected {Name}:");
            Console.WriteLine("What would you like to do?\n[1]Register Contestant\n[2]Pick Winner\n[3]Back to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    HandleContestant();
                    DisplayMenu();
                    return;
                case "2":
                    HandleWinner();
                    DisplayMenu();
                    return;
                case "3":
                    return;
            }
        }
    }
}
