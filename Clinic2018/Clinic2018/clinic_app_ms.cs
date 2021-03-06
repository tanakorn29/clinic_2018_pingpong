﻿using System;
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
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        Timer t = new Timer();

        public clinic_app_ms()
        {
            InitializeComponent();
          
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

            query = ("select appointment.app_id,appointment.app_date,appointment.app_time ,opd.opd_idcard,opd.opd_name,employee_doctor.emp_doc_name,appointment.day from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id inner join opd on opd.opd_id = appointment.opd_id where status_approve = 2");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["app_id"].ToString();
                System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");

                DateTime app_date = Convert.ToDateTime(item["app_date"].ToString());

                string date_app= String.Format("{0:yyyy-MM-dd}", app_date);
                string date_th = app_date.ToString("yyyy-MM-dd", _cultureEnInfo);
                dataGridView2.Rows[n].Cells[1].Value = date_th;

                dataGridView2.Rows[n].Cells[2].Value = item["app_time"].ToString();
            //    dataGridView2.Rows[n].Cells[3].Value = item["day"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["opd_idcard"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["opd_name"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = item["emp_doc_name"].ToString();
                dataGridView2.Rows[n].Cells[6].Value = item["day"].ToString();


            }
   
            query = ("select employee_doctor.emp_doc_name , schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();



                dataGridView3.Rows[n].Cells[0].Value = item["emp_doc_name"].ToString();
                
                dataGridView3.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item["swd_start_time"].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item["room_id"].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item["swd_note"].ToString();



            }
         
            conn.Close();
        }
  
        private void clinic_app_ms_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();

            dtp1.Format = DateTimePickerFormat.Custom;
            dtp1.CustomFormat = "yyyy-MM-dd";
            //lblday.Text = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            //   MessageBox.Show(lbltime.Text);
            conn.Open();
            CultureInfo ThaiCulture = new CultureInfo("th-TH");
            DateTime date_app = Convert.ToDateTime(dtp1.Text);

            string date = date_app.ToString("yyyy-MM-dd", ThaiCulture);
            string day = date_app.ToString("dddd", ThaiCulture);
            double time = Convert.ToDouble(comboBox1.SelectedItem.ToString());

            if (time <= 12.00)
            {
                string query = ("select count(*) from schedule_work_doctor where emp_doc_id = '" +lbliddoc.Text +"' AND swd_timezone = 'เช้า' AND swd_day_work = '"+day+"'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int count_appswd = (int)cmd.ExecuteScalar();
                if(count_appswd == 1)
                {

                   // MessageBox.Show("เช้า" + day);
                    query = ("select schedule_work_doctor.swd_id,schedule_work_doctor.swd_timezone from schedule_work_doctor where emp_doc_id = '" + lbliddoc.Text + "' AND swd_timezone = 'เช้า' AND swd_day_work = '" + day + "'");
                    cmd = new SqlCommand(query, conn);
                    //    conn.Open();
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                        string timezone = sdr["swd_timezone"].ToString();
                         query = ("select count(*) from appointment where app_time = '"+ comboBox1.SelectedItem.ToString() + "' AND day = '"+day+ "' AND swd_id = '"+swd_id+"'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        int count_app = (int)cmd.ExecuteScalar();
                        if(count_app < 1)
                        {
                      //    MessageBox.Show("   " + swd_id + "    " + timezone + "   " + count_app + "    " + lbliddoc.Text);
                     
                            query = ("Update appointment SET day = '" + day + "',app_date = '" + date + "' , app_time = '" + comboBox1.SelectedItem.ToString() + "',app_remark = '" + txtremark.Text + "',status_approve = 2,status_app = 1 , swd_id = '" + swd_id + "' where app_id = '" + lb11.Text + "' ");
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
                     
                        }
                        else
                        {
                            MessageBox.Show(" มีคนไข้นัดอยู่แล้ว " );
                        }
                     

                    }

              }
                else
                {
                    MessageBox.Show("ตารางปฏิบัติงานว่าง");
                }



            }
            else if (time >= 12.01)
            {
                string query = ("select count(*) from schedule_work_doctor where emp_doc_id = '" + lbliddoc.Text + "' AND swd_timezone = 'บ่าย' AND swd_day_work = '" + day + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                int count_appswd = (int)cmd.ExecuteScalar();
                if (count_appswd == 1)
                {

                    // MessageBox.Show("เช้า" + day);
                    query = ("select schedule_work_doctor.swd_id,schedule_work_doctor.swd_timezone from schedule_work_doctor where emp_doc_id = '" + lbliddoc.Text + "' AND swd_timezone = 'บ่าย' AND swd_day_work = '" + day + "'");
                    cmd = new SqlCommand(query, conn);
                    //    conn.Open();
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int swd_id = Convert.ToInt32(sdr["swd_id"].ToString());
                        string timezone = sdr["swd_timezone"].ToString();
                        query = ("select count(*) from appointment where app_time = '" + comboBox1.SelectedItem.ToString() + "' AND day = '" + day + "' AND swd_id = '" + swd_id + "'");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        int count_app = (int)cmd.ExecuteScalar();
                        if (count_app < 1)
                        {
                            //    MessageBox.Show("   " + swd_id + "    " + timezone + "   " + count_app + "    " + lbliddoc.Text);

                            query = ("Update appointment SET day = '" + day + "',app_date = '" + dtp1.Text + "' , app_time = '" + comboBox1.SelectedItem.ToString() + "',app_remark = '" + txtremark.Text + "',status_approve = 2,status_app = 1 , swd_id = '" + swd_id + "' where app_id = '" + lb11.Text + "' ");
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

                        }
                        else
                        {
                            MessageBox.Show(" มีคนไข้นัดอยู่แล้ว ");
                        }


                    }

                }
                else
                {
                    MessageBox.Show("ตารางปฏิบัติงานว่าง");
                }

            }








            /*

                  clinic_app_ms doc1 = new clinic_app_ms();
              doc1.Show();
              clinic_app_ms clnlog = new clinic_app_ms();
              clnlog.Close();
              Visible = false;
              MessageBox.Show("นัดหมายเรียบร้อย");
              */
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

    /*    private void btnapp_Click(object sender, EventArgs e)
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
*/
        private void lb6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
       /*     lblidapp.Text = row.Cells[0].Value.ToString();
            lbldocname.Text = row.Cells[5].Value.ToString();
         
            lbldate.Text = row.Cells[1].Value.ToString();
            lbltime.Text = row.Cells[2].Value.ToString();
            lblname.Text = row.Cells[4].Value.ToString();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            //   int ss = DateTime.Now.Second;

            String time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ".";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            /*
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            */
            lbltime1.Text = time;
        }

        private void lb11_TextChanged(object sender, EventArgs e)
        {
      

        }

        private void lbldoc_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            string query = ("select employee_doctor.emp_doc_name , schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 1 AND employee_doctor.emp_doc_name = '"+lbldoc.Text+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();



                dataGridView3.Rows[n].Cells[0].Value = item["emp_doc_name"].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item["swd_start_time"].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item["room_id"].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item["swd_note"].ToString();



            }
            conn.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            string query = ("select appointment.app_id,appointment.app_date,appointment.app_time ,opd.opd_idcard,opd.opd_name,employee_doctor.emp_doc_name,appointment.day from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id inner join opd on opd.opd_id = appointment.opd_id where status_approve = 2 AND opd_name LIKE '%" + textBox3.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["app_id"].ToString();


                DateTime app_date = Convert.ToDateTime(item["app_date"].ToString());
                string date_app = String.Format("{0:yyyy-MM-dd}", app_date);
                dataGridView2.Rows[n].Cells[1].Value = date_app;

                dataGridView2.Rows[n].Cells[2].Value = item["app_time"].ToString();
                //    dataGridView2.Rows[n].Cells[3].Value = item["day"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["opd_idcard"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = item["opd_name"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = item["emp_doc_name"].ToString();
                dataGridView2.Rows[n].Cells[6].Value = item["day"].ToString();


            }






            conn.Close();
        }

        private void manuappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_app_service cliapp = new clinic_app_service();
            cliapp.Show();
        }
    }
}
