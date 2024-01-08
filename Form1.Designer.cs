namespace OptionCo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCustomer = new System.Windows.Forms.Button();
            this.buttonDevice = new System.Windows.Forms.Button();
            this.buttonRepair = new System.Windows.Forms.Button();
            this.buttonBoth = new System.Windows.Forms.Button();
            this.buttonDeleteCustomer = new System.Windows.Forms.Button();
            this.buttonDeleteDevice = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.buttonSearchBySerial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSearchByName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonShowRepair = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonCustomer);
            this.flowLayoutPanel1.Controls.Add(this.buttonDevice);
            this.flowLayoutPanel1.Controls.Add(this.buttonRepair);
            this.flowLayoutPanel1.Controls.Add(this.buttonBoth);
            this.flowLayoutPanel1.Controls.Add(this.buttonDeleteCustomer);
            this.flowLayoutPanel1.Controls.Add(this.buttonDeleteDevice);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.buttonShowRepair);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(179, 444);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonCustomer
            // 
            this.buttonCustomer.Location = new System.Drawing.Point(3, 3);
            this.buttonCustomer.Name = "buttonCustomer";
            this.buttonCustomer.Size = new System.Drawing.Size(83, 62);
            this.buttonCustomer.TabIndex = 0;
            this.buttonCustomer.Text = "Add Customer";
            this.buttonCustomer.UseVisualStyleBackColor = true;
            this.buttonCustomer.Click += new System.EventHandler(this.buttonCustomer_Click);
            // 
            // buttonDevice
            // 
            this.buttonDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDevice.Location = new System.Drawing.Point(92, 3);
            this.buttonDevice.Name = "buttonDevice";
            this.buttonDevice.Size = new System.Drawing.Size(83, 62);
            this.buttonDevice.TabIndex = 1;
            this.buttonDevice.Text = "Add Device";
            this.buttonDevice.UseVisualStyleBackColor = true;
            this.buttonDevice.Click += new System.EventHandler(this.buttonDevice_Click);
            // 
            // buttonRepair
            // 
            this.buttonRepair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonRepair.Location = new System.Drawing.Point(3, 71);
            this.buttonRepair.Name = "buttonRepair";
            this.buttonRepair.Size = new System.Drawing.Size(83, 62);
            this.buttonRepair.TabIndex = 6;
            this.buttonRepair.Text = "Add Repair";
            this.buttonRepair.UseVisualStyleBackColor = true;
            this.buttonRepair.Click += new System.EventHandler(this.buttonRepair_Click);
            // 
            // buttonBoth
            // 
            this.buttonBoth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonBoth.Location = new System.Drawing.Point(92, 71);
            this.buttonBoth.Name = "buttonBoth";
            this.buttonBoth.Size = new System.Drawing.Size(83, 62);
            this.buttonBoth.TabIndex = 2;
            this.buttonBoth.Text = "Add New";
            this.buttonBoth.UseVisualStyleBackColor = true;
            this.buttonBoth.Click += new System.EventHandler(this.buttonBoth_Click);
            // 
            // buttonDeleteCustomer
            // 
            this.buttonDeleteCustomer.Location = new System.Drawing.Point(3, 139);
            this.buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            this.buttonDeleteCustomer.Size = new System.Drawing.Size(83, 62);
            this.buttonDeleteCustomer.TabIndex = 3;
            this.buttonDeleteCustomer.Text = "Delete Customer";
            this.buttonDeleteCustomer.UseVisualStyleBackColor = true;
            this.buttonDeleteCustomer.Click += new System.EventHandler(this.buttonDeleteCustomer_Click);
            // 
            // buttonDeleteDevice
            // 
            this.buttonDeleteDevice.Location = new System.Drawing.Point(92, 139);
            this.buttonDeleteDevice.Name = "buttonDeleteDevice";
            this.buttonDeleteDevice.Size = new System.Drawing.Size(83, 62);
            this.buttonDeleteDevice.TabIndex = 4;
            this.buttonDeleteDevice.Text = "Delete Device";
            this.buttonDeleteDevice.UseVisualStyleBackColor = true;
            this.buttonDeleteDevice.Click += new System.EventHandler(this.buttonDeleteDevice_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 62);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete a Repair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox3);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.buttonSearchBySerial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxSerial);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.buttonSearchByName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(188, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 444);
            this.panel1.TabIndex = 1;
            // 
            // listBox3
            // 
            this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(177, 340);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(429, 95);
            this.listBox3.TabIndex = 10;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(0, 238);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 9;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // buttonSearchBySerial
            // 
            this.buttonSearchBySerial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSearchBySerial.Location = new System.Drawing.Point(64, 189);
            this.buttonSearchBySerial.Name = "buttonSearchBySerial";
            this.buttonSearchBySerial.Size = new System.Drawing.Size(106, 23);
            this.buttonSearchBySerial.TabIndex = 8;
            this.buttonSearchBySerial.Text = "Search";
            this.buttonSearchBySerial.UseVisualStyleBackColor = true;
            this.buttonSearchBySerial.Click += new System.EventHandler(this.buttonSearchBySerial_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(3, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Serial:";
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSerial.Location = new System.Drawing.Point(3, 212);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.Size = new System.Drawing.Size(167, 20);
            this.textBoxSerial.TabIndex = 6;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(177, 191);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(429, 112);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(177, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 112);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // buttonSearchByName
            // 
            this.buttonSearchByName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearchByName.Location = new System.Drawing.Point(64, 6);
            this.buttonSearchByName.Name = "buttonSearchByName";
            this.buttonSearchByName.Size = new System.Drawing.Size(106, 23);
            this.buttonSearchByName.TabIndex = 2;
            this.buttonSearchByName.Text = "Search";
            this.buttonSearchByName.UseVisualStyleBackColor = true;
            this.buttonSearchByName.Click += new System.EventHandler(this.buttonSearchByName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxName.Location = new System.Drawing.Point(3, 29);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(167, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // buttonShowRepair
            // 
            this.buttonShowRepair.Location = new System.Drawing.Point(92, 207);
            this.buttonShowRepair.Name = "buttonShowRepair";
            this.buttonShowRepair.Size = new System.Drawing.Size(83, 62);
            this.buttonShowRepair.TabIndex = 7;
            this.buttonShowRepair.Text = "Show All Repairs";
            this.buttonShowRepair.UseVisualStyleBackColor = true;
            this.buttonShowRepair.Click += new System.EventHandler(this.buttonShowRepair_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button buttonRepair;

        private System.Windows.Forms.Button buttonBoth;

        private System.Windows.Forms.Button buttonCustomer;
        private System.Windows.Forms.Button buttonDevice;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSearchByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button buttonSearchBySerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSerial;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button buttonDeleteCustomer;
        private System.Windows.Forms.Button buttonDeleteDevice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonShowRepair;
    }
}

