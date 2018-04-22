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
    public partial class clinic_approve : Form
    {
        public clinic_approve()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            tb1.MaxLength = 13;

            //clear label เมื่อ tb1 เปลี่ยนการค้นหา
            S1.Text = "";
            S2.Text = "";
            S3.Text = "";
            S4.Text = "";
            S5.Text = "";
            S6.Text = "";

            conn.Open();

            string query = ("select eru.emp_ru_idcard, emp_ru_name, emp_ru_birthday, emp_ru_telmobile, pos_name, privil_status ,workplace.workplace  from employee_ru eru left join position pos on pos.pos_id = eru.pos_id  left join privilege pivi on pivi.emp_ru_idcard = eru.emp_ru_idcard left join workplace  on workplace.workplace_id = eru.workplace_id where eru.emp_ru_idcard =  '" + tb1.Text + "'");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                S1.Text = (sdr["emp_ru_idcard"].ToString());
                S2.Text = (sdr["emp_ru_name"].ToString());
                S3.Text = (sdr["emp_ru_birthday"].ToString());
                S4.Text = (sdr["emp_ru_telmobile"].ToString());
                S5.Text = (sdr["workplace"].ToString());
                S6.Text = (sdr["privil_status"].ToString());
                button1.Show();
            }
            /*else if (this.sdr.GetSqlString3)
            {
                S1.Text = (sdr["emp_ru_idcard"].ToString());
                S2.Text = (sdr["emp_ru_name"].ToString());
                S3.Text = (sdr["emp_ru_birthday"].ToString());
                S4.Text = (sdr["emp_ru_telmobile"].ToString());
                S5.Text = (sdr["pos_name"].ToString());
                S6.Text = "ไม่อนุญาต";
            }*/

            conn.Close();

            //textBox2.Clear();
            //Select DATE_FORMAT(DATE_ADD(BirthDate, INTERVAL 543 YEAR), '%d/%m/%Y') AS BirthDate From tblolder
        }

        private void tb1_Enter(object sender, EventArgs e)
        {
            if (tb1.Text == "บัตรประชาชน")
            {
                tb1.Text = "";

                tb1.ForeColor = Color.Black;
            }
        }

        private void tb1_Leave(object sender, EventArgs e)
        {
            if (tb1.Text == "")
            {
                tb1.Text = "บัตรประชาชน";

                tb1.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            string query = ("select eru.emp_ru_name,eru.emp_ru_idcard,eru.emp_ru_birthday,eru.emp_ru_age,eru.emp_ru_telwork,eru.emp_ru_telmobile ,eru.emp_ru_telhome,eru.emp_ru_telparent,eru.emp_ru_nameparent,eru.em_ru_addressparent,eru.emp_ru_namedad,eru.emp_ru_namemom,eru.emp_ru_namehusband_and_wife,eru.emp_ru_address from employee_ru eru where eru.emp_ru_idcard = '" + tb1.Text + "'");
            cmd = new SqlCommand(query, conn);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string emp_ru_name = sdr["emp_ru_name"].ToString();
                string emp_ru_idcard = sdr["emp_ru_idcard"].ToString();
                string emp_ru_birthday = sdr["emp_ru_birthday"].ToString();
                string emp_ru_age = sdr["emp_ru_age"].ToString();
                string emp_ru_telwork = sdr["emp_ru_telwork"].ToString();
                string emp_ru_telmobile = sdr["emp_ru_telmobile"].ToString();
                string emp_ru_telhome = sdr["emp_ru_telhome"].ToString();
                string emp_ru_telparent = sdr["emp_ru_telparent"].ToString();
                string emp_ru_nameparent = sdr["emp_ru_nameparent"].ToString();
                string em_ru_addressparent = sdr["em_ru_addressparent"].ToString();
                string emp_ru_namedad = sdr["emp_ru_namedad"].ToString();
                string emp_ru_namemom = sdr["emp_ru_namemom"].ToString();
                string emp_ru_namehusband_and_wife = sdr["emp_ru_namehusband_and_wife"].ToString();
                string emp_ru_address = sdr["emp_ru_address"].ToString();
                query = ("insert into opd (opd_name,opd_idcard,opd_birthday,opd_age,opd_telwork,opd_telmobile ,opd_telhome,opd_telparent,opd_nameparent,opd_addressparent,opd_namedad,opd_namemom,opd_namehusband_and_wife,opd_address)" +
             "values('" + emp_ru_name + " ','" + emp_ru_idcard + " ','" + emp_ru_birthday + " ','" + emp_ru_age + " '," +
                    "'" + emp_ru_telwork + " ','" + emp_ru_telmobile + " ','" + emp_ru_telhome + " ','" + emp_ru_telparent + " '," +
                    "'" + emp_ru_nameparent + "','" + em_ru_addressparent + " ','" + emp_ru_namedad + " '" +
                    ",'" + emp_ru_namemom + "','" + emp_ru_namehusband_and_wife + " ','" + emp_ru_address + " ')");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                /*
                query = ("insert into opd (opd_name,opd_idcard,opd_birthday,opd_age,opd_telwork,opd_telmobile ,opd_telhome,emp_ru_telparent,emp_ru_nameparent,em_ru_addressparent,emp_ru_namedad,eru.emp_ru_namemom,emp_ru_namehusband_and_wife,emp_ru_address)"+
                    "values('"+emp_ru_name+" ','"+emp_ru_idcard+" ','"+emp_ru_birthday+" ','"+emp_ru_age+" ',"+
                    "'"+emp_ru_age+" ','"+emp_ru_telwork+" ','"+emp_ru_telmobile+" ','"+emp_ru_telhome+" ',"+
                    "'"+emp_ru_telparent+"','"+emp_ru_nameparent+" ','"+ em_ru_addressparent + " '"+
                    ",'"+ emp_ru_namedad + "','"+emp_ru_namemom+" ','"+ emp_ru_namehusband_and_wife + " ',"+
                    "'"+ emp_ru_address + "')");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

    */
                clinic_approve_step2 appr2 = new clinic_approve_step2();
                appr2.Show();
            }
         
        }

        private void tb1_MouseClick(object sender, MouseEventArgs e)
        {
            tb1.Clear();
        }
    }
}

