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
    public partial class Form7 : Form
    {
        private List<Customer> _customers;
        private List<Device> _devices;
        private List<Repair> _repairs;
        private List<Repair> _toBeDeletedRepairs;
        DBConnection _dbConnection = new DBConnection("option.db");
        public Form7(List<Customer> customers, List<Device> devices, List<Repair> repair)
        {
            InitializeComponent();
            _customers = customers;
            _devices = devices;
            _toBeDeletedRepairs = [];
            _repairs = repair;
            foreach (var customer in _customers)
            {
                comboBoxName.Items.Add(customer.Name);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
            dbConnection.Open();
            using var cmd = new SQLiteCommand(dbConnection);
            foreach (var repair in _toBeDeletedRepairs)
            {
                cmd.CommandText = "DELETE FROM Repair WHERE ID = @Id";
                cmd.Parameters.AddWithValue("@Id", repair.Id);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Repairs deleted");
            Close();
        }

        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var device in _devices.Where(device =>
                         device.SerialKey == comboBoxDevices.SelectedItem.ToString()))
            {
                foreach (var repair in device.Repair)
                {
                    checkedListBox1.Items.Add(repair.DateIn);
                }
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var customer in _customers.Where(customer => customer.Name == comboBoxName.SelectedItem.ToString()))
            {
                comboBoxDevices.Items.Clear();
                foreach (var device in customer.Devices)
                {
                    comboBoxDevices.Items.Add(device.SerialKey);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _toBeDeletedRepairs.Clear();
            buttonDelete.Enabled = true;
            foreach (var repair in _repairs.Where(repair => checkedListBox1.CheckedItems.Contains(repair.DateIn)))
            {
                _toBeDeletedRepairs.Add(repair);
            }
        }
    }
}
