using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptionCo
{
    public partial class Form9 : Form
    {
        private List<Repair> _repairs;
        private readonly DBConnection _dbConnection = new DBConnection("option.db");
        private List<Customer> _customers;
        private List<Device> _devices;
        private StringCompare _stringCompare = new StringCompare();
        public Form9(List<Customer> customers, List<Device> devices, List<Repair> repairs)
        {
            InitializeComponent();
            _customers = customers;
            _devices = devices;
            _repairs = repairs;
            ShowRepairs(flowLayoutPanel1);
        }

        private void ShowRepairs(Control FlowLayoutPanel)
        {
            FlowLayoutPanel.Controls.Clear();
            // sort the repairs, so that they are shown in the order first: Pending, then: Completed Repair, the Finished
            var sortingOrder = new Dictionary<string, int>()
            {
                {"Pending", 1},
                {"Completed Repair", 2},
                {"Finished", 3}
            };
            var sortedRepairs = _repairs.OrderBy(r => sortingOrder[r.Status]).ToList();
            // now show an interactive UI for each repair, you should show the status, date in, and if the status is not finished, a button to change the status and a datetime picker for the dateout when the user elects to change the status (the datetime picker should be hidden by default and activated once and only once the status is set to Finish, use a combobox to change that)
            foreach (var repair in sortedRepairs)
            {
                Panel panel = new Panel();
                panel.Width = FlowLayoutPanel.Width;
                panel.Height = 250;  // Set a reasonable height, adjust as needed

                Label statusLabel = new Label();
                statusLabel.Text = "Status: " + repair.Status;
                statusLabel.Location = new Point(10, 10);  // Adjust the position as needed
                panel.Controls.Add(statusLabel);

                Label dateInLabel = new Label();
                dateInLabel.Text = "Date In: " + repair.DateIn.ToString();
                dateInLabel.Location = new Point(10, 30);  // Adjust the position as needed
                panel.Controls.Add(dateInLabel);

                if (repair.Status != "Finished")
                {
                    Button changeStatusButton = new Button();
                    changeStatusButton.Text = "Change Status";
                    changeStatusButton.Click += ChangeStatusButton_Click;
                    changeStatusButton.Location = new Point(10, 50);  // Adjust the position as needed
                    panel.Controls.Add(changeStatusButton);

                    DateTimePicker dateOutPicker = new DateTimePicker();
                    dateOutPicker.Visible = false;
                    dateOutPicker.Location = new Point(10, 70);  // Adjust the position as needed
                    panel.Controls.Add(dateOutPicker);

                    Label customerNameLabel = new Label();
                    Customer customer = _customers.FirstOrDefault(c => c.Id == repair.CustomerId);
                    customerNameLabel.Text = "Customer Name: " + customer.Name;
                    customerNameLabel.Location = new Point(10, 90);  // Adjust the position as needed
                    panel.Controls.Add(customerNameLabel);

                    Label customerMobileLabel = new Label();
                    customerMobileLabel.Text = "Customer Mobile: " + customer.MobilePhone;
                    customerMobileLabel.Location = new Point(10, 110);  // Adjust the position as needed
                    panel.Controls.Add(customerMobileLabel);

                    Label deviceSerialLabel = new Label();
                    Device device = _devices.FirstOrDefault(d => d.Id == repair.DeviceId);
                    deviceSerialLabel.Text = "Device Serial: " + device.SerialKey;
                    deviceSerialLabel.Location = new Point(10, 130);  // Adjust the position as needed
                    panel.Controls.Add(deviceSerialLabel);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description: " + repair.Description;
                    descriptionLabel.Location = new Point(10, 150);  // Adjust the position as needed
                    panel.Controls.Add(descriptionLabel);

                    Button deleteButton = new Button();
                    deleteButton.Name = repair.Id.ToString();
                    deleteButton.Text = "Delete Repair";
                    deleteButton.Click += DeleteButton_Click;
                    deleteButton.Location = new Point(10, 170);  // Adjust the position as needed
                    panel.Controls.Add(deleteButton);
                }
                FlowLayoutPanel.Controls.Add(panel);
            }

            void ChangeStatusButton_Click(object sender, EventArgs e)
            {
                Button button = (Button)sender;
                Panel panel = (Panel)button.Parent;
                DateTimePicker dateOutPicker = panel.Controls.OfType<DateTimePicker>().FirstOrDefault();
                dateOutPicker.Visible = true;
            }

            void DeleteButton_Click(object sender, EventArgs e)
            {
                Button button = (Button)sender;
                Panel panel = (Panel)button.Parent;
                FlowLayoutPanel.Controls.Remove(panel);
                foreach (var repair in _repairs.Where(r => r.Id == int.Parse(button.Name)))
                {
                    DeleteRepair(repair);
                    _repairs.Remove(repair);
                    return;
                }

            }
            // other than that the UI should also have the the customer name,customer mobile phone, device serial number, and the description of the repair, also a button to delete the repair. each button will be associate with an event of course
            // The customer associated with the repair can be found by using the customer id of the repair and the customer list
            // keep in mind the flow direction of the flow layout panel is left to right and I want each recording to always span an entire row of the layout panel, do it by adding a panel to the flow layout panel, with width equal to the width of the flowlayout panel and then adding the controls to the panel
            // the events for the combobox and the buttons have to be separate functions, just reference them and they are going to be created later
            


        }

        private void DeleteRepair(Repair r)
        {
            //delete the 
        }
    }
}
