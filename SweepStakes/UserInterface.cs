using System;
using System.Net;
using System.Net.Mail;

namespace SweepStakes
{
    public static class UserInterface
    {

        private static string GetFirstName()
        {
            string firstName;
            Console.WriteLine("What is the contestant's first name?");
            firstName = Console.ReadLine();
            return firstName;
        }

        private static string GetLastName()
        {
            string lastName;
            Console.WriteLine("What is the contestant's last name?");
            lastName = Console.ReadLine();
            return lastName;
        }
        private static string GetEmail()
        {
            string email;
            Console.WriteLine("What is the contestant's email address?");
            email = Console.ReadLine();
            return email;
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

        private static void ViewContestant(Sweepstakes sweepstakes)
        {
            DisplayContestants(sweepstakes);
            string selectedContestant = SelectContestant();
            for (int i = 0; i < sweepstakes.Contestants.Count; i++)
            {
                if (selectedContestant == sweepstakes.Contestants[i].RegistrationNumber.ToString())
                {
                    Console.WriteLine("Found Contestant:");
                    DisplayContestantInformation(sweepstakes.Contestants[i]);
                }
            }
        }

        private static void DisplayContestantInformation(Contestant contestant)
        {
            if (contestant == null)
            {
                Console.WriteLine("The winner has not been found yet!");
                return;
            }
            Console.WriteLine($"Name: {contestant.FullName}\nEmail: {contestant.Email}\nRegistration Number: {contestant.RegistrationNumber}\nWinner: {(contestant.IsWinner ? "Yes" : "No")}");
        }

        private static void DisplayContestants(Sweepstakes sweepstakes)
        {
            Console.WriteLine("Registered Contestants:");
            for (int i = 0; i < sweepstakes.Contestants.Count; i++)
            {
                Console.WriteLine($"[{sweepstakes.Contestants[i].RegistrationNumber}] {sweepstakes.Contestants[i].FullName}");
            }
        }

        public static void DisplayManagerMenu(ISweepstakesManager manager)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("[1]Create Sweepstake\n[2]Go To Sweepstake Menu");
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
            DisplayManagerMenu(manager);
            return;
        }

        private static Sweepstakes CreateSweepstake()
        {
            Console.WriteLine("What is the name of the sweepstake?");
            string sweepstakeName = Console.ReadLine();
            Sweepstakes newSweepstake = new Sweepstakes(sweepstakeName);
            return newSweepstake;
        }

        private static void DisplaySweepstakeMenu(Sweepstakes sweepstake)
        {
            Console.WriteLine($"Selected {sweepstake.Name}:");
            Console.WriteLine("What would you like to do?\n[1]Register Contestant\n[2]Pick Winner\n[3]View Contestants\n[4]View Contestant Information\n[5]View Winner\n[6]Back to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    sweepstake.HandleContestantCreation();
                    break;
                case "2":
                    sweepstake.DetermineWinner();
                    EmailContestants(sweepstake);
                    break;
                case "3":
                    DisplayContestants(sweepstake);
                    break;
                case "4":
                    ViewContestant(sweepstake);
                    break;
                case "5":
                    DisplayContestantInformation(sweepstake.Winner);
                    break;
                case "6":
                    return;
                default:
                    DisplayErrorMessage();
                    break;
            }
            DisplaySweepstakeMenu(sweepstake);
            return;
        }

        public static void GetNewContestantInformation(Contestant contestant)
        {
            contestant.FirstName = GetFirstName();
            contestant.LastName = GetLastName();
            contestant.Email = GetEmail();
            contestant.FullName = $"{contestant.FirstName} {contestant.LastName}";
        }

        private static void EmailContestants(Sweepstakes sweepstakes)
        {
            
            for (int i = 0; i < sweepstakes.Contestants.Count; i ++)
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mail.From = new MailAddress("trent.test1234@gmail.com", $"The {sweepstakes.Name} Sweepstakes");
                smtpClient.Port = 25;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(Credentials.USERNAME, Credentials.PASSWORD);
                mail.To.Add(sweepstakes.Contestants[i].Email);
                if (sweepstakes.Contestants[i].Email == sweepstakes.Winner.Email)
                {
                    mail.Subject = $"CONGRATULATIONS!";
                    mail.Body = $"Congratulations {sweepstakes.Winner.FullName}! You have won the {sweepstakes.Name} sweepstakes!";
                }
                else
                {
                    mail.Subject = $"Results from the {sweepstakes.Name} Sweepstakes";
                    mail.Body = $"Sorry {sweepstakes.Contestants[i].FullName}, you have lost the {sweepstakes.Name} sweepstakes. Try again next time!";
                }
                smtpClient.Send(mail);
            }
            Console.WriteLine("Sent emails to contestants.");
        }


    }

}

