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
    public partial class clinic_timeschedule : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        public clinic_timeschedule()
        {
            InitializeComponent();
            txtstarttime.Text = "0:00";
            txtendtime.Text = "0:00";
      
            string query = ("select schedule_work_doctor.swd_month_work,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id,room.room_status,schedule_work_doctor.swd_timezone,schedule_work_doctor.swd_status from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["swd_month_work"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["swd_end_time"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["swd_note"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["room_status"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["swd_timezone"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["swd_status"].ToString();


            }
            /*
                  query = ("select schedule_work_doctor.swd_status from schedule_work_doctor inner join room on room.room_id = schedule_work_doctor.room_id where schedule_work_doctor.swd_timezone = 'เช้า' OR schedule_work_doctor.swd_timezone = 'บ่าย'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
               lblstatus.Text = sdr["swd_status"].ToString();

                

            }
            */
    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = ("Update schedule_work_doctor set  swd_start_time = '"+txtstarttime.Text+"' ,swd_end_time = '"+txtendtime.Text+"',swd_note = '"+txtremark.Text+"' where room_id = '"+txtroom.Text+"' AND swd_timezone = '"+txttimezone.Text+"' AND swd_day_work = '"+txtday.Text+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);
            clinic_timeschedule doc1 = new clinic_timeschedule();
            doc1.Show();
            clinic_timeschedule clnlog = new clinic_timeschedule();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("เปลี่ยนแปลงตารางเรียบร้อย");

        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtday.Text = row.Cells[1].Value.ToString();
            txtstarttime.Text = row.Cells[2].Value.ToString();
            txtendtime.Text = row.Cells[3].Value.ToString();
            txtremark.Text = row.Cells[4].Value.ToString();
            txtroom.Text = row.Cells[5].Value.ToString();
            txttimezone.Text = row.Cells[7].Value.ToString();
            //lblstatus.Text = row.Cells[8].Value.ToString();
        }
 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // conn.Open();
           string query = ("Update schedule_work_doctor set swd_month_work = '" + comboBox1.SelectedItem.ToString()+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);
            conn.Close();
            clinic_timeschedule doc1 = new clinic_timeschedule();
            doc1.Show();
            clinic_timeschedule clnlog = new clinic_timeschedule();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("จัดตารางปฏิบัติงานแพทย์ประจำเดือน  "  + comboBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



  
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = ("Update schedule_work_doctor set swd_status = '" + comboBox2.SelectedItem.ToString() + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);
            conn.Close();
            clinic_timeschedule doc1 = new clinic_timeschedule();
            doc1.Show();
            clinic_timeschedule clnlog = new clinic_timeschedule();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("เปลี่ยนเป็นสถานะ  " + comboBox2.SelectedItem.ToString());
        }
        /*
private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
{
string query = ("Update schedule_work_doctor set swd_status = '"+ comboBox2.SelectedItem.ToString() + "'");
cmd = new SqlCommand(query, conn);
sda = new SqlDataAdapter(cmd);
dt = new DataTable();
clinic_timeschedule doc1 = new clinic_timeschedule();
doc1.Show();
clinic_timeschedule clnlog = new clinic_timeschedule();
clnlog.Close();
Visible = false;
MessageBox.Show("เปลี่ยนสถานะ  " + comboBox2.SelectedItem.ToString() + "  เรียบร้อย");
}
*/
    }
}
