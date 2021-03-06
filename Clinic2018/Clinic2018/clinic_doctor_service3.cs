﻿using System;
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
    public partial class clinic_doctor_service3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
        public clinic_doctor_service3()
        {
            InitializeComponent();
            conn.Open();
            string query = ("select queue_diag_room.qdr_record,queue_diag_room.qdr_date,queue_diag_room.qdr_time_sent,schedule_work_doctor.room_id,employee_doctor.emp_doc_name,employee_doctor.emp_doc_id,opd.opd_id,opd.opd_name,position.pos_name from queue_diag_room inner join opd on opd.opd_id = queue_diag_room.opd_id inner join schedule_work_doctor on schedule_work_doctor.swd_id = queue_diag_room.swd_id inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id inner join position on position.pos_id = opd.pos_id where  queue_diag_room.status_queue = 1 AND room_id = 3  ");
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
                dataGridView1.Rows[n].Cells[8].Value = item["pos_name"].ToString();
            }
            query = ("select disease from disease");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                // int n = dataGridView1.Rows.Add();

                comboBox1.Items.Add(item["disease"].ToString());


            }

            query = ("select medi_id,medi_name,medi_qty_use,medi_unit from medical");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["medi_qty_use"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item["medi_unit"].ToString();
            }


            query = ("select medicine_use.medi_use_id , medical.medi_name,medicine_use.medi_num, treatment_record.treatr_id, opd.opd_name from opd inner join treatment_record on treatment_record.opd_id = opd.opd_id inner join medicine_use on medicine_use.treatr_id = treatment_record.treatr_id inner join medical on medical.medi_id = medicine_use.medi_id where medicine_use.medi_use_status = 1");
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

            query = ("select treatr_id,treatr_symptom,treatr_diagnose ,opd.opd_name,treatment_record.emp_doc_id  from treatment_record inner join opd on opd.opd_id = treatment_record.opd_id where treatr_status = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView4.Rows.Add();



                dataGridView4.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                dataGridView4.Rows[n].Cells[1].Value = item["treatr_symptom"].ToString();
                dataGridView4.Rows[n].Cells[2].Value = item["treatr_diagnose"].ToString();
                dataGridView4.Rows[n].Cells[3].Value = item["opd_name"].ToString();
                dataGridView4.Rows[n].Cells[4].Value = item["emp_doc_id"].ToString();
            }


            conn.Close();
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

            query = ("select treatr_id,treatr_symptom,treatr_diagnose ,opd.opd_name,treatment_record.emp_doc_id  from treatment_record inner join opd on opd.opd_id = treatment_record.opd_id where treatr_status =  0 AND opd.opd_id = '" + lblopdid.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView5.Rows.Add();



                dataGridView5.Rows[n].Cells[0].Value = item["treatr_id"].ToString();
                dataGridView5.Rows[n].Cells[1].Value = item["treatr_symptom"].ToString();
                dataGridView5.Rows[n].Cells[2].Value = item["treatr_diagnose"].ToString();
                dataGridView5.Rows[n].Cells[3].Value = item["opd_name"].ToString();
                dataGridView5.Rows[n].Cells[4].Value = item["emp_doc_id"].ToString();
            }

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = ("insert into treatment_record (treatr_symptom,treatr_diagnose,treatr_status,disease_id,emp_doc_id,opd_id) values ('" + txtsystoms.Text + "','" + txtdis.Text + "',1,'" + txtiddis.Text + "','" + txtdocid.Text + "','" + lblopdid.Text + "')");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
            sda.Fill(dt);
            query = ("Update queue_diag_room SET status_queue = 0 where opd_id = '" + lblopdid.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            clinic_doctor_service3 m3 = new clinic_doctor_service3();
            m3.Show();
            clinic_doctor_service3 clnlog = new clinic_doctor_service3();
            clnlog.Close();
            Visible = false;


            MessageBox.Show("บันทึกการรักษาเรียบร้อย");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string position = lblposition.Text;
            conn.Open();
            if (position == "เจ้าหน้าที่")
            {
                DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = ("Insert into appointment (status_approve,emp_doc_id,opd_id) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "');");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

                //     button1.Visible = true;
            }
            else if (position == "เวชระเบียน")
            {
                DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = ("Insert into appointment (status_approve,emp_doc_id,opd_id) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "');");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                //      button1.Visible = true;
            }
            else if (position == "พยาบาล")
            {
                DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = ("Insert into appointment (status_approve,emp_doc_id,opd_id) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "');");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else if (position == "เภสัชกรณ์")
            {
                DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = ("Insert into appointment (status_approve,emp_doc_id,opd_id) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "');");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else if (position == "หัวหน้า")
            {
                DialogResult dialogResult = MessageBox.Show("ส่งข้อมูลการนัดหมายหรือไม่", "นัดหมายหรือไม่ ? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = ("Insert into appointment (status_approve,emp_doc_id,opd_id) values (1,'" + txtdocid.Text + "','" + lblopdid.Text + "');");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    MessageBox.Show("ส่งข้อมูลการนัดหมายเรียบร้อย");

                }
                else if (dialogResult == DialogResult.No)
                {

                    MessageBox.Show("ไม่มีการนัดหมาย");

                }
            }
            else
            {
                conn.Close();
                //        button1.Visible = false;
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            string query = ("select medi_id,medi_name,medi_qty from medical where medi_name LIKE '%" + textBox20.Text + "%'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();



                dataGridView2.Rows[n].Cells[0].Value = item["medi_id"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item["medi_name"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item["medi_qty"].ToString();


            }
            /*
                        clinic_doctor_service m3 = new clinic_doctor_service();
                        m3.Show();
                        clinic_doctor_service clnlog = new clinic_doctor_service();
                        clnlog.Close();
                        Visible = false;*/


            conn.Close();
        }
        int selectedRow;
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView4.Rows[selectedRow];
            lblidt.Text = row.Cells[0].Value.ToString();
            lblopd.Text = row.Cells[3].Value.ToString();
            lbldoctor.Text = row.Cells[4].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            lblidt.Text = row.Cells[3].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            lblmed.Text = row.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = ("select medi_qty_use from medical where medi_id = '" + lblmed.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                int nummed = Convert.ToInt32(sdr["medi_qty_use"].ToString());
                int cut_stock = nummed - Convert.ToInt32(txtnum.Text);
                if (nummed < 5)
                {
                    
                    MessageBox.Show("ยาใกล้หมดคลังแล้ว");

                    query = ("Update medical set medi_qty_use = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);


                    query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                    sda.Fill(dt);

                    clinic_doctor_service3 m3 = new clinic_doctor_service3();
                    m3.Show();
                    clinic_doctor_service3 clnlog = new clinic_doctor_service3();
                    clnlog.Close();
                    Visible = false;
                    

                    MessageBox.Show("บันทึกใบจ่ายยาเรียบร้อย");

                }else if (nummed < 0)
                {
                    MessageBox.Show("ยาหมดคลังแล้ว");
                }
                else if (nummed > 5)
                {
                    query = ("Update medical set medi_qty_use = '" + cut_stock + "' where medi_id = '" + lblmed.Text + "'");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);


                    query = ("insert into  medicine_use (medi_use_remark,medi_use_date,medi_use_status,medi_num,treatr_id,medi_id)values ('" + txtre2.Text + "',SYSDATETIME(),1,'" + txtnum.Text + "','" + lblidt.Text + "','" + lblmed.Text + "')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    //  MessageBox.Show("บันทึกการรักษาเรียบร้อย");
                    sda.Fill(dt);

                    clinic_doctor_service3 m3 = new clinic_doctor_service3();
                    m3.Show();
                    clinic_doctor_service3 clnlog = new clinic_doctor_service3();
                    clnlog.Close();
                    Visible = false;


                    MessageBox.Show("บันทึกใบจ่ายยาเรียบร้อย");
                }


            }

            conn.Close();


            /*
            query = ("Update treatment_record SET treatr_status = 0 where treatr_id = '"+lblidt.Text+"'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            */


        }

        private void button24_Click(object sender, EventArgs e)
        {
            string query = ("UPDATE medicine_use SET medi_use_status = 2 where treatr_id = '" + lblidt.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);



            query = ("Update treatment_record SET treatr_status = 0 where treatr_id = '" + lblidt.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            clinic_doctor_service3 m3 = new clinic_doctor_service3();
            m3.Show();
            clinic_doctor_service3 clnlog = new clinic_doctor_service3();
            clnlog.Close();
            Visible = false;


            MessageBox.Show("จ่ายยาเรียบร้อย");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn.Open();
            string query = ("select * from disease where disease = '" + comboBox1.SelectedItem.ToString() + "'");
            cmd = new SqlCommand(query, conn);

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {

                txtiddis.Text = (sdr["disease_id"].ToString());
                txtdis.Text = (sdr["disease"].ToString());







            }


            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lblopdid.Text = row.Cells[6].Value.ToString();
            lblsername.Text = row.Cells[7].Value.ToString();
            // lblopd.Text = row.Cells[7].Value.ToString();
            txtdocid.Text = row.Cells[5].Value.ToString();
            string position = row.Cells[8].Value.ToString();
            lblposition.Text = position;
        }
    }
}
