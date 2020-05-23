using System.Collections.Generic;
using System.Linq;

namespace ContactBook
{
    public class ContactBook
    {
        private static ContactBook contactBook;
        private ISet<Person> persons;
        private ContactBook()
        {
            if (persons == null)
            {
                persons = new HashSet<Person>();
            }
        }

        public static ContactBook instance()
        {
            if (contactBook == null)
            {
                contactBook = new ContactBook();
            }

            return contactBook;
        }

        public Person addPerson(Person person)
        {
            if (!persons.Contains(person))
            {
                persons.Add(person);
                return person;
            }
            return null;
        }

        public Person getPerson(string emailAddress)
        {
            Person existedPerson = persons.ToList().Find(it => it.EmailAddress == emailAddress);
            return existedPerson;
        }
        
        public Person updatePerson(Person person)
        {
            if (persons.Contains(person))
            {
                persons.Add(person);
                return person;
            }
            return null;
        }

        public List<Person> listAll()
        {
            return persons.ToList();
        }
        
        public Person deletePerson(string emailAddress)
        {
            var person = persons.ToList().Find(it => it.EmailAddress == emailAddress);
            if (persons.Select(it => it.EmailAddress).Contains(emailAddress))
            {
                
                var filtered = persons.ToList().FindAll(it => it.EmailAddress != emailAddress).ToHashSet();
                this.persons = filtered;
                return person;
            }
            return null;
        }
    }
}