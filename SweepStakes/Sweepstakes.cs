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

        public string Name { get => name;}
        public Dictionary<int,Contestant> Dictionary { get => dictionary; set => dictionary = value; }

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
            dictionary.Add(numberOfContestants, contestant);
            numberOfContestants++;
            
        }

        public string PickWinner()
        {
            int winningRegistrationNumber;
            string winner;

            winningRegistrationNumber = random.Next(1, dictionary.Count);
            for (int i = 1; i < numberOfContestants; i++)
            {
                if (winningRegistrationNumber == dictionary[i].RegistrationNumber)
                {
                    winner = dictionary[i].FullName;
                    return winner;

                }
            }
            return "No winner found."
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine(contestant.FullName);
            Console.WriteLine(contestant.Email);
            Console.WriteLine(contestant.RegistrationNumber);
        }
    }
}
