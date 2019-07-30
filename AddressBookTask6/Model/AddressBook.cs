using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookTask6;
using AddressBookTask6.Repository;

namespace AddressBookTask6.Model
{
    public class AddressBook
    {
        AddressBookRepository abr = new AddressBookRepository();
        public int Id { get; set; }
        public int selectedIndex { get; set; }
       
        public AddressBook()
        {
            listPerson = new List<Person>();
        }
        public Person person { get; set; }
        public List<Person> listPerson { get; set; }
        public bool isDuplicate(string Email)
        {
            foreach(Person p in abr.GetAll())
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
                abr.Add(p);
            }
            else if(isDuplicate(p.Email))
            { System.Windows.Forms.MessageBox.Show("User already exist with the same email.");}
        }

        public void deletePerson(Person person)
        {
            Person p;
            for (int i=0;i<abr.GetAll().Count;i++)
            {
                 p = listPerson[i];
                if (p.Email == person.Email)
                {
                    listPerson.Remove(p);
                    abr.Remove(p);
                    // listPerson.RemoveAt(1);
                }
            }
            //return listPerson;
        }
        public void updatePerson(Person person)
        {
            listPerson[selectedIndex] = person;
            abr.Update(person);
            //Person personToDelete;
            //for (int i = 0; i < listPerson.Count; i++)
            //{
            //    personToDelete = listPerson[i];
            //    if (personToDelete.Email == person.Email)
            //    {
            //        listPerson[i] = person;
            //    }
            //}
        }
        public List<Person> searchByLastName(string LastName)
        {
            List<Person> searchByLastName = new List<Person>();
            foreach(Person p in abr.GetAll())
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
            foreach (Person p in abr.GetAll())
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
            foreach (Person p in abr.GetAll())
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
