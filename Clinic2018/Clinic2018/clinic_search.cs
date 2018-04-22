﻿using System;
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
    public partial class clinic_search : Form
    {
        public clinic_search()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "บัตรประชาชน")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "บัตรประชาชน";

                textBox1.ForeColor = Color.Silver;
            }
        }

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 13;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
      
            //     string query = ("select * from employee_ru eru, opd, privilege where eru.emp_ru_idcard = opd.emp_ru_id and opd.emp_ru_id = privilege.emp_ru_idcard and eru.emp_ru_idcard = '" + textBox1.Text + "'");
            string query = ("select * from employee_ru inner join privilege on privilege.emp_ru_id = employee_ru.emp_ru_id inner join opd on opd.emp_ru_id = employee_ru.emp_ru_id where employee_ru.emp_ru_idcard = '" + textBox1.Text + "'");
            cmd = new SqlCommand(query, conn);
     
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
         //   SqlDataReader sba = cmd.ExecuteReader();
            
            sda.Fill(dt);
            
            //------------------------------ปิงปอง--------------------------------------
            if (textBox1.Text == cmd.Connection.Database || textBox1.MaxLength == 13)
            {
              // if (sba.Read())
                //{
                  //  string position = sba["privil_status"].ToString();
                   // if(position == "อนุญาต")
                    //{
                        foreach (DataRow item in dt.Rows)
                        {
                            int n = dataGridView1.Rows.Add();
                    string privil_status = item["privil_status"].ToString();
                    if (privil_status == "อนุญาต")
                    {
                        dataGridView1.Rows[n].Cells[0].Value = item["emp_ru_idcard"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = item["emp_ru_name"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = item["emp_ru_birthday"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = item["emp_ru_telmobile"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = item["privil_status"].ToString();

                    }
               
                 
                        }
                //     }



                //  }

            }
     //    if (textBox1.Text != cmd.Connection.Database || textBox1.MaxLength == 13)
      
     //       {
     //            clinic_approve cliapp = new clinic_approve();
     //            cliapp.Show();
     //       }
            //------------------------------ปิงปอง--------------------------------------


            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------
            /*select eru.emp_ru_idcard, eru.emp_ru_name, privilege.privil_status
            from employee_ru eru
            inner join opd on eru.emp_ru_idcard = opd.emp_ru_id
            inner join privilege on opd.emp_ru_id = privilege.emp_ru_idcard

            select eru.emp_ru_idcard, eru.emp_ru_name, privilege.privil_status 
            from employee_ru eru, opd, privilege
            where eru.emp_ru_idcard = opd.emp_ru_id
            and opd.emp_ru_id = privilege.emp_ru_idcard
            and eru.emp_ru_idcard = '1859900128488'*/
            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------
            /*if (textBox1.MaxLength == null)
            {
                textBox1.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            else
            {
                clinic_approve cliapp = new clinic_approve();
                cliapp.Close();
            }*/
            //------------------------------ไม่ได้ใช้ เก็บไว้ --------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string query = ("update queue_visit_record set opd_idcard = '"+ dt DataGridTextBoxColumn + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);*/
        }

        int selectedRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            lb11.Text = row.Cells[0].Value.ToString();
            lb22.Text = row.Cells[1].Value.ToString();
            lb33.Text = row.Cells[2].Value.ToString();
            lb44.Text = row.Cells[3].Value.ToString();
            lb55.Text = row.Cells[4].Value.ToString();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            lb11.Text = "";
            lb22.Text = "";
            lb33.Text = "";
            lb44.Text = "";
            lb55.Text = "";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (lb11.Text != cmd.Connection.Database &&
                lb22.Text != cmd.Connection.Database &&
                lb33.Text != cmd.Connection.Database &&
                lb44.Text != cmd.Connection.Database && 
                lb55.Text != cmd.Connection.Database )
            {
               
                string query = ("insert into queue_visit_record(qvr_record,qvr_time,qvr_date,emp_ru_id,vr_id,opd_idcard) values(' ', SYSDATETIME(), SYSDATETIME(),' ',' ',' ')");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                //dataGridView1.Rows[n].Cells[0].Value = item["emp_ru_idcard"].ToString();

                MessageBox.Show("สำเร็จ");

                textBox1.MaxLength = 13;
                textBox1.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                lb11.Text = "";
                lb22.Text = "";
                lb33.Text = "";
                lb44.Text = "";
                lb55.Text = "";

                
            }
            else
            {
                MessageBox.Show("ตรวจสอบข้อมูลอีกครั้ง");
            }
            conn.Close();

            //----------------------------------------------------------------------
            /*try
            {
                drd = cmd.ExecuteReader();
                MessageBox.Show("Save");
                while (drd.Read())
                {

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            //----------------------------------------------------------------------

            /*string query = (" ");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);*/


        }

    

        private void conferm_Click(object sender, EventArgs e)
        {
            clinic_approve cliapp = new clinic_approve();
             cliapp.Show();
        }
    }
}




