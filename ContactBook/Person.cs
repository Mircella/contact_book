using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            setFirstName(firstName);
            setLastName(lastName);
            setTelephoneNumber(telephoneNumber);
            setEmailAddress(emailAddress);
            this.dateOfBirth = dateOfBirth;
        }

        public DateTime DateOfBirth => dateOfBirth;

        public string EmailAddress => emailAddress;

        public string TelephoneNumber => telephoneNumber;

        private void setTelephoneNumber(string telephoneNumber)
        {
            if (telephoneNumber.All(char.IsNumber))
            {
                this.telephoneNumber = telephoneNumber;
            }
            else
            {
                throw new ArgumentException("Invalid telephone number");
            }
        }
        
        private void setEmailAddress(string emailAddress)
        {
            String emailAddressPattern = @"(?i)(\S+)(@{1})(\w+)(.{1})(\w+)$";
            Regex r = new Regex(emailAddressPattern, RegexOptions.IgnoreCase);
            if (r.Match(emailAddress).Success)
            {
                this.emailAddress = emailAddress;
            }
            else
            {
                throw new ArgumentException("Invalid email address");
            }
        }
        
        private void setLastName(string lastName)
        {
            if (!String.IsNullOrEmpty(lastName))
            {
                this.lastName = lastName;
            }
            else
            {
                throw new ArgumentException("Invalid last name");
            }
        }
        
        private void setFirstName(string firstName)
        {
            if (!String.IsNullOrEmpty(firstName))
            {
                this.firstName = firstName;
            }
            else
            {
                throw new ArgumentException("Invalid first name");
            }
        }



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