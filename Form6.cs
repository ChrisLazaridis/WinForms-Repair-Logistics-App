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
    public partial class Form6 : Form
    {
        private List<Customer> _customers;
        private List<Device> _devices;
        private List<Device> _toBeDeleteDevices;
        private readonly DBConnection _dbConnection = new DBConnection("option.db");
        public Form6(List<Customer> customers, List<Device> devices)
        {
            InitializeComponent();
            _customers = customers;
            _devices = devices;
            _toBeDeleteDevices = [];
            foreach (var customer in _customers)
            {
                comboBox1.Items.Add(customer.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var customer in _customers)
            {
                if (customer.Name == comboBox1.SelectedItem.ToString())
                {
                    checkedListBox1.Items.Clear();
                    foreach (var device in customer.Devices)
                    {
                        checkedListBox1.Items.Add(device.SerialKey);
                    }
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _toBeDeleteDevices.Clear();
            buttonDelete.Enabled = true;
            richTextBox1.Text = "";
            foreach (var device in _devices.Where(device => checkedListBox1.CheckedItems.Contains(device.SerialKey)))
            {
                _toBeDeleteDevices.Add(device);
            }

            foreach (var device in _toBeDeleteDevices)
            {
                richTextBox1.Text += "Serial Key" + device.SerialKey + "\n" +"Device Type" + device.DeviceType;
            }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // delete all the devices and their associated repairs
            foreach (var device in _toBeDeleteDevices)
            {
                foreach (var repair in device.Repair)
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText = "DELETE FROM Repair WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", repair.Id);
                    cmd.ExecuteNonQuery();
                    dbConnection.Close();
                }
                using var dbConnection2 = new SQLiteConnection(_dbConnection.ConnectionString);
                dbConnection2.Open();
                using var cmd2 = new SQLiteCommand(dbConnection2);
                cmd2.CommandText = "DELETE FROM Devices WHERE ID = @Id";
                cmd2.Parameters.AddWithValue("@Id", device.Id);
                cmd2.ExecuteNonQuery();
                dbConnection2.Close();
            }
        }
    }
}
