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
    public partial class clinic_pharmacist_service : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-CGKA91D\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_pharmacist_service()
        {
            InitializeComponent();
            conn.Open();
            string  query = ("select medicine_use.medi_use_id , medical.medi_name, medicine_use.medi_num,treatment_record.treatr_id, opd.opd_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();



                dataGridView3.Rows[n].Cells[0].Value = item["medi_use_id"].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item["medi_num"].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item["treatr_id"].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item["opd_name"].ToString();
            }

            query = ("select medi_id,medi_name,medi_qty from medical");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
           
            }


            conn.Close();
        }
        int selectedRow;
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("select medi_qty from medical where medi_name = '"+textBox2.Text+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                int nummed = Convert.ToInt32(sdr["medi_qty"].ToString());
                int cut_stock = nummed - Convert.ToInt32(textBox3.Text);

                query = ("Update medical set medi_qty = '"+cut_stock+"' where medi_name = '"+textBox2.Text+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                query = ("UPDATE medicine_use SET medi_use_status = 0 where treatr_id = '" + textBox4.Text + "' AND medi_use_id = '"+textBox1.Text+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                clinic_pharmacist_service m3 = new clinic_pharmacist_service();
                m3.Show();
                clinic_pharmacist_service clnlog = new clinic_pharmacist_service();
                clnlog.Close();
                Visible = false;


                MessageBox.Show("จ่ายยาเรียบร้อย");




            }

            conn.Close();
        }
    }
}
