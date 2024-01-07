using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace OptionCo
{
    public partial class Form5 : Form
    {
        private List<Customer> _customers;
        private List<Device> _toBeDeletedDevices;
        private List<Repair> _toBeDeletedRepairs;
        private Customer _selectedCustomer;
        private readonly DBConnection _dbConnection = new DBConnection("option.db");
        public Form5( List<Customer> customers)
        {
            InitializeComponent();
            _customers = customers;
            _toBeDeletedDevices = [];
            _toBeDeletedRepairs = [];
            foreach (var customer in _customers)
            {
                comboBox1.Items.Add(customer.Name);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // delete everything related to the customer
            using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
            dbConnection.Open();
            using var cmd = new SQLiteCommand(dbConnection);
            cmd.CommandText = "DELETE FROM Customers WHERE ID = @Id";
            cmd.Parameters.AddWithValue("@Id", _selectedCustomer.Id);
            cmd.ExecuteNonQuery();
            foreach (var device in _toBeDeletedDevices)
            {
                cmd.CommandText = "DELETE FROM Devices WHERE ID = @Id";
                cmd.Parameters.AddWithValue("@Id", device.Id);
                cmd.ExecuteNonQuery();
            }

            foreach (var repair in _toBeDeletedRepairs)
            {
                cmd.CommandText = "DELETE FROM Repair WHERE ID = @Id";
                cmd.Parameters.AddWithValue("@Id", repair.Id);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Customer deleted");
            Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            _selectedCustomer = _customers[comboBox1.SelectedIndex];
            _toBeDeletedDevices = _selectedCustomer.Devices;
            foreach (var r in _toBeDeletedDevices.SelectMany(device => device.Repair))
            {
                _toBeDeletedRepairs.Add(r);
            }
            richTextBox1.Text = "";
            richTextBox1.Text += "Name: " + _selectedCustomer.Name + "\n";
            richTextBox1.Text += "Email: " + _selectedCustomer.Email + "\n";
            richTextBox1.Text += "Mobile Phone: " + _selectedCustomer.MobilePhone + "\n";
            richTextBox1.Text += "Home Phone: " + _selectedCustomer.HomePhone + "\n";

        }
    }
}
