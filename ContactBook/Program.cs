using System;

namespace ContactBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactBook contactBook = ContactBook.instance();
            string[] options = {"0. Create", "1. Find", "2. Edit", "3. Delete", "4. List all"};
            while (true)
            {
                try
                {
                    listOptions("Select one of the option:", options);
                    int choice = ReadUserInputChoice();
                    switch (choice)
                    {
                        case 0:
                        {
                            createPerson(contactBook);
                            break;
                        }
                        case 1:
                        {
                            findPerson(contactBook);
                            break;
                        }
                        case 2:
                        {
                            string emailAddress = readInputString("Enter email address");
                            Person person = contactBook.getPerson(emailAddress);
                            if (person!=null)
                            {
                                editPerson(person, contactBook);
                            }
                            else
                            {
                                Console.WriteLine($"There is no person with email:{emailAddress}");
                            }
                            break;
                        }
                        case 3:
                        {
                            deletePerson(contactBook);
                            break;
                        }
                        case 4:
                        {
                            var persons = contactBook.listAll();
                            if (persons!=null && persons.Count > 0)
                            {
                                Console.WriteLine($"Persons:\n");
                                for (int i = 0; i < persons.Count; i++)
                                {
                                    Console.WriteLine($"{i}:\n{persons[i]}\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no persons");
                            }
                            break;
                        }
                        default:
                        {
                            throw new ArgumentException("Invalid choice");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static void editPerson(Person person, ContactBook contactBook)
        {
            string[] editOptions =
            {
                "0. FirstName", "1. LastName", "2. Email address",
                "3. Telephone number", "4. Date of birth"
            };
            listOptions("Select what you'd like to edit:", editOptions);
            int editChoice = ReadUserInputChoice();
            switch (editChoice)
            {
                case 0:
                {
                    updateFirstName(person, contactBook);
                    break;
                }
                case 1:
                {
                    updateLastName(person, contactBook);
                    break;
                }
                case 2:
                {
                    updateEmailAddress(person, contactBook);
                    break;
                }
                case 3:
                {
                    updateTelephoneNumber(person, contactBook);
                    break;
                }
                case 4:
                {
                    updateDateOfbirth(person, contactBook);
                    break;
                }
                default:
                {
                    throw new ArgumentException("Invalid choice");
                }
            }
        }

        private static void deletePerson(ContactBook contactBook)
        {
            string emailAddress = readInputString("Enter email address:");
            Person result = contactBook.deletePerson(emailAddress);
            if (result != null)
            {
                Console.WriteLine($"Person:'{result.FirstName} {result.LastName} was deleted'");
            }
            else
            {
                Console.WriteLine($"There was no person with email:'{emailAddress}'");
            }
        }

        private static void updateDateOfbirth(Person person, ContactBook contactBook)
        {
            var dateOfBirth = Convert.ToDateTime(readInputString("Enter date of birth:(dd.MM.yyyy)"));
            var newPerson = new Person(
                person.FirstName, person.LastName, person.TelephoneNumber,
                person.EmailAddress, dateOfBirth
            );
            Person result = contactBook.updatePerson(newPerson);
            if (result != null)
            {
                Console.WriteLine($"Person was updated");
            }
            else
            {
                Console.WriteLine($"Failed to update person:'{person.EmailAddress}'");
            }
        }

        private static void updateTelephoneNumber(Person person, ContactBook contactBook)
        {
            var newPhoneNumber = readInputString("Enter telephone number:");
            var newPerson = new Person(person.FirstName, person.LastName, newPhoneNumber,
                person.EmailAddress, person.DateOfBirth);
            Person result = contactBook.updatePerson(newPerson);
            if (result != null)
            {
                Console.WriteLine($"Person was updated");
            }
            else
            {
                Console.WriteLine($"Failed to update person:'{person.EmailAddress}'");
            }
        }

        private static void updateEmailAddress(Person person, ContactBook contactBook)
        {
            var newEmailAddress = readInputString("Enter email address:");
            var newPerson = new Person(person.FirstName, person.LastName, person.TelephoneNumber,
                newEmailAddress, person.DateOfBirth);
            var oldPerson = contactBook.deletePerson(person.EmailAddress);
            if (oldPerson != null)
            {
                var result = contactBook.addPerson(newPerson);
                if (result != null)
                {
                    Console.WriteLine($"Person was updated");
                }
                else
                {
                    Console.WriteLine($"Failed to update person:'{person.EmailAddress}'");
                }
            }
            else
            {
                Console.WriteLine($"Failed to update person:'{person.EmailAddress}'");
            }
        }

        private static void updateLastName(Person person, ContactBook contactBook)
        {
            var lastName = readInputString("Enter lastName:");
            var newPerson = new Person(
                person.FirstName, lastName, person.TelephoneNumber,
                person.EmailAddress, person.DateOfBirth
            );
            Person result = contactBook.updatePerson(newPerson);
            if (result != null)
            {
                Console.WriteLine($"Person was updated");
            }
            else
            {
                Console.WriteLine($"Failed to update person:'{person.EmailAddress}'");
            }
        }

        private static void updateFirstName(Person person, ContactBook contactBook)
        {
            var firstName = readInputString("Enter firstName:");
            var newPerson = new Person(firstName, person.LastName, person.TelephoneNumber,
                person.EmailAddress, person.DateOfBirth);
            Person result = contactBook.updatePerson(newPerson);
            if (result != null)
            {
                Console.WriteLine($"Person was updated");
            }
            else
            {
                Console.WriteLine($"Failed to update person:'{person.EmailAddress}'");
            }
        }

        private static void findPerson(ContactBook contactBook)
        {
            string emailAddress = readInputString("Enter email address");
            Person result = contactBook.getPerson(emailAddress);
            if (result != null)
            {
                Console.WriteLine($"Found person:\n{result}");
            }
            else
            {
                Console.WriteLine($"No person with email:\n{emailAddress}");
            }
        }

        private static void createPerson(ContactBook contactBook)
        {
            Person person = readPersonData();
            Person result = contactBook.addPerson(person);
            if (result != null)
            {
                Console.WriteLine($"Person:'{result.FirstName} {result.LastName} was created'");
            }
            else
            {
                Console.WriteLine($"Failed to create person");
            }
        }

        private static void listOptions(string instruction, string[] options)
        {
            var optionsText = String.Join("\n", options);
            Console.WriteLine($"{instruction}\n{optionsText}");
        }

        private static string readInputString(string instruction)
        {
            Console.WriteLine(instruction);
            string emailAddress = Console.ReadLine();
            return emailAddress;
        }

        private static Person readPersonData()
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter telephone number:");
            string telephoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email address:");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Enter date of birth:(dd.MM.yyyy)");
            string dateOfBirth = Console.ReadLine();
            return new Person(
                firstName, lastName, telephoneNumber, emailAddress, Convert.ToDateTime(dateOfBirth)
            );
        }

        private static int ReadUserInputChoice()
        {
            return Int32.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid number format"));
        }
    }
}