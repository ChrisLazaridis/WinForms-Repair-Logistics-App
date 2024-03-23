using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OptionCo
{
    public partial class Form9 : Form
    {
        private List<Repair> _repairs;
        private readonly DBConnection _dbConnection = new("option.db");
        private List<Customer> _customers;
        private List<Device> _devices;
        private string _selectedCustomer;
        private string _dateFrom;
        private string _dateTo;

        private StringCompare _stringCompare = new StringCompare();

        public Form9(List<Customer> customers, List<Device> devices, List<Repair> repairs)
        {
            InitializeComponent();
            _customers = customers;
            _devices = devices;
            _repairs = repairs;
            ShowRepairs(flowLayoutPanel1, "all", "none", "none");
            comboBoxCustomers.Items.Add("all");
            foreach (var customer in _customers)
            {
                comboBoxCustomers.Items.Add(customer.Name);
            }

            comboBoxCustomers.SelectedIndex = 0;

        }

        private void ShowRepairs(Control FlowLayoutPanel, string customerName, string date1, string date2)
        {
            _repairs.Clear();

            // Parsing date1 and date2
            if (!DateTime.TryParseExact(date1, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date1Value))
            {
                date1Value = DateTime.MinValue;
                date1 = "none";
            }
            if (!DateTime.TryParseExact(date2, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date2Value))
            {
                date2Value = DateTime.MaxValue;
                date2 = "none";
            }

            // Adjusting date1 if it's later than date2
            if (date1Value > date2Value)
            {
                date1Value = date2Value.AddDays(-1);
                date1 = date1Value.ToString("yyyy-MM-dd");
            }

            foreach (var customer in _customers.Where(c => customerName == "all" || c.Name == customerName))
            {
                foreach (var device in customer.Devices)
                {
                    foreach (var repair in device.Repair)
                    {
                        if (!DateTime.TryParseExact(repair.DateIn, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var repairDate))
                            continue;
                        if ((repairDate < date1Value || repairDate > date2Value) &&
                            (date1 != "none" || repairDate > date2Value) &&
                            (date2 != "none" || repairDate < date1Value)) continue;
                        _repairs.Add(repair);
                        var panel = new Panel();
                        panel.Size = new Size(200, 200);
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Margin = new Padding(5);
                        panel.Tag = repair;
                        var label1 = new Label();
                        label1.Text = "Customer: " + customer.Name;
                        label1.AutoSize = true;
                        label1.Location = new Point(10, 10);
                        panel.Controls.Add(label1);
                        var label2 = new Label();
                        label2.Text = "Device: " + device.DeviceType;
                        label2.AutoSize = true;
                        label2.Location = new Point(10, 30);
                        panel.Controls.Add(label2);
                        var label3 = new Label();
                        label3.Text = "Serial Key: " + device.SerialKey;
                        label3.AutoSize = true;
                        label3.Location = new Point(10, 50);
                        panel.Controls.Add(label3);
                        var label4 = new Label();
                        label4.Text = "Date In: " + repair.DateIn;
                        label4.AutoSize = true;
                        label4.Location = new Point(10, 70);
                        panel.Controls.Add(label4);
                        var label5 = new Label();
                        label5.Text = "Date Out: " + repair.DateOut;
                        label5.AutoSize = true;
                        label5.Location = new Point(10, 90);
                        panel.Controls.Add(label5);
                        var label6 = new Label();
                        label6.Text = "Description: " + repair.Description;
                        label6.AutoSize = true;
                        label6.Location = new Point(10, 110);
                        panel.Controls.Add(label6);
                        var button = new Button();
                        button.Text = "Delete";
                        button.Location = new Point(10, 130);
                        button.Click += (sender, args) =>
                        {
                            if (DeleteRepair(repair))
                            {
                                panel.Dispose();
                            }

                        };
                        panel.Controls.Add(button);
                        FlowLayoutPanel.Controls.Add(panel);
                    }
                }
            }
        }

        private bool DeleteRepair(Repair r)
        {
            // Delete the repair from the database
            try
            {
                using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                dbConnection.Open();
                using var cmd = new SQLiteCommand(dbConnection);
                cmd.CommandText = "DELETE FROM Repair WHERE ID = @Id";
                cmd.Parameters.AddWithValue("@Id", r.Id);
                cmd.ExecuteNonQuery();
                dbConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            ShowRepairs(flowLayoutPanel1, comboBoxCustomers.SelectedItem.ToString(), "none", "none");
            _selectedCustomer = comboBoxCustomers.SelectedItem.ToString();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            _dateFrom = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
            flowLayoutPanel1.Controls.Clear();
            ShowRepairs(flowLayoutPanel1, _selectedCustomer, _dateFrom, _dateTo != "none" ? _dateTo : "none");
        }

        private void dateTimePickerFinish_ValueChanged(object sender, EventArgs e)
        {
            _dateTo = dateTimePickerFinish.Value.ToString("yyyy-MM-dd");
            flowLayoutPanel1.Controls.Clear();
            ShowRepairs(flowLayoutPanel1, _selectedCustomer, _dateFrom != "none" ? _dateFrom : "none", _dateTo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _selectedCustomer = "all";
            _dateFrom = "none";
            _dateTo = "none";
            comboBoxCustomers.SelectedIndex = 0;
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerFinish.Value = DateTime.Now;
            flowLayoutPanel1.Controls.Clear();
            ShowRepairs(flowLayoutPanel1, "all", "none", "none");
        }
    }
}

