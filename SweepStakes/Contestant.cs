using System;
namespace SweepStakes
{
    public class Contestant
    {
        private string firstName;
        private string lastName;
        private string email;
        private int registrationNumber;
        private string fullName;


        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public int RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public bool IsWinner { get; set; }

        public Contestant()
        {
            fullName = $"{firstName} {lastName}";
            IsWinner = false;

        }


    }
}
