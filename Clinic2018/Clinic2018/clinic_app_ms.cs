using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic2018
{
    public partial class clinic_app_ms : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
    

        public clinic_app_ms()
        {
            InitializeComponent();
            textBox2.Text = "00:00";
            conn.Open();
            string query = ("select appointment.app_id ,opd.opd_idcard,opd.opd_name,employee_doctor.emp_doc_id,employee_doctor.emp_doc_name from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id inner join opd on opd.opd_id = appointment.opd_id  where status_approve = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["app_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["opd_idcard"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["opd_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["emp_doc_id"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["emp_doc_name"].ToString();
              //  dataGridView1.Rows[n].Cells[4].Value = item["room_id"].ToString();
    

            }

            query = ("select appointment.app_id,appointment.app_date,appointment.app_time ,opd.opd_idcard,opd.opd_name,employee_doctor.emp_doc_name from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id inner join opd on opd.opd_id = appointment.opd_id where status_approve = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["app_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["app_date"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["app_time"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["opd_idcard"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["opd_name"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = item["emp_doc_name"].ToString();
                //  dataGridView1.Rows[n].Cells[4].Value = item["room_id"].ToString();


            }
            conn.Close();
        }
  
        private void clinic_app_ms_Load(object sender, EventArgs e)
        {
            dtp1.Format = DateTimePickerFormat.Custom;
            dtp1.CustomFormat = "yyyy-MM-dd";
            //lblday.Text = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            //   MessageBox.Show(lbltime.Text);
            conn.Open();
        
            string query = ("Update appointment SET app_date = '"+dtp1.Text+"' , app_time = '"+textBox2.Text+"',app_remark = '"+txtremark.Text+ "',status_approve = 2,status_app = 1 where app_id = '" + lb11.Text+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            clinic_app_ms doc1 = new clinic_app_ms();
            doc1.Show();
            clinic_app_ms clnlog = new clinic_app_ms();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("นัดหมายเรียบร้อย");

            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lb11.Text = row.Cells[0].Value.ToString();
            lb22.Text = row.Cells[1].Value.ToString();
            // lblopd.Text = row.Cells[7].Value.ToString();
            lb33.Text = row.Cells[2].Value.ToString();
            lbliddoc.Text = row.Cells[3].Value.ToString();
            lbldoc.Text = row.Cells[4].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string query = ("select appointment.app_id ,opd.opd_idcard,opd.opd_name,employee_doctor.emp_doc_name from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id inner join opd on opd.opd_id = appointment.opd_id where opd.opd_name LIKE '%"+textBox1.Text+"%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["app_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["opd_idcard"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["opd_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["emp_doc_name"].ToString();
                //  dataGridView1.Rows[n].Cells[4].Value = item["room_id"].ToString();


            }




            conn.Close();
        }

        private void btnapp_Click(object sender, EventArgs e)
        {
            conn.Open();

            string query = ("Update appointment SET status_approve = 0,status_app = 0 where app_id = '" + lblidapp.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();

            sda.Fill(dt);

            clinic_app_ms doc1 = new clinic_app_ms();
            doc1.Show();
            clinic_app_ms clnlog = new clinic_app_ms();
            clnlog.Close();
            Visible = false;
            MessageBox.Show("นัดหมายเรียบร้อย");

            conn.Close();
        }

        private void lb6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            lblidapp.Text = row.Cells[0].Value.ToString();
            lbldocname.Text = row.Cells[5].Value.ToString();
         
            lbldate.Text = row.Cells[1].Value.ToString();
            lbltime.Text = row.Cells[2].Value.ToString();
            lblname.Text = row.Cells[4].Value.ToString();
        }
    }
}
