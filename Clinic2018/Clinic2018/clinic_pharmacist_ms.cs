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
    public partial class clinic_pharmacist_ms : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-CGKA91D\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public clinic_pharmacist_ms()
        {
            InitializeComponent();
            conn.Open();
            string query = (" select medi_name,medi_no,medi_qty,medi_unit,medi_price_unit,medi_price from medical");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["medi_name"].ToString();
        
                dataGridView1.Rows[n].Cells[1].Value = item["medi_no"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["medi_qty"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["medi_unit"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["medi_price_unit"].ToString();
                 dataGridView1.Rows[n].Cells[5].Value = item["medi_price"].ToString();
                //  dataGridView1.Rows[n].Cells[4].Value = item["room_id"].ToString();


            }




            conn.Close();
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
