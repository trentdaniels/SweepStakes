using System;
namespace SweepStakes
{
    public static class UserInterface
    {

        public static string GetFirstName()
        {
            string firstName;
            Console.WriteLine("What is the contestant's first name?");
            firstName = Console.ReadLine();
            return firstName;
        }

        public static string GetLastName()
        {
            string lastName;
            Console.WriteLine("What is the contestant's last name?");
            lastName = Console.ReadLine();
            return lastName;
        }
        public static string GetEmail()
        {
            string email;
            Console.WriteLine("What is the contestant's email address?");
            email = Console.ReadLine();
            return email;
        }



        public static int GetRegistrationNumber(int currentRegistrationNumber)
        {
            currentRegistrationNumber++;
            return currentRegistrationNumber;
        }

        public static string GetSweepstakesName()
        {
            string userResponse;
            Console.WriteLine("What is the name of this sweepstake?");
            userResponse = Console.ReadLine();
            return userResponse;
        }

        public static ISweepstakesManager GetManager()
        {
            string userInput;
            ISweepstakesManager manager;
            Console.WriteLine("What kind of manager would you like to create?\n[1]Stack\n[2]Queue");
            userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                    manager = new SweepstakesStackManager();
                    break;
                case "2":
                    manager = new SweepstakesQueueManager();
                    break;
                default:
                    DisplayErrorMessage();
                    return GetManager();
            }
            return manager;
        }

        public static void DisplayErrorMessage()
        {
            Console.WriteLine("Invalid option. Please try again.");
        }

        public static string SelectContestant()
        {
            Console.WriteLine("Which contestant would you like to view?");
            string selectedContestant = Console.ReadLine();
            return selectedContestant;
        }

        public static void DisplaySweepstakesManagerMenu(ISweepstakesManager manager)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("[1]Create Sweepstake\n[2]Go To Sweepstake");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Sweepstakes newSweepstake = CreateSweepstake();
                    manager.InsertSweepstakes(newSweepstake);
                    Console.WriteLine($"Added {newSweepstake.Name} to list of sweepstakes.");
                    break;
                case "2":
                    Sweepstakes selectedSweepstake = manager.GetSweepstakes();
                    DisplaySweepstakeMenu(selectedSweepstake);
                    break;
                default:
                    DisplayErrorMessage();
                    break;

            }
            DisplaySweepstakesManagerMenu(manager);
            return;
        }

        public static Sweepstakes CreateSweepstake()
        {
            Console.WriteLine("What is the name of the sweepstake?");
            string sweepstakeName = Console.ReadLine();
            Sweepstakes newSweepstake = new Sweepstakes(sweepstakeName);
            return newSweepstake;
        }

        public static void DisplaySweepstakeMenu(Sweepstakes sweepstake)
        {
            Console.WriteLine($"Selected {sweepstake.Name}:");
            Console.WriteLine("What would you like to do?\n[1]Register Contestant\n[2]Pick Winner\n[3]View Contestants\n[4]View Contestant Information\n[5]Back to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    sweepstake.HandleContestant();
                    DisplaySweepstakeMenu(sweepstake);
                    break;
                case "2":
                    sweepstake.HandleWinner();
                    DisplaySweepstakeMenu(sweepstake);
                    break;
                case "3":
                    sweepstake.DisplayContestants();
                    DisplaySweepstakeMenu(sweepstake);
                    break;
                case "4":

                    break;
                case "5":
                    break;
                default:
                    DisplayErrorMessage();
                    DisplaySweepstakeMenu(sweepstake);
                    break;
            }
            return;
        }

        public static void GetInformation(Contestant contestant)
        {
            contestant.FirstName = GetFirstName();
            contestant.LastName = GetLastName();
            contestant.Email = GetEmail();

        }


    }

}
