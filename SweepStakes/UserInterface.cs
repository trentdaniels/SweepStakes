using System;
namespace SweepStakes
{
    public static class UserInterface
    {

        public static string GetFirstName()
        {
            string firstName;
            Console.WriteLine("Hello Contestant. What is your first name?");
            firstName = Console.ReadLine();
            return firstName;
        }

        public static string GetLastName()
        {
            string lastName;
            Console.WriteLine("What is your last name?");
            lastName = Console.ReadLine();
            return lastName;
        }
        public static string GetEmail()
        {
            string email;
            Console.WriteLine("What is your email address?");
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






    }

}
