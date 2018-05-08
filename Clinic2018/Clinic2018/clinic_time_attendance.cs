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
using System.Data.SqlClient;

namespace Clinic2018
{
    public partial class clinic_time_attendance : Form
    {
        Timer t = new Timer();

        public clinic_time_attendance()
        {
            InitializeComponent();
        }

        private void clinic_time_attendance_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();


            label2.Text = DateTime.Now.ToString("dddd d MMMM yyyy", new CultureInfo("th-TH"));
            
        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            String time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            label1.Text = time;

        }

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
    
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.MaxLength = 13;
            if(radioButton1.Checked == true)
            {
                
                string query = ("select emp_ru_id from employee_ru where emp_ru_idcard = '"+textBox1.Text+"'");
                cmd = new SqlCommand(query, conn);
                conn.Open();
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
        
                if (sdr.Read())
                {
                    int emp_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());

                    query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),SYSDATETIME(),SYSDATETIME(),'เข้างาน','"+emp_id+"','')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    MessageBox.Show("เข้างานเรียบร้อย");

                }
                query = ("select emp_doc_id from employee_doctor where emp_doc_idcard ='" + textBox1.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    int emp_doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());

                    query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),SYSDATETIME(),SYSDATETIME(),'เข้างาน','','" + emp_doc_id + "')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    MessageBox.Show("เข้างานเรียบร้อย");
                }

                    conn.Close();
            }else if (radioButton2.Checked == true)
            {
              
            }

            /*
            string query = ("insert time_attendance (start_time,end_time,date_work,remark,emp_ru_id,emp_doc_id) values(SYSDATETIME(),SYSDATETIME(),SYSDATETIME(),'',1,1)");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);*/
        }
    }
}
