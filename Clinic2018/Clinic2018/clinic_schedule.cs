using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class clinic_schedule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-CGKA91D\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_schedule()
        {
            InitializeComponent();
            string query = ("select employee_doctor.emp_doc_id,employee_doctor.emp_doc_name , schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();


                dataGridView1.Rows[n].Cells[0].Value = item["emp_doc_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["swd_day_work"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["swd_note"].ToString();



            }


            query = ("select employee_doctor.emp_doc_id,employee_doctor.emp_doc_name , schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 3");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();


                dataGridView2.Rows[n].Cells[0].Value = item["emp_doc_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["swd_day_work"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["swd_start_time"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["room_id"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = item["swd_note"].ToString();



            }

            query = ("select emp_doc_name from employee_doctor");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                // int n = dataGridView1.Rows.Add();

                comboBox1.Items.Add(item["emp_doc_name"].ToString());


            }



        }




        private void button2_Click(object sender, EventArgs e)
        {

        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
         
            txtday.Text = row.Cells[2].Value.ToString();
            txttime.Text = row.Cells[3].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtname1.Text = row.Cells[1].Value.ToString();
            txtday1.Text = row.Cells[2].Value.ToString();
            txttime1.Text = row.Cells[3].Value.ToString();
        }
    }
}
