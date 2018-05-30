using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dddd dd-MM-yyyy";

            // DateTime myDT = new DateTime(dateTimePicker1.DataBindings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            string date_birth = String.Format("{0:dddd}", date);

            MessageBox.Show("" + date_birth);
        }
    }
}
