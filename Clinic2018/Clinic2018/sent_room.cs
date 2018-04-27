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
    public partial class sent_room : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public sent_room()
        {
            InitializeComponent();
            string query = ("select schedule_work_doctor.swd_id,employee_doctor.emp_doc_name,employee_doctor.emp_doc_specialist,schedule_work_doctor.swd_date_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,room.room_id from employee_doctor inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = employee_doctor.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id where room.room_status = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["swd_date_work"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["room_id"].ToString();

            }

            query = ("select queue_visit_record.qvr_record,queue_visit_record.qvr_time,opd.opd_name,opd.opd_idcard,opd.opd_address,opd.opd_telmobile,opd.opd_id from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["qvr_record"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["qvr_time"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["opd_name"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["opd_idcard"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["opd_id"].ToString();
      



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'"+lblswd.Text+"','"+lblopdid.Text+"');");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
                query = ("Update queue_visit_record set qvr_status = 0 where opd_id = '"+lblopdid.Text+"'");
            
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            Queue<int> collection = new Queue<int>();

            query = ("select count(*) from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where  queue_diag_room.status_queue = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            //  sdr = cmd.ExecuteReader();
            int queue = (int)cmd.ExecuteScalar();
            collection.Enqueue(queue);

            foreach (int value in collection)
            {
                query = ("Update queue_diag_room Set qdr_record = '"+value+"' where opd_id = '"+lblopdid.Text+"'");
                //  
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                clinc_nurse_service s2 = new clinc_nurse_service();
                s2.Show();
                sent_room clnlog = new sent_room();
                clnlog.Close();
                Visible = false;
                MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);
            }

        //    MessageBox.Show("ส่งคิวเรียบร้อย");




        }

        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblswd.Text = row.Cells[0].Value.ToString();
          
        }
        int selectedRow1;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow1 = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow1];
            lblopdid.Text = row.Cells[4].Value.ToString();
        }
    }
}
