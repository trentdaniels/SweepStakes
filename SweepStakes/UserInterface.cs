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
    }
}
