using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace OptionCo
{
    public partial class Form4 : Form
    {
        private bool _isFinished = false;
        private bool _isOther = false;
        public Form4()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxHome.Text = "";
            textBoxMobile.Text = "";
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxSerial.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
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

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBoxName.Text == "" || textBoxHome.Text == "" || textBoxMobile.Text == "" ||
                    textBoxSerial.Text == "" || comboBox1.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all the fields");
                }
                else
                {
                    using var dbConnection = new SQLiteConnection("Data Source=option.db");
                    dbConnection.Open();
                    using var cmd = new SQLiteCommand(dbConnection);
                    cmd.CommandText =
                        "INSERT INTO Customers (Name, Email, MobilePhone, HomePhone) VALUES (@Name, @Email, @Mobile, @Home)";
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@Home", textBoxHome.Text);
                    cmd.Parameters.AddWithValue("@Mobile", textBoxMobile.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT * FROM Customers WHERE Name = @Name";
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    using var reader = cmd.ExecuteReader();
                    var customerId = 0;
                    while (reader.Read())
                    {
                        customerId = reader.GetInt32(0);
                    }
                    reader.Close();

                    cmd.CommandText =
                        "INSERT INTO Devices (SerialKey, CustomerId, DeviceType) VALUES (@Serial, @CustomerId, @DeviceType)";
                    cmd.Parameters.AddWithValue("@Serial", textBoxSerial.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
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
                    cmd.Parameters.AddWithValue("@DeviceType", comboBox1.SelectedIndex.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT * FROM Devices WHERE SerialKey = @Serial";
                    cmd.Parameters.AddWithValue("@Serial", textBoxSerial.Text);
                    using var reader2 = cmd.ExecuteReader();
                    var deviceId = 0;
                    while (reader2.Read())
                    {
                        deviceId = reader2.GetInt32(0);
                    }
                    reader2.Close();

                    cmd.CommandText =
                        "INSERT INTO Repair (DeviceId, Status, DateIn, DateOut, CustomerId, Description) VALUES (@DeviceId, @Status, @DateIn, @DateOut, @CustomerId, @Description)";
                    cmd.Parameters.AddWithValue("@DeviceId", deviceId);
                    cmd.Parameters.AddWithValue("@Status", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DateIn", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    if (_isFinished)
                    {
                        cmd.Parameters.AddWithValue("@DateOut", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DateOut", "");
                    }

                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Description", richTextBoxDescription.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully added to database");
                    Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
    }
}
