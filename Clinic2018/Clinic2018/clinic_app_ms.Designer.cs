﻿namespace Clinic2018
{
    partial class clinic_app_ms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb33 = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lb22 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb11 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbliddoc = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bt3 = new System.Windows.Forms.Button();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.lb9 = new System.Windows.Forms.Label();
            this.lb8 = new System.Windows.Forms.Label();
            this.lbldoc = new System.Windows.Forms.Label();
            this.lb6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblidapp = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.btnapp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbldocname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "การนัดหมายจากแพทย์";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(179, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(123, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ค้นหา";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(16, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(508, 197);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "รหัสนัดหมาย";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "หมายเลขบัตรประชาชน";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ชื่อ-นามสกุล";
            this.Column3.Name = "Column3";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "รหัสแพทย์";
            this.Column7.Name = "Column7";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "แพทย์ผู้ทำการรักษา";
            this.Column4.Name = "Column4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb33);
            this.groupBox2.Controls.Add(this.lb3);
            this.groupBox2.Controls.Add(this.lb22);
            this.groupBox2.Controls.Add(this.lb2);
            this.groupBox2.Controls.Add(this.lb11);
            this.groupBox2.Controls.Add(this.lb1);
            this.groupBox2.Location = new System.Drawing.Point(590, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 107);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายละเอียดคนไข้";
            // 
            // lb33
            // 
            this.lb33.AutoSize = true;
            this.lb33.Location = new System.Drawing.Point(154, 68);
            this.lb33.Name = "lb33";
            this.lb33.Size = new System.Drawing.Size(10, 13);
            this.lb33.TabIndex = 0;
            this.lb33.Text = "-";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Location = new System.Drawing.Point(94, 68);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(54, 13);
            this.lb3.TabIndex = 0;
            this.lb3.Text = "ชื่อ - สกุล :";
            // 
            // lb22
            // 
            this.lb22.AutoSize = true;
            this.lb22.Location = new System.Drawing.Point(154, 47);
            this.lb22.Name = "lb22";
            this.lb22.Size = new System.Drawing.Size(10, 13);
            this.lb22.TabIndex = 0;
            this.lb22.Text = "-";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(70, 47);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(78, 13);
            this.lb2.TabIndex = 0;
            this.lb2.Text = "บัตรประชาชน :";
            // 
            // lb11
            // 
            this.lb11.AutoSize = true;
            this.lb11.Location = new System.Drawing.Point(154, 26);
            this.lb11.Name = "lb11";
            this.lb11.Size = new System.Drawing.Size(10, 13);
            this.lb11.TabIndex = 0;
            this.lb11.Text = "-";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(101, 26);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(47, 13);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "รหัสนัด :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtremark);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lbliddoc);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.bt3);
            this.groupBox3.Controls.Add(this.dtp1);
            this.groupBox3.Controls.Add(this.lb9);
            this.groupBox3.Controls.Add(this.lb8);
            this.groupBox3.Controls.Add(this.lbldoc);
            this.groupBox3.Controls.Add(this.lb6);
            this.groupBox3.Location = new System.Drawing.Point(590, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 223);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "นัดหมาย";
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(154, 116);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(168, 50);
            this.txtremark.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(90, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "หมายเหตุ :";
            // 
            // lbliddoc
            // 
            this.lbliddoc.AutoSize = true;
            this.lbliddoc.Location = new System.Drawing.Point(154, 16);
            this.lbliddoc.Name = "lbliddoc";
            this.lbliddoc.Size = new System.Drawing.Size(10, 13);
            this.lbliddoc.TabIndex = 15;
            this.lbliddoc.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(83, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "รหัสแพทย์ :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(157, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 20);
            this.textBox2.TabIndex = 13;
            // 
            // bt3
            // 
            this.bt3.Location = new System.Drawing.Point(178, 182);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(100, 23);
            this.bt3.TabIndex = 4;
            this.bt3.Text = "นัดหมาย";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(157, 61);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(103, 20);
            this.dtp1.TabIndex = 2;
            // 
            // lb9
            // 
            this.lb9.AutoSize = true;
            this.lb9.Location = new System.Drawing.Point(113, 89);
            this.lb9.Name = "lb9";
            this.lb9.Size = new System.Drawing.Size(35, 13);
            this.lb9.TabIndex = 0;
            this.lb9.Text = "เวลา :";
            // 
            // lb8
            // 
            this.lb8.AutoSize = true;
            this.lb8.Location = new System.Drawing.Point(114, 65);
            this.lb8.Name = "lb8";
            this.lb8.Size = new System.Drawing.Size(34, 13);
            this.lb8.TabIndex = 0;
            this.lb8.Text = "วันที่ :";
            // 
            // lbldoc
            // 
            this.lbldoc.AutoSize = true;
            this.lbldoc.Location = new System.Drawing.Point(154, 41);
            this.lbldoc.Name = "lbldoc";
            this.lbldoc.Size = new System.Drawing.Size(10, 13);
            this.lbldoc.TabIndex = 0;
            this.lbldoc.Text = "-";
            // 
            // lb6
            // 
            this.lb6.AutoSize = true;
            this.lb6.Location = new System.Drawing.Point(83, 41);
            this.lb6.Name = "lb6";
            this.lb6.Size = new System.Drawing.Size(65, 13);
            this.lb6.TabIndex = 0;
            this.lb6.Text = "แพทย์ผู้นัด :";
            this.lb6.Click += new System.EventHandler(this.lb6_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(12, 390);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(543, 308);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ใบนัดหมาย";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(179, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(211, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(123, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ค้นหา";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column5,
            this.Column6,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView2.Location = new System.Drawing.Point(16, 68);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(508, 197);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "รหัสนัดหมาย";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "วันที่นัดหมาย";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "เวลานัดหมาย";
            this.Column6.Name = "Column6";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "หมายเลขบัตรประชาชน";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ชื่อ-นามสกุล";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "แพทย์ผู้ทำการรักษา";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblidapp);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.lblname);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.lbltime);
            this.groupBox5.Controls.Add(this.lbldate);
            this.groupBox5.Controls.Add(this.btnapp);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.lbldocname);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(590, 429);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(449, 226);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ข้อมูลใบนัดหมาย";
            // 
            // lblidapp
            // 
            this.lblidapp.AutoSize = true;
            this.lblidapp.Location = new System.Drawing.Point(141, 29);
            this.lblidapp.Name = "lblidapp";
            this.lblidapp.Size = new System.Drawing.Size(10, 13);
            this.lblidapp.TabIndex = 10;
            this.lblidapp.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "รหัสอ้างอิงนัดหมาย:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(141, 130);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(10, 13);
            this.lblname.TabIndex = 8;
            this.lblname.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "ชื่อคนไข้ :";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(141, 102);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(10, 13);
            this.lbltime.TabIndex = 6;
            this.lbltime.Text = "-";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(141, 78);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(10, 13);
            this.lbldate.TabIndex = 5;
            this.lbldate.Text = "-";
            // 
            // btnapp
            // 
            this.btnapp.Location = new System.Drawing.Point(178, 171);
            this.btnapp.Name = "btnapp";
            this.btnapp.Size = new System.Drawing.Size(100, 23);
            this.btnapp.TabIndex = 4;
            this.btnapp.Text = "บันทึก";
            this.btnapp.UseVisualStyleBackColor = true;
            this.btnapp.Click += new System.EventHandler(this.btnapp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "เวลา :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "วันที่ :";
            // 
            // lbldocname
            // 
            this.lbldocname.AutoSize = true;
            this.lbldocname.Location = new System.Drawing.Point(141, 53);
            this.lbldocname.Name = "lbldocname";
            this.lbldocname.Size = new System.Drawing.Size(10, 13);
            this.lbldocname.TabIndex = 0;
            this.lbldocname.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "แพทย์ผู้นัด :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 31);
            this.label5.TabIndex = 15;
            this.label5.Text = "ข้อมูลการนัดหมาย";
            // 
            // clinic_app_ms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 749);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "clinic_app_ms";
            this.Text = "การนัดหมาย";
            this.Load += new System.EventHandler(this.clinic_app_ms_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb33;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lb22;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb11;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label lb9;
        private System.Windows.Forms.Label lb8;
        private System.Windows.Forms.Label lbldoc;
        private System.Windows.Forms.Label lb6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnapp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbldocname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lbliddoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label lblidapp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
    }
}