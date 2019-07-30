using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBookTask6.Model;
using AddressBookTask6.Repository;

namespace AddressBookTask6
{
    public partial class Form1 : Form
    {
        public Person p;
        public AddressBook a;
        private AddressBookRepository abr;
      
        public Form1()
        {
            InitializeComponent();
           // btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            
               // listView1.DisplayMember = "Name";
            a = new AddressBook();
            abr= new AddressBookRepository();
            list();
           
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
                    //abr.Add(p);
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
            foreach(Person p in abr.GetAll())
            {
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
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //abr.Remove(p);
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
            p = new Person();
            p.FirstName = txtFirstName.Text;
            p.LastName = txtLastName.Text;
            p.Email = txtEmail.Text;
            p.Phone = txtPhone.Text;

            a.updatePerson(p);
            //abr.Update(p);
            
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            list();
            MessageBox.Show("Person Updated");
        }
       
       

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            a.selectedIndex = listView1.SelectedIndices[0];
            txtFirstName.Text = a.listPerson[a.selectedIndex].FirstName;
            txtLastName.Text = a.listPerson[a.selectedIndex].LastName;
            txtEmail.Text = a.listPerson[a.selectedIndex].Email;
            txtPhone.Text = a.listPerson[a.selectedIndex].Phone;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            //if (listView1.SelectedItems.Count == 0)
            //    return;

            // ListViewItem item = listView1.SelectedItems[0];
            //// System.Diagnostics.Debug.WriteLine("Selected Indices[0]: " + listView1.SelectedIndices[0]);
            // txtEmail.Enabled = false;
            // p = new Person();
            // for (int i = 0; i < abr.GetAll().Count; i++)
            // {
            //     p = a.listPerson[i];
            //     if (p.FirstName == item.Text)
            //     {
            //         //fill the text boxes
            //         p.FirstName = txtFirstName.Text = item.SubItems[0].Text;
            //         p.LastName = txtLastName.Text = item.SubItems[1].Text;
            //         p.Email = txtEmail.Text = item.SubItems[2].Text;
            //         p.Phone = txtPhone.Text = item.SubItems[3].Text;
            //         btnAdd.Enabled = false;
            //         btnUpdate.Enabled = true;
            //         btnDelete.Enabled = true;
            //     }
            // }

            // txtEmail.Enabled = true;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtEmail.Enabled = true;
            txtPhone.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            list();
        }
    }
}
