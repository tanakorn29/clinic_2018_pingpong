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
    public partial class clinic_doctor_service : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_doctor_service()
        {
            InitializeComponent();
            conn.Open();
            string query = ("select queue_diag_room.qdr_record,queue_diag_room.qdr_date,queue_diag_room.qdr_time_sent,schedule_work_doctor.room_id,employee_doctor.emp_doc_name,employee_doctor.emp_doc_id,opd.opd_id,opd.opd_name from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where  queue_diag_room.status_queue = 1 AND room_id = 1  ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["qdr_record"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["qdr_date"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["qdr_time_sent"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["emp_doc_id"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["opd_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["opd_name"].ToString();
            }
         

            conn.Close();

        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblopdid.Text = row.Cells[6].Value.ToString();
          lblsername.Text = row.Cells[7].Value.ToString();

        
        }

        private void label43_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            clinic_appointment m2 = new clinic_appointment();
            m2.Show();
          
            /*
            conn.Open();
            string query = ("insert into appointment (app_date , app_time ,app_remark , status_approve,status_app,emp_doc_id,opd_id) values ('"+ txtapp.Text + "','"+txttime.Text+"','"+txtremark.Text+"',1,1,'"+txtdoctor.Text+"','"+txtopdid.Text+"');");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            MessageBox.Show("นัดหมายเรียบร้อยแล้ว");

    */
        }
        
        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void lblopdid_Click(object sender, EventArgs e)
        {

        }

        private void txtw_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblopdid_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("select visit_record.vr_id,visit_record.vr_weight,visit_record.vr_height,visit_record.vr_systolic,visit_record.vr_diastolic,visit_record.vr_hearth_rate,visit_record.vr_date,visit_record.vr_remark,visit_record.opd_id from visit_record where opd_id = '" + lblopdid.Text + "'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {

                txtw.Text = (sdr["vr_weight"].ToString());
                txth.Text = (sdr["vr_height"].ToString());
                txts.Text = (sdr["vr_systolic"].ToString());
                txtd.Text = (sdr["vr_diastolic"].ToString());
                txthert.Text = (sdr["vr_hearth_rate"].ToString());
                txtremark.Text = (sdr["vr_remark"].ToString());





            }
            conn.Close();
        }
    }
}
