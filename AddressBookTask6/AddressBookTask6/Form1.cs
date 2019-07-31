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
    public partial class Form1 : Form
    {
        public Person p;
        public AddressBook a;
        Form2 f;
        public Form1()
        {
            InitializeComponent();
           // btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            
               // listView1.DisplayMember = "Name";
            a = new AddressBook();
            f = new Form2();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(isOk())
            {
               // btnAdd.Enabled = true;
                p = new Person();
                if (a.isDuplicate(txtEmail.Text) ==false)
                {
                    p.FirstName = txtFirstName.Text;
                    p.LastName = txtLastName.Text;
                    p.Email = txtEmail.Text;
                    p.Phone = txtPhone.Text;
                    a.addPerson(p);
                    list();
                    txtFirstName.Text="";
                    txtLastName.Text="";
                    txtEmail.Text="";
                    txtPhone.Text="";
                    MessageBox.Show("Person Saved");
                    //this.Hide();
                    //f.ShowDialog();
                }
                else
                {
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Focus();
                    MessageBox.Show("User Already Exist with the same Email.");
                }
            }
        }
        public void list()
        {
            listView1.Items.Clear();
            foreach(Person p in a.listPerson)
            {
                // listView1.Items.Add(p.FirstName/*+"\t\t"+p.LastName + p.Email + p.Phone*/);
                ListViewItem item1 = new ListViewItem(p.FirstName);
                item1.SubItems.Add(p.LastName);
                item1.SubItems.Add(p.Email);
                item1.SubItems.Add(p.Phone);
                listView1.Items.Add(item1);
            }
        }
        public bool isOk()
        {
            if(txtFirstName.Text=="" || txtLastName.Text=="" || txtEmail.Text==""||txtPhone.Text=="")
            { MessageBox.Show("Plz fill up all the required fields");return false; }
            if(!txtEmail.Text.Contains("@") && !txtEmail.Text.Contains("."))
            { MessageBox.Show("Email address must have a '@'  and a '.'"); return false; }
            if (!txtEmail.Text.Contains("@"))
            { MessageBox.Show("Email address must have a '@' "); return false; }
            if (!txtEmail.Text.Contains("."))
            { MessageBox.Show("Email address must have a '.' "); return false; }
            if(txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".") && txtFirstName.Text!="" && txtLastName.Text!="" && txtPhone.Text!="" && txtEmail.Text!="")
            { btnAdd.Enabled = true; return true; }
            //MessageBox.Show("Plz fill up all the required fields Check Email Contains '@' and '.'");
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
          
            a.deletePerson(p);
           
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            list();
            MessageBox.Show("Person Deleted");
            //this.Hide();
            //f.ShowDialog();

        }
       // Person pp = new Person();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            a.updatePerson(p);
            
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            list();
            MessageBox.Show("Person Updated");
            //this.Hide();
            //f.ShowDialog();
        }
       
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // p=(Person)listView1.SelectedItems.Cast<Person>();
            p = new Person();
           foreach(Person p in a.listPerson)
            {
                if(p.FirstName==listView1.SelectedItems.ToString())
                {
                    txtFirstName.Text = p.FirstName;
                    txtLastName.Text = p.LastName;
                    txtEmail.Text = p.Email;
                    txtPhone.Text = p.Phone;
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
               // btnAdd.Enabled = true;
            }
           
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView1.SelectedItems[0];
           p = new Person();
            foreach (Person p in a.listPerson)
            {
                if (p.FirstName == item.Text)
                {
                    //fill the text boxes
                    p.FirstName = txtFirstName.Text = item.SubItems[0].Text;
                    p.LastName = txtLastName.Text = item.SubItems[1].Text;
                    p.Email = txtEmail.Text = item.SubItems[2].Text;
                    p.Phone = txtPhone.Text = item.SubItems[3].Text;
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                //btnAdd.Enabled = true;
            }

            ////fill the text boxes
            //p.FirstName=txtFirstName.Text = item.Text;
            //p.LastName= txtLastName.Text = item.SubItems[1].Text;
            //p.Email=txtEmail.Text = item.SubItems[2].Text;
            //p.Phone=txtPhone.Text = item.SubItems[3].Text;
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSearchBy.Text== "Last Name" && txtSearchBy.Text!="" && txtSearchBy.Text != null)
            {
                listView1.Items.Clear();
                foreach(Person p in a.searchByLastName(txtSearchBy.Text))
                {
                    //listView1.Items.Add(p.FirstName);
                    ListViewItem item1 = new ListViewItem(p.FirstName);
                    item1.SubItems.Add(p.LastName);
                    item1.SubItems.Add(p.Email);
                    item1.SubItems.Add(p.Phone);
                    listView1.Items.Add(item1);
                }
               
            }
            else if (comboBoxSearchBy.Text == "E-mail" && txtSearchBy.Text != "" && txtSearchBy.Text != null)
            {
                listView1.Items.Clear();
                foreach (Person p in a.searchByEmail(txtSearchBy.Text))
                {
                    // listView1.Items.Add(p.FirstName);
                    ListViewItem item1 = new ListViewItem(p.FirstName);
                    item1.SubItems.Add(p.LastName);
                    item1.SubItems.Add(p.Email);
                    item1.SubItems.Add(p.Phone);
                    listView1.Items.Add(item1);
                }
            }
            else if (comboBoxSearchBy.Text == "Mobile Number" && txtSearchBy.Text != "" && txtSearchBy.Text != null)
            {
                listView1.Items.Clear();
                foreach (Person p in a.searchByMobile(txtSearchBy.Text))
                {
                    //listView1.Items.Add(p.FirstName);
                    ListViewItem item1 = new ListViewItem(p.FirstName);
                    item1.SubItems.Add(p.LastName);
                    item1.SubItems.Add(p.Email);
                    item1.SubItems.Add(p.Phone);
                    listView1.Items.Add(item1);
                }
            }
            else
            {
                list();
                MessageBox.Show("Type something and then select search by.");
            }
        }
    }
}
