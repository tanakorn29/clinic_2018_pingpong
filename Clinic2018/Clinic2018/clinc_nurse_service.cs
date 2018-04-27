using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinic2018
{
    public partial class clinc_nurse_service : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public clinc_nurse_service()
        {
            InitializeComponent();


            string query = ("select queue_visit_record.qvr_record,queue_visit_record.qvr_time,opd.opd_name,opd.opd_idcard,opd.opd_address,opd.opd_telmobile,opd.opd_id from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
     
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
          


                    dataGridView1.Rows[n].Cells[0].Value = item["qvr_record"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["qvr_time"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["opd_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["opd_idcard"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["opd_id"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["opd_address"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["opd_id"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["opd_telmobile"].ToString();
         


            }


        }

        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblidcard.Text = row.Cells[3].Value.ToString();
            lblsername.Text = row.Cells[2].Value.ToString();
            lblopd.Text = row.Cells[4].Value.ToString();

        }

        private void clinc_nurse_service_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.queue_visit_record' table. You can move, or remove it, as needed.
        //    this.queue_visit_recordTableAdapter.Fill(this.dataSet2.queue_visit_record);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = ("insert into visit_record (vr_weight,vr_height,vr_systolic,vr_diastolic,vr_hearth_rate,vr_date,vr_remark,opd_id) values ('"+txtw.Text+"','"+txth.Text+"','"+txts1.Text+"','"+txts2.Text+"','"+txthearth.Text+"',SYSDATETIME(),'"+txtremark.Text+"',"+lblopd.Text+");");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            MessageBox.Show("บันทึกข้อมูลซักประวัติเรียบร้อย");






            /*string query = ("insert into visit_record (vr_weight,vr_height,vr_systolic,vr_diastolic,vr_hearth_rate,vr_date,vr_remark,opd_id) values ('" + txtw.Text + "','" + txth.Text + "','" + txts1.Text + "','" + txts2.Text + "','" + txthearth.Text + "',SYSDATETIME(),'" + txtremark.Text + "'," + lblopd.Text + ");");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            MessageBox.Show("บันทึกข้อมูลซักประวัติเรียบร้อย");*/
        }

        private void button3_Click(object sender, EventArgs e)
        {

            sent_room s2 = new sent_room();
            s2.Show();
            clinc_nurse_service clnlog = new clinc_nurse_service();
            clnlog.Close();
            Visible = false;
        }
    }
}
