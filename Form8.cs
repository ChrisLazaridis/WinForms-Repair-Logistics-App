using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace OptionCo
{
    
    public partial class Form8 : Form
    {
        private List<Repair> _repairs;
        private List<Customer> _customers;
        private Customer _selectedCustomer;
        private List<Device> _devices;
        private Device _selectedDevice;
        bool _isFinished = false;
        private DBConnection _dbConnection = new DBConnection("option.db");
        public Form8(List<Customer> customer, List<Device> devices, List<Repair> repairs)
        {
            InitializeComponent();
            _customers = customer;
            _devices = devices;
            _repairs = repairs;
            foreach (var customer1 in _customers)
            {
                comboBoxName.Items.Add(customer1.Name);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxName.SelectedIndex = -1;
            comboBoxDevices.SelectedIndex = -1;
            comboBoxDevices.Items.Clear();
            richTextBoxDescription.Text = "";
            comboBox3.SelectedIndex = -1;
            buttonSubmit.Enabled = false;
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var customer in _customers.Where(customer =>
                         customer.Name == comboBoxName.SelectedItem.ToString()))
            {
                _selectedCustomer = customer;
            }
            foreach (var device in _devices.Where(device =>
                         device.CustomerId == _customers[comboBoxName.SelectedIndex].Id))
            {
                comboBoxDevices.Items.Add(device.SerialKey);
            }
        }

        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            // find the selected device
            foreach (var device in _devices.Where(device =>
                         device.SerialKey == comboBoxDevices.SelectedItem.ToString()))
            {
                _selectedDevice = device;
            }
            if(comboBoxDevices.SelectedIndex != -1) buttonSubmit.Enabled = true;
            else buttonSubmit.Enabled = false;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isFinished)
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText =
                        "INSERT INTO Repair (Description, DateIn, DateOut, Status, CustomerId, DeviceId) VALUES (@Description, @DateIn, @DateOut, @Status, @CustomerId, @DeviceId)";
                    cmd.Parameters.AddWithValue("@Description", richTextBoxDescription.Text);
                    cmd.Parameters.AddWithValue("@DateIn", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateOut", "has Not Finished");
                    cmd.Parameters.AddWithValue("@Status", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CustomerId", _selectedCustomer.Id);
                    cmd.Parameters.AddWithValue("@DeviceId", _selectedDevice.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Repair added");
                    Close();
                }
                else
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText =
                        "INSERT INTO Repair (Description, DateIn, DateOut, Status, CustomerId, DeviceId) VALUES (@Description, @DateIn, @DateOut, @Status, @CustomerId, @DeviceId)";
                    cmd.Parameters.AddWithValue("@Description", richTextBoxDescription.Text);
                    cmd.Parameters.AddWithValue("@DateIn", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateOut", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Status", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CustomerId", _selectedCustomer.Id);
                    cmd.Parameters.AddWithValue("@DeviceId", _selectedDevice.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Repair added");
                    Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 2)
            {
                label5.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker2.Enabled = true;
                _isFinished = true;
            }
            else
            {
                label5.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker2.Enabled = false;
                _isFinished = false;
            }
        }
    }
}
