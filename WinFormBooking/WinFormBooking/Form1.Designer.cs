namespace WinFormBooking
{
    partial class frmBooking
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flightNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airways = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leaveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.landTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.cmbLeave = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbxlandTime = new System.Windows.Forms.TextBox();
            this.tbxDestination = new System.Windows.Forms.TextBox();
            this.tbxAirways = new System.Windows.Forms.TextBox();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.tbxLeaveTime = new System.Windows.Forms.TextBox();
            this.tbxLeaveCity = new System.Windows.Forms.TextBox();
            this.tbxFlightNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.cmbDestination);
            this.groupBox1.Controls.Add(this.cmbLeave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "航班信息";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(403, 19);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flightNo,
            this.airways,
            this.leaveTime,
            this.landTime,
            this.price});
            this.dataGridView1.Location = new System.Drawing.Point(7, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(470, 153);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // flightNo
            // 
            this.flightNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.flightNo.DataPropertyName = "flightNo";
            this.flightNo.FillWeight = 1.269036F;
            this.flightNo.HeaderText = "航班号";
            this.flightNo.Name = "flightNo";
            this.flightNo.ReadOnly = true;
            this.flightNo.Width = 60;
            // 
            // airways
            // 
            this.airways.DataPropertyName = "airways";
            this.airways.FillWeight = 0.9327411F;
            this.airways.HeaderText = "航空公司";
            this.airways.Name = "airways";
            this.airways.ReadOnly = true;
            // 
            // leaveTime
            // 
            this.leaveTime.DataPropertyName = "leaveTime";
            this.leaveTime.FillWeight = 0.9327411F;
            this.leaveTime.HeaderText = "出发时间";
            this.leaveTime.Name = "leaveTime";
            this.leaveTime.ReadOnly = true;
            // 
            // landTime
            // 
            this.landTime.DataPropertyName = "landTime";
            this.landTime.FillWeight = 0.9327411F;
            this.landTime.HeaderText = "到达时间";
            this.landTime.Name = "landTime";
            this.landTime.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.FillWeight = 0.9327411F;
            this.price.HeaderText = "成人票价(元)";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // cmbDestination
            // 
            this.cmbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(276, 21);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(121, 20);
            this.cmbDestination.TabIndex = 3;
            // 
            // cmbLeave
            // 
            this.cmbLeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeave.FormattingEnabled = true;
            this.cmbLeave.Location = new System.Drawing.Point(73, 21);
            this.cmbLeave.Name = "cmbLeave";
            this.cmbLeave.Size = new System.Drawing.Size(121, 20);
            this.cmbLeave.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "目的地：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "出发地：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.tbxlandTime);
            this.groupBox2.Controls.Add(this.tbxDestination);
            this.groupBox2.Controls.Add(this.tbxAirways);
            this.groupBox2.Controls.Add(this.tbxPrice);
            this.groupBox2.Controls.Add(this.tbxLeaveTime);
            this.groupBox2.Controls.Add(this.tbxLeaveCity);
            this.groupBox2.Controls.Add(this.tbxFlightNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 174);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "航班预定";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(104, 135);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(125, 21);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(321, 134);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(125, 21);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // tbxlandTime
            // 
            this.tbxlandTime.Location = new System.Drawing.Point(320, 79);
            this.tbxlandTime.Name = "tbxlandTime";
            this.tbxlandTime.ReadOnly = true;
            this.tbxlandTime.Size = new System.Drawing.Size(125, 21);
            this.tbxlandTime.TabIndex = 18;
            // 
            // tbxDestination
            // 
            this.tbxDestination.Location = new System.Drawing.Point(320, 54);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.ReadOnly = true;
            this.tbxDestination.Size = new System.Drawing.Size(125, 21);
            this.tbxDestination.TabIndex = 17;
            // 
            // tbxAirways
            // 
            this.tbxAirways.Location = new System.Drawing.Point(320, 27);
            this.tbxAirways.Name = "tbxAirways";
            this.tbxAirways.ReadOnly = true;
            this.tbxAirways.Size = new System.Drawing.Size(125, 21);
            this.tbxAirways.TabIndex = 16;
            // 
            // tbxPrice
            // 
            this.tbxPrice.Location = new System.Drawing.Point(104, 108);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.ReadOnly = true;
            this.tbxPrice.Size = new System.Drawing.Size(125, 21);
            this.tbxPrice.TabIndex = 15;
            // 
            // tbxLeaveTime
            // 
            this.tbxLeaveTime.Location = new System.Drawing.Point(104, 81);
            this.tbxLeaveTime.Name = "tbxLeaveTime";
            this.tbxLeaveTime.ReadOnly = true;
            this.tbxLeaveTime.Size = new System.Drawing.Size(125, 21);
            this.tbxLeaveTime.TabIndex = 14;
            // 
            // tbxLeaveCity
            // 
            this.tbxLeaveCity.Location = new System.Drawing.Point(104, 54);
            this.tbxLeaveCity.Name = "tbxLeaveCity";
            this.tbxLeaveCity.ReadOnly = true;
            this.tbxLeaveCity.Size = new System.Drawing.Size(125, 21);
            this.tbxLeaveCity.TabIndex = 13;
            // 
            // tbxFlightNo
            // 
            this.tbxFlightNo.Location = new System.Drawing.Point(104, 27);
            this.tbxFlightNo.Name = "tbxFlightNo";
            this.tbxFlightNo.ReadOnly = true;
            this.tbxFlightNo.Size = new System.Drawing.Size(125, 21);
            this.tbxFlightNo.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "航空公司：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "目的地：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(249, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "到达时间：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(249, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "出发日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "预订数量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "成人票价：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出发时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "出发地：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "航班号：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(333, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "预订";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(426, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "机票订单系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.ComboBox cmbLeave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tbxlandTime;
        private System.Windows.Forms.TextBox tbxDestination;
        private System.Windows.Forms.TextBox tbxAirways;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.TextBox tbxLeaveTime;
        private System.Windows.Forms.TextBox tbxLeaveCity;
        private System.Windows.Forms.TextBox tbxFlightNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn flightNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn airways;
        private System.Windows.Forms.DataGridViewTextBoxColumn leaveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn landTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

