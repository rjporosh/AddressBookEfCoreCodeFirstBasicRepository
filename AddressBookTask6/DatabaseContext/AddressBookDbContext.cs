using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookTask6.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;


//using Microsoft.EntityFrameworkCore;
namespace AddressBookTask6.DatabaseContext
{
    public class AddressBookDbContext : DbContext
    {
        public DbSet<Person> Address { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AM55Q6R\\SQLEXPRESS;Database=AddressBook; Integrated Security=true");
        }

    }
}
