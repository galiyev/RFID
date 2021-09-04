
namespace TestRFIDWinfForms
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
            this.components = new System.ComponentModel.Container();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.textBox_pc = new System.Windows.Forms.TextBox();
            this.checkBox_pc = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.CheckBox_TID = new System.Windows.Forms.CheckBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ComboBox_IntervalTime = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.Timer_Test_ = new System.Windows.Forms.Timer(this.components);
            this.ListView1_EPC = new System.Windows.Forms.ListView();
            this.listViewCol_Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_Times = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox12.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(59, 30);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(86, 23);
            this.btnOpenPort.TabIndex = 0;
            this.btnOpenPort.Text = "OpenPort";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // textBox_pc
            // 
            this.textBox_pc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_pc.Location = new System.Drawing.Point(197, 71);
            this.textBox_pc.Name = "textBox_pc";
            this.textBox_pc.ReadOnly = true;
            this.textBox_pc.Size = new System.Drawing.Size(34, 20);
            this.textBox_pc.TabIndex = 23;
            this.textBox_pc.Text = "0800";
            // 
            // checkBox_pc
            // 
            this.checkBox_pc.AutoSize = true;
            this.checkBox_pc.Location = new System.Drawing.Point(59, 73);
            this.checkBox_pc.Name = "checkBox_pc";
            this.checkBox_pc.Size = new System.Drawing.Size(127, 17);
            this.checkBox_pc.TabIndex = 22;
            this.checkBox_pc.Text = "Compute and add PC";
            this.checkBox_pc.UseVisualStyleBackColor = true;
            this.checkBox_pc.CheckedChanged += new System.EventHandler(this.checkBox_pc_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.CheckBox_TID);
            this.groupBox12.Controls.Add(this.groupBox33);
            this.groupBox12.Controls.Add(this.button2);
            this.groupBox12.Controls.Add(this.ComboBox_IntervalTime);
            this.groupBox12.Controls.Add(this.label23);
            this.groupBox12.Location = new System.Drawing.Point(59, 108);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(325, 101);
            this.groupBox12.TabIndex = 24;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Query Tag";
            // 
            // CheckBox_TID
            // 
            this.CheckBox_TID.AutoSize = true;
            this.CheckBox_TID.Location = new System.Drawing.Point(226, 65);
            this.CheckBox_TID.Name = "CheckBox_TID";
            this.CheckBox_TID.Size = new System.Drawing.Size(44, 17);
            this.CheckBox_TID.TabIndex = 6;
            this.CheckBox_TID.Text = "TID";
            this.CheckBox_TID.UseVisualStyleBackColor = true;
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.textBox5);
            this.groupBox33.Controls.Add(this.label55);
            this.groupBox33.Controls.Add(this.textBox4);
            this.groupBox33.Controls.Add(this.label54);
            this.groupBox33.Location = new System.Drawing.Point(6, 43);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(209, 52);
            this.groupBox33.TabIndex = 5;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Query TID Parameter";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(167, 15);
            this.textBox5.MaxLength = 2;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(37, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "04";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(126, 25);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(31, 13);
            this.label55.TabIndex = 2;
            this.label55.Text = "Len：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(71, 16);
            this.textBox4.MaxLength = 2;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(37, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "02";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(4, 26);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(57, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "StartAddr：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "Query Tag";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ComboBox_IntervalTime
            // 
            this.ComboBox_IntervalTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_IntervalTime.FormattingEnabled = true;
            this.ComboBox_IntervalTime.Location = new System.Drawing.Point(101, 22);
            this.ComboBox_IntervalTime.Name = "ComboBox_IntervalTime";
            this.ComboBox_IntervalTime.Size = new System.Drawing.Size(120, 21);
            this.ComboBox_IntervalTime.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Read Interval:";
            // 
            // Timer_Test_
            // 
            this.Timer_Test_.Tick += new System.EventHandler(this.Timer_Test__Tick);
            // 
            // ListView1_EPC
            // 
            this.ListView1_EPC.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.ListView1_EPC.AutoArrange = false;
            this.ListView1_EPC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListView1_EPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewCol_Number,
            this.listViewCol_ID,
            this.listViewCol_Length,
            this.listViewCol_Times});
            this.ListView1_EPC.FullRowSelect = true;
            this.ListView1_EPC.GridLines = true;
            this.ListView1_EPC.HideSelection = false;
            this.ListView1_EPC.Location = new System.Drawing.Point(59, 228);
            this.ListView1_EPC.Name = "ListView1_EPC";
            this.ListView1_EPC.Size = new System.Drawing.Size(462, 158);
            this.ListView1_EPC.TabIndex = 25;
            this.ListView1_EPC.UseCompatibleStateImageBehavior = false;
            this.ListView1_EPC.View = System.Windows.Forms.View.Details;
            // 
            // listViewCol_Number
            // 
            this.listViewCol_Number.Text = "No.";
            this.listViewCol_Number.Width = 40;
            // 
            // listViewCol_ID
            // 
            this.listViewCol_ID.Text = "ID";
            this.listViewCol_ID.Width = 200;
            // 
            // listViewCol_Length
            // 
            this.listViewCol_Length.Text = "EPCLength";
            this.listViewCol_Length.Width = 100;
            // 
            // listViewCol_Times
            // 
            this.listViewCol_Times.Text = "Times";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListView1_EPC);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.textBox_pc);
            this.Controls.Add(this.checkBox_pc);
            this.Controls.Add(this.btnOpenPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.TextBox textBox_pc;
        private System.Windows.Forms.CheckBox checkBox_pc;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox CheckBox_TID;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ComboBox_IntervalTime;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer Timer_Test_;
        private System.Windows.Forms.ListView ListView1_EPC;
        private System.Windows.Forms.ColumnHeader listViewCol_Number;
        private System.Windows.Forms.ColumnHeader listViewCol_ID;
        private System.Windows.Forms.ColumnHeader listViewCol_Length;
        private System.Windows.Forms.ColumnHeader listViewCol_Times;
    }
}

