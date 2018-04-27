namespace Clinic2018
{
    partial class clinc_nurse_service
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblopd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.txthearth = new System.Windows.Forms.TextBox();
            this.txth = new System.Windows.Forms.TextBox();
            this.txtw = new System.Windows.Forms.TextBox();
            this.txts2 = new System.Windows.Forms.TextBox();
            this.txts1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblsername = new System.Windows.Forms.Label();
            this.lblidcard = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ลำดับคิว = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.เวลา = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ชื่อสกุล = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.รหัสคนไข้ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataSet2 = new Clinic2018.DataSet2();
            this.queuevisitrecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.queue_visit_recordTableAdapter = new Clinic2018.DataSet2TableAdapters.queue_visit_recordTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queuevisitrecordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 749);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.lblopd);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.lblsername);
            this.groupBox3.Controls.Add(this.lblidcard);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(834, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 577);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ข้อมูลคนไข้";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 455);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 38);
            this.button3.TabIndex = 8;
            this.button3.Text = "ส่งข้อมูลให้แพทย์";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblopd
            // 
            this.lblopd.AutoSize = true;
            this.lblopd.Location = new System.Drawing.Point(149, 53);
            this.lblopd.Name = "lblopd";
            this.lblopd.Size = new System.Drawing.Size(10, 13);
            this.lblopd.TabIndex = 6;
            this.lblopd.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "รหัสเวชระเบียน :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtremark);
            this.groupBox4.Controls.Add(this.txthearth);
            this.groupBox4.Controls.Add(this.txth);
            this.groupBox4.Controls.Add(this.txtw);
            this.groupBox4.Controls.Add(this.txts2);
            this.groupBox4.Controls.Add(this.txts1);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(96, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(334, 331);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "สุขภาพ";
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(30, 193);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtremark.Size = new System.Drawing.Size(248, 132);
            this.txtremark.TabIndex = 2;
            this.txtremark.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // txthearth
            // 
            this.txthearth.Location = new System.Drawing.Point(145, 134);
            this.txthearth.Name = "txthearth";
            this.txthearth.Size = new System.Drawing.Size(100, 20);
            this.txthearth.TabIndex = 2;
            // 
            // txth
            // 
            this.txth.Location = new System.Drawing.Point(145, 97);
            this.txth.Name = "txth";
            this.txth.Size = new System.Drawing.Size(100, 20);
            this.txth.TabIndex = 2;
            // 
            // txtw
            // 
            this.txtw.Location = new System.Drawing.Point(145, 67);
            this.txtw.Name = "txtw";
            this.txtw.Size = new System.Drawing.Size(100, 20);
            this.txtw.TabIndex = 2;
            // 
            // txts2
            // 
            this.txts2.Location = new System.Drawing.Point(145, 43);
            this.txts2.Name = "txts2";
            this.txts2.Size = new System.Drawing.Size(100, 20);
            this.txts2.TabIndex = 2;
            // 
            // txts1
            // 
            this.txts1.Location = new System.Drawing.Point(145, 13);
            this.txts1.Name = "txts1";
            this.txts1.Size = new System.Drawing.Size(100, 20);
            this.txts1.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(27, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "ความดันโลหิตช่วงล่าง :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(95, 137);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "ชีพพร :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(92, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "ส่วนสูง :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(88, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 13);
            this.label25.TabIndex = 1;
            this.label25.Text = "น้ำหนัก :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(27, 170);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "หมายเหตุ :";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(25, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(111, 13);
            this.label33.TabIndex = 1;
            this.label33.Text = "ความดันโลหิตช่วงบน :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "ส่งตรวจ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblsername
            // 
            this.lblsername.AutoSize = true;
            this.lblsername.Location = new System.Drawing.Point(346, 19);
            this.lblsername.Name = "lblsername";
            this.lblsername.Size = new System.Drawing.Size(10, 13);
            this.lblsername.TabIndex = 1;
            this.lblsername.Text = "-";
            // 
            // lblidcard
            // 
            this.lblidcard.AutoSize = true;
            this.lblidcard.Location = new System.Drawing.Point(161, 19);
            this.lblidcard.Name = "lblidcard";
            this.lblidcard.Size = new System.Drawing.Size(10, 13);
            this.lblidcard.TabIndex = 1;
            this.lblidcard.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(286, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "ชื่อ-สกุล :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "เลขบัตรประจำตัวประชาชน : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "บันทึกข้อมูลซักประวัติ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 577);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "คิวบริการ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ลำดับคิว,
            this.เวลา,
            this.ชื่อสกุล,
            this.Column1,
            this.รหัสคนไข้,
            this.Column4,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(813, 544);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ลำดับคิว
            // 
            this.ลำดับคิว.HeaderText = "ลำดับคิว";
            this.ลำดับคิว.Name = "ลำดับคิว";
            this.ลำดับคิว.ReadOnly = true;
            // 
            // เวลา
            // 
            this.เวลา.HeaderText = "เวลา";
            this.เวลา.Name = "เวลา";
            this.เวลา.ReadOnly = true;
            // 
            // ชื่อสกุล
            // 
            this.ชื่อสกุล.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ชื่อสกุล.HeaderText = "ชื่อสกุล";
            this.ชื่อสกุล.Name = "ชื่อสกุล";
            this.ชื่อสกุล.ReadOnly = true;
            this.ชื่อสกุล.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "รหัสประจำตัวประชาชน";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // รหัสคนไข้
            // 
            this.รหัสคนไข้.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.รหัสคนไข้.HeaderText = "รหัสคนไข้";
            this.รหัสคนไข้.Name = "รหัสคนไข้";
            this.รหัสคนไข้.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ที่อยู่";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "วันเดือนปีเกิด";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "เบอร์โทร";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 26);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 725);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1370, 24);
            this.panel3.TabIndex = 3;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // queuevisitrecordBindingSource
            // 
            this.queuevisitrecordBindingSource.DataMember = "queue_visit_record";
            this.queuevisitrecordBindingSource.DataSource = this.dataSet2;
            // 
            // queue_visit_recordTableAdapter
            // 
            this.queue_visit_recordTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "qvr_time";
            this.dataGridViewTextBoxColumn1.HeaderText = "qvr_time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // clinc_nurse_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Name = "clinc_nurse_service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "คิวซักประวัติ - ระบบบริหารจัดการงานบริการงานแพทย์และอนามัย ";
            this.Load += new System.EventHandler(this.clinc_nurse_service_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queuevisitrecordBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblidcard;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblsername;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txthearth;
        private System.Windows.Forms.TextBox txth;
        private System.Windows.Forms.TextBox txtw;
        private System.Windows.Forms.TextBox txts2;
        private System.Windows.Forms.TextBox txts1;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label21;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource queuevisitrecordBindingSource;
        private DataSet2TableAdapters.queue_visit_recordTableAdapter queue_visit_recordTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ลำดับคิว;
        private System.Windows.Forms.DataGridViewTextBoxColumn เวลา;
        private System.Windows.Forms.DataGridViewTextBoxColumn ชื่อสกุล;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn รหัสคนไข้;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label lblopd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}