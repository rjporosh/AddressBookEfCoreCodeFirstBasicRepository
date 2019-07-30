using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookTask6.DatabaseContext;
using AddressBookTask6.Model;
using Microsoft.EntityFrameworkCore;

namespace AddressBookTask6.Repository
{
    public class AddressBookRepository
    {
        private AddressBookDbContext _db;

        public AddressBookRepository()
        {
            _db = new AddressBookDbContext();
        }
        public bool Add(Person person)
        {
            _db.Address.Add(person);

            return _db.SaveChanges() > 0;
        }

        public bool Remove(Person person)
        {
            _db.Address.Remove(person);
            return _db.SaveChanges() > 0;
        }

        public List<Person> GetAll()
        {
            return _db.Address.ToList();
        }

        public Person GetById(int id)
        {
            return _db.Address.Find(id);
        }

        public bool Update(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;

            return _db.SaveChanges() > 0;
        }
    }
}
