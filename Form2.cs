using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;

namespace OptionCo
{
    public partial class Form2 : Form
    {
        DBConnection _dbConnection = new DBConnection("option.db");
        private readonly List<Customer> _customers;
        private int _mode = 0;
        private Customer _selectedCustomer;
        public Form2(List<Customer> Customers)
        {
            InitializeComponent();
            _customers = Customers;
            foreach (var customer in _customers)
            {
                comboBox1.Items.Add(customer.Name);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxHome.Text = "";
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxMobile.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxName.Enabled = false;
                textBoxName.Visible = false;
                comboBox1.Enabled = true;
                comboBox1.Visible = true;
                _mode = 1;

            }
            else
            {
                textBoxName.Enabled = true;
                textBoxName.Visible = true;
                comboBox1.Enabled = false;
                comboBox1.Visible = false;
                _mode = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var customer in _customers)
            {
                if (customer.Name == comboBox1.Text)
                {
                    textBoxEmail.Text = customer.Email;
                    textBoxMobile.Text = customer.MobilePhone;
                    textBoxHome.Text = customer.HomePhone;
                    _selectedCustomer = customer;
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mode == 0 && textBoxName.Text != "")
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText =
                        "INSERT INTO Customers (Name, Email, MobilePhone, HomePhone) VALUES (@Name, @Email, @MobilePhone, @HomePhone)";
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@MobilePhone", textBoxMobile.Text);
                    cmd.Parameters.AddWithValue("@HomePhone", textBoxHome.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added");
                }
                else if (_mode == 1)
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText =
                        "UPDATE Customers SET Email = @Email, MobilePhone = @MobilePhone, HomePhone = @HomePhone WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@MobilePhone", textBoxMobile.Text);
                    cmd.Parameters.AddWithValue("@HomePhone", textBoxHome.Text);
                    cmd.Parameters.AddWithValue("@ID", _selectedCustomer.Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer updated");
                }
                else
                {
                    MessageBox.Show("Please fill in the name field");
                }
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Close();
            }
            
        }
    }
}
