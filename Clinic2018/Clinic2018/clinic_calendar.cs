﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class clinic_calendar : Form
    {
        public clinic_calendar()
        {
            InitializeComponent();
        }

        private void clinic_calendar_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            this.dateTimePicker2.Show();
        }
    }
}
