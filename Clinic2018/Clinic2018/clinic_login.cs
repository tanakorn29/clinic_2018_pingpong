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
    public partial class clinic_login : Form
    {
        public clinic_login()
        {
            InitializeComponent();
        }

        private void B_login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-26BM5UJ\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets=true; User ID = sa; Password = 1234");
                SqlCommand cmd = new SqlCommand("select employee_ru.emp_ru_name,position.pos_name from employee_ru inner join user_control on user_control.emp_ru_id = employee_ru.emp_ru_id inner join position on position.pos_id = employee_ru.pos_id where uct_user=@uct_user and uct_password=@uct_password", conn);
                SqlCommand cmd1 = new SqlCommand("select employee_doctor.emp_doc_name from employee_doctor inner join user_control on user_control.emp_doc_id = employee_doctor.emp_doc_id where uct_user=@uct_user and uct_password=@uct_password", conn);
                conn.Open();
         
                  
                cmd.Parameters.AddWithValue("@uct_user", T_Username.Text);
                cmd.Parameters.AddWithValue("@uct_password", T_Password.Text);
                cmd1.Parameters.AddWithValue("@uct_user", T_Username.Text);
                cmd1.Parameters.AddWithValue("@uct_password", T_Password.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        string position = dr["pos_name"].ToString();
                        if(position == "เวชระเบียน")
                        {
                            MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                            clinic_main_v2 m1 = new clinic_main_v2();
                            m1.Show();
                            clinic_login clnlog = new clinic_login();
                            clnlog.Close();
                            Visible = false;

                        }else if(position == "พยาบาล")
                        {
                            MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                            clinic_nurse m2 = new clinic_nurse();
                            m2.Show();
                            clinic_login clnlog = new clinic_login();
                            clnlog.Close();
                            Visible = false;
                        }else if(position == "หัวหน้า")
                        {
                            MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                            Clinic_boss m3 = new Clinic_boss();
                            m3.Show();
                            clinic_login clnlog = new clinic_login();
                            clnlog.Close();
                            Visible = false;
                        }else if(position == "เภสัชกรณ์")
                        {
                            MessageBox.Show("ยินดีต้อนรับ" + dr["emp_ru_name"].ToString());

                            clinic_pharmacist m4 = new clinic_pharmacist();
                            m4.Show();
                            clinic_login clnlog = new clinic_login();
                            clnlog.Close();
                            Visible = false;
                        }
                   



                    }
                 
                }
                else if(dr1.HasRows == true)
                {
                    if (dr1.Read())
                    {
                        MessageBox.Show("ยินดีต้อนรับ" + dr1["emp_doc_name"].ToString());

                        Clinic_doctor doc1 = new Clinic_doctor();
                        doc1.Show();
                        clinic_login clnlog = new clinic_login();
                        clnlog.Close();
                        Visible = false;
                      
                    }
                       

                }
                else
                {
                    MessageBox.Show("Check Username and Password agin!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }
        }
        

        private void T_Username_Enter(object sender, EventArgs e)
        {
            if (T_Username.Text == "Username")
            {
                T_Username.Text = "";

                T_Username.ForeColor = Color.Black;
            }
        }

        private void T_Username_Leave(object sender, EventArgs e)
        {
            if (T_Username.Text == "")
            {
                T_Username.Text = "Username";

                T_Username.ForeColor = Color.Silver;
            }
        }

        private void T_Password_Enter(object sender, EventArgs e)
        {
            if (T_Password.Text == "Password")
            {
                T_Password.Text = "";

                T_Password.ForeColor = Color.Black;
            }
        }

        private void T_Password_Leave(object sender, EventArgs e)
        {
            if (T_Password.Text == "")
            {
                T_Password.Text = "Password";

                T_Password.ForeColor = Color.Silver;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /*private void textBox1_Enter(object sender, EventArgs e)
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
        }*/

    }
}
