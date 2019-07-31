using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTask6
{
    public class AddressBook
    {
        public AddressBook()
        {
            listPerson = new List<Person>();
        }
        public Person person { get; set; }
        public List<Person> listPerson { get; set; }
        public bool isDuplicate(string Email)
        {
            foreach(Person p in listPerson)
            {
                if(p.Email==Email)
                { return true; }
            }
            return false;
        }
        public void addPerson(Person p)
        {
            if(isDuplicate(p.Email)==false)
            {
                listPerson.Add(p);
            }
            else if(isDuplicate(p.Email))
            { System.Windows.Forms.MessageBox.Show("User already exist with the same email.");}
        }

        public void deletePerson(Person person)
        {
            
            foreach (Person p in listPerson)
            {
               // p = new Person();
                if (p.Email == person.Email)
                {
                    listPerson.Remove(p);
                   // listPerson.RemoveAt(1);
                }
            }
            //return listPerson;
        }
        public void updatePerson(Person person)
        {
            foreach (Person p in listPerson)
            {
                if (p.Email == person.Email)
                {
                    listPerson.Remove(p);
                    //listPerson.Add(person);
                }
            }
           // return listPerson;
        }
        public List<Person> searchByLastName(string LastName)
        {
            List<Person> searchByLastName = new List<Person>();
            foreach(Person p in listPerson)
            {
                if(p.LastName==LastName)
                {
                    searchByLastName.Add(p);
                }
            }
            return searchByLastName;
        }
        public List<Person> searchByEmail(string Email)
        {
            List<Person> searchByEmail = new List<Person>();
            foreach (Person p in listPerson)
            {
                if (p.Email == Email)
                {
                    searchByEmail.Add(p);
                }
            }
            return searchByEmail;
        }
        public List<Person> searchByMobile(string Mobile)
        {
            List<Person> searchByMobile = new List<Person>();
            foreach (Person p in listPerson)
            {
                if (p.Phone == Mobile)
                {
                    searchByMobile.Add(p);
                }
            }
            return searchByMobile;
        }
    }
}
