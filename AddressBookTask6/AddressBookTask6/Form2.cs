using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBookTask6
{
    public partial class Form2 : Form
    {
        AddressBook a;
        Person p;
        Form2 f;
        public Form2()
        {
            InitializeComponent();
            a = new AddressBook();
            p = new Person();
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           // f.a.listPerson.AsReadOnly(); 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
