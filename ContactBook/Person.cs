using System;

namespace ContactBook
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string telephoneNumber;
        private string emailAddress;
        private DateTime dateOfBirth;

        public Person(string firstName, string lastName, string telephoneNumber, string emailAddress, DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephoneNumber = telephoneNumber;
            this.emailAddress = emailAddress;
            this.dateOfBirth = dateOfBirth;
        }

        public DateTime DateOfBirth => dateOfBirth;

        public string EmailAddress => emailAddress;

        public string TelephoneNumber => telephoneNumber;

        public string LastName => lastName;

        public string FirstName => firstName;

        protected bool Equals(Person other)
        {
            return emailAddress == other.emailAddress;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            return (emailAddress != null ? emailAddress.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"FirstName:{FirstName}" +
                   $"\nLastName:{LastName}" +
                   $"\nEmail:{EmailAddress}" +
                   $"\nTelephone number:{TelephoneNumber}" +
                   $"\nDate of birth:{DateOfBirth}";
        }
    }
}