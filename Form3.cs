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
    public partial class Form3 : Form
    {
        private List<Device> _devices;
        private List<Customer> _customers;
        private readonly DBConnection _dbConnection = new DBConnection("option.db");
        private bool _isFinished = false;
        private bool _isOther = false;
        public Form3(List<Device> devices, List<Customer> customers)
        {
            InitializeComponent();
            _devices = devices;
            _customers = customers;
            foreach (var c in _customers)
            {
                comboBox2.Items.Add(c.Name);
            }
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSerial.Text = "";
            textBoxOther.Text = "";
            richTextBoxDescription.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            _isFinished = false;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 8)
            {
                textBoxOther.Visible = true;
                textBoxOther.Enabled = true;
                _isOther = true;
            }
            else
            {
                textBoxOther.Visible = false;
                textBoxOther.Enabled = false;
                _isOther = false;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isFinished && textBoxSerial.Text != "")
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText = "INSERT INTO Devices (SerialKey, CustomerId, DeviceType) VALUES (@SerialKey, @CustomerId, @DeviceType)";
                    cmd.Parameters.AddWithValue("@SerialKey", textBoxSerial.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", _customers[comboBox2.SelectedIndex].Id);
                    switch (_isOther)
                    {
                        case true when textBoxOther.Text != "":
                            cmd.Parameters.AddWithValue("@DeviceType", textBoxOther.Text);
                            break;
                        case false:
                            cmd.Parameters.AddWithValue("@DeviceType", comboBox1.Text);
                            break;
                        default:
                            cmd.Parameters.AddWithValue("@DeviceType", comboBox1.Text);
                            break;
                    }
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT * FROM Devices WHERE SerialKey = @SerialKey";
                    cmd.Parameters.AddWithValue("@SerialKey", textBoxSerial.Text);
                    using var reader = cmd.ExecuteReader();
                    var deviceId = 0;
                    while (reader.Read())
                    {
                        deviceId = reader.GetInt32(0);
                    }
                    reader.Close();
                    cmd.CommandText = "INSERT INTO Repair (Description, DateIn, DateOut, Status, CustomerId, DeviceId) VALUES (@Description, @DateIn, @DateOut, @Status, @CustomerId, @DeviceId)";
                    cmd.Parameters.AddWithValue("@Description", richTextBoxDescription.Text);
                    cmd.Parameters.AddWithValue("@DateIn", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateOut", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Status", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", _customers[comboBox2.SelectedIndex].Id);
                    cmd.Parameters.AddWithValue("@DeviceId", deviceId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Repair added successfully!");
                    Close();
                }
                else if(!_isFinished && textBoxSerial.Text != "")
                {
                    using var dbConnection = new SQLiteConnection(_dbConnection.ConnectionString);
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText = "INSERT INTO Devices (SerialKey, CustomerId, DeviceType) VALUES (@SerialKey, @CustomerId, @DeviceType)";
                    cmd.Parameters.AddWithValue("@SerialKey", textBoxSerial.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", _customers[comboBox2.SelectedIndex].Id);
                    switch (_isOther)
                    {
                        case true when textBoxOther.Text != "":
                            cmd.Parameters.AddWithValue("@DeviceType", textBoxOther.Text);
                            break;
                        case false:
                            cmd.Parameters.AddWithValue("@DeviceType", comboBox1.Text);
                            break;
                        default:
                            cmd.Parameters.AddWithValue("@DeviceType", comboBox1.Text);
                            break;
                    }
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT * FROM Devices WHERE SerialKey = @SerialKey";
                    cmd.Parameters.AddWithValue("@SerialKey", textBoxSerial.Text);
                    using var reader = cmd.ExecuteReader();
                    var deviceId = 0;
                    while (reader.Read())
                    {
                        deviceId = reader.GetInt32(0);
                    }

                    reader.Close();
                    cmd.CommandText = "INSERT INTO Repair (Description, DateIn, DateOut, Status, CustomerId, DeviceId) VALUES (@Description, @DateIn, @DateOut, @Status, @CustomerId, @DeviceId)";
                    cmd.Parameters.AddWithValue("@Description", richTextBoxDescription.Text);
                    cmd.Parameters.AddWithValue("@DateIn", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateOut", "Has Not Finished");
                    cmd.Parameters.AddWithValue("@Status", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", _customers[comboBox2.SelectedIndex].Id);
                    cmd.Parameters.AddWithValue("@DeviceId", deviceId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Repair added successfully!");
                    Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
