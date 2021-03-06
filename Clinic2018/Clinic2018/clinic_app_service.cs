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
    public partial class clinic_app_service : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        Timer t = new Timer();
        public clinic_app_service()
        {
            InitializeComponent();
            conn.Open();
            string query = ("select queue_visit_record.qvr_record,queue_visit_record.qvr_time,opd.opd_name,opd.opd_idcard,opd.opd_address,opd.opd_telmobile,opd.opd_id,opd.opd_birthday from queue_visit_record inner join opd on opd.opd_id = queue_visit_record.opd_id where queue_visit_record.qvr_status = 5");
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
                dataGridView1.Rows[n].Cells[6].Value = item["opd_birthday"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["opd_telmobile"].ToString();



            }





            conn.Close();
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

        private void clinic_app_service_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
        }

        private void lbltime1_TextChanged(object sender, EventArgs e)
        {
            try
            {





                lblday.Text = DateTime.Now.ToString("dddd", new CultureInfo("th-TH"));
                conn.Open();





                double time = Convert.ToDouble(lbltime1.Text);

                if (time <= 12.00)
                {
                    lbltimezone.Text = "เช้า";
                    /*
                                    string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    foreach (DataRow item in dt.Rows)
                                    {
                                        int n = dataGridView2.Rows.Add();



                                        dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                                        dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                                        dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                                        dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                                        dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                                        dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                                        dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                                        dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                                   }

                                */
                }
                else if (time >= 12.01)
                {
                    lbltimezone.Text = "บ่าย";
                    /*
                                    string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย'");
                                    cmd = new SqlCommand(query, conn);
                                    sda = new SqlDataAdapter(cmd);
                                    dt = new DataTable();
                                    sda.Fill(dt);

                                    foreach (DataRow item in dt.Rows)
                                    {
                                        int n = dataGridView2.Rows.Add();



                                        dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                                        dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                                        dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                                        dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                                        dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                                        dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                                        dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                                        dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                                    }
                                    */

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }
        }

        private void lbltimezone_TextChanged(object sender, EventArgs e)
        {
            /*
            string timezone = lbltimezone.Text;
            if (timezone == "เช้า")
            {
                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();



                    dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                }
            }
            else if (timezone == "บ่าย")
            {

                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();



                    dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                }

            }
            */
        }
        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];

            lblname.Text = row.Cells[2].Value.ToString();
            lblopdid.Text = row.Cells[4].Value.ToString();
        }

        private void lbltimezone_Click(object sender, EventArgs e)
        {

        }

        private void lblname_TextChanged(object sender, EventArgs e)
        {
       
        try
            {
                 conn.Open();
                string query = ("select appointment.app_id,appointment.app_date,appointment.app_time ,opd.opd_name,employee_doctor.emp_doc_name,appointment.day from appointment inner join employee_doctor on employee_doctor.emp_doc_id = appointment.emp_doc_id inner join opd on opd.opd_id = appointment.opd_id  where status_approve = 2 AND opd_name LIKE '%" + lblname.Text + "%'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    lblidapp.Text = sdr["app_id"].ToString();
                    DateTime date_app = Convert.ToDateTime(sdr["app_date"].ToString());

                    lbldate.Text = String.Format("{0:yyyy-MM-dd}", date_app);
                    lbltime.Text = sdr["app_time"].ToString();
                    lbldocname.Text = sdr["emp_doc_name"].ToString();

                }


               conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("แพทย์ยังไม่เข้างาน");
            }
          



        }

        private void btnsent_Click(object sender, EventArgs e)
        {
        conn.Open();
            string query = ("insert into queue_diag_room(qdr_date,qdr_time_sent,status_queue,swd_id,opd_id)values (SYSDATETIME(), SYSDATETIME(),1,'" + lblswdid.Text + "','" + lblopdid.Text + "');");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            Queue<int> collection = new Queue<int>();

            query = ("select count(*) from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where  queue_diag_room.status_queue = 1 AND schedule_work_doctor.swd_id = '" + lblswdid.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            //  sdr = cmd.ExecuteReader();
            int queue = (int)cmd.ExecuteScalar();
            collection.Enqueue(queue);

            foreach (int value in collection)
            {
                if (value <= 9)
                {
                    query = ("Update queue_diag_room Set qdr_record = '" + value + "' where opd_id = '" + lblopdid.Text + "'");
                    //  
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    query = ("Update visit_record set vr_status = 1 where opd_id = '" + lblopdid.Text + "'");
                    //  
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);


                    query = ("Update queue_visit_record set qvr_status = 0 where opd_id = '" + lblopdid.Text + "'");

                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                     query = ("Update appointment SET status_approve = 0,status_app = 0 where app_id = '" + lblidapp.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    clinic_app_service s2 = new clinic_app_service();
                    s2.Show();
                    clinic_app_service clnlog = new clinic_app_service();
                    clnlog.Close();
                    Visible = false;
                    MessageBox.Show("ส่งเข้าห้องตรวจเรียบร้อย   คุณคิวที่    " + value);
                }
                else
                {
                    MessageBox.Show("คิวห้องตรวจเต็ม");
                }

            }
          conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];

           lblswdid.Text = row.Cells[0].Value.ToString();
        }

        private void lbldocname_TextChanged(object sender, EventArgs e)
        {
            string timezone = lbltimezone.Text;
            if (timezone == "เช้า")
            {
                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'เช้า' AND emp_doc_name LIKE '%"+ lbldocname.Text + "%'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();



                    dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                }
            }
            else if (timezone == "บ่าย")
            {

                string query = ("select schedule_work_doctor.swd_id,empdoc.emp_doc_name,empdoc.emp_doc_specialist,schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.swd_end_time,schedule_work_doctor.swd_note,schedule_work_doctor.room_id from employee_doctor empdoc inner join schedule_work_doctor on schedule_work_doctor.emp_doc_id  = empdoc.emp_doc_id inner join room on room.room_id = schedule_work_doctor.room_id inner join time_attendance on time_attendance.emp_doc_id = empdoc.emp_doc_id where swd_status_room = 1 AND room.room_status = 1 AND swd_day_work = '" + lblday.Text + "' AND remark = 'เข้างาน' AND swd_timezone = 'บ่าย' AND emp_doc_name LIKE '%" + lbldocname.Text + "%'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();



                    dataGridView2.Rows[n].Cells[0].Value = item["swd_id"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["emp_doc_name"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["emp_doc_specialist"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["swd_day_work"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["swd_start_time"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["swd_end_time"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["swd_note"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["room_id"].ToString();

                }

            }
        }
    }
}
