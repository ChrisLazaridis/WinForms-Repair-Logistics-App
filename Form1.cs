using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace OptionCo
{
    public partial class Form1 : Form
    {
        private List<Customer> _customers;
        private List<Device> _devices;
        private List<Repair> _repairs;
        private Customer _selectedCustomer;
        private readonly DBConnection _dbConnection = new DBConnection("option.db");
        private StringCompare _stringCompare = new StringCompare();
        private Device _selectedDevice;
        private Repair _selectedRepair;

        public Form1()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            try
            {
                _customers = new List<Customer>();
                _devices = new List<Device>();
                _repairs = new List<Repair>();
                using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                dbConnection.Open();
                using var cmd = new SQLiteCommand(dbConnection);
                cmd.CommandText = "SELECT * FROM Repair";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _repairs.Add(new Repair(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
                }

                using var cmd2 = new SQLiteCommand(dbConnection);
                cmd2.CommandText = "SELECT * FROM Devices";
                using var reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    _devices.Add(new Device(reader2.GetInt32(0), reader2.GetString(1), reader2.GetInt32(2),
                        reader2.GetString(3), _repairs.Where(x => x.CustomerId == reader2.GetInt32(2)).ToList()));
                }

                using var cmd3 = new SQLiteCommand(dbConnection);
                cmd3.CommandText = "SELECT * FROM Customers";
                using var reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    _customers.Add(new Customer(reader3.GetInt32(0), reader3.GetString(1), reader3.GetString(2),
                        reader3.GetString(3), reader3.GetString(4),
                        _devices.Where(x => x.CustomerId == reader3.GetInt32(0)).ToList()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowCustomerInfo(Control richTexBox, Customer c)
        {
            richTexBox.Text = "name:" + c.Name + "\n" + "email" + c.Email + "\n" + "mobile" + c.MobilePhone + "\n" + "Home Phone" + c.HomePhone;
        }

        private void ShowInfo(Control richTextBox, Repair d)
        {
            richTextBox.Text = "Description: " + d.Description + "\n" + "Date In: " + d.DateIn + "\n" + "Date Out: " + d.DateOut + "\n" + "Status: " + d.Status;
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var form2 = new Form2(_customers);
            form2.ShowDialog();
            Enabled = true;
            GetData();
            Refresh();
        }

        private void buttonDevice_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var form3 = new Form3(_devices, _customers);
            form3.ShowDialog();
            Enabled = true;
            GetData();
            Refresh();
        }

        private void buttonBoth_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var form4 = new Form4();
            form4.ShowDialog();
            Enabled = true;
            GetData();
            Refresh();
        }

        private void buttonSearchByName_Click(object sender, EventArgs e)
        {
            foreach (var t in _customers)
            {
                if (_stringCompare.Calculate(textBoxName.Text, t.Name) <= 2)
                {
                    listBox1.Items.Add(t.Name);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var t in _customers.Where(t => listBox1.SelectedItem.ToString() == t.Name))
            {
                _selectedCustomer = t;
                ShowCustomerInfo(richTextBox1, t);
            }
        }

        private void buttonSearchBySerial_Click(object sender, EventArgs e)
        {
            foreach (var t in _devices)
            {
                if (_stringCompare.Calculate(textBoxSerial.Text, t.SerialKey) <= 2)
                {
                    listBox2.Items.Add(t.SerialKey);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Clear();

            foreach (var t in _devices.Where(t => string.Equals(listBox2.SelectedItem?.ToString(), t.SerialKey)))
            {
                _selectedDevice = t;

                foreach (var r in t.Repair)
                {
                    listBox3.Items.Add(r.DateIn);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var t in _selectedDevice.Repair.Where(t =>
                         string.Equals(listBox3.SelectedItem?.ToString(), t.DateIn)))
            {
               ShowInfo(richTextBox2, t);
               _selectedRepair = t;

            }
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(_customers);
            form5.ShowDialog();
            GetData();
            Refresh();
        }

        private void buttonDeleteDevice_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(_customers, _devices);
            form6.ShowDialog();
            GetData();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(_customers, _devices, _repairs);
            form7.ShowDialog();
            GetData();
            Refresh();
        }

        private void buttonRepair_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(_customers, _devices, _repairs);
            form8.ShowDialog();
            GetData();
            Refresh();
        }

        private void buttonShowRepair_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(_customers, _devices, _repairs);
            form9.ShowDialog();
            GetData();
            Refresh();
        }
    }
}
