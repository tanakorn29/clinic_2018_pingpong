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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Clinic2018
{
    public partial class clinic_approve : Form
    {
        public clinic_approve()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-CGKA91D\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
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
                string privil = sdr["privil_status"].ToString();

                if(privil != "อนุญาต")
                {
                    S1.Text = (sdr["emp_ru_idcard"].ToString());
                    S2.Text = (sdr["emp_ru_name"].ToString());
                    S3.Text = (sdr["emp_ru_birthday"].ToString());
                    S4.Text = (sdr["emp_ru_telmobile"].ToString());
                    S5.Text = (sdr["workplace"].ToString());
                    S6.Text = (sdr["privil_status"].ToString());
                    button1.Show();


                }
          
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

            string query = ("select eru.emp_ru_name,eru.emp_ru_idcard,eru.emp_ru_birthday,eru.emp_ru_age,eru.emp_ru_telwork,eru.emp_ru_telmobile,eru.emp_ru_telhome,eru.emp_ru_telparent,eru.emp_ru_nameparent,eru.em_ru_addressparent,eru.emp_ru_namedad,eru.emp_ru_namemom,eru.emp_ru_namehusband_and_wife,eru.emp_ru_address,workplace.workplace,position.pos_id,eru.emp_ru_id ,privilege.privil_status from employee_ru eru left join workplace  on workplace.workplace_id = eru.workplace_id left join position on position.pos_id = eru.pos_id left join privilege on privilege.emp_ru_id = eru.emp_ru_id where eru.emp_ru_idcard ='" + tb1.Text + "'");
            cmd = new SqlCommand(query, conn);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string privil_status = sdr["privil_status"].ToString();
                if(privil_status != "ได้รับสิทธิการรักษา")
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
                    string workplace = sdr["workplace"].ToString();

                    int emp_ru_id = Convert.ToInt32(sdr["emp_ru_id"].ToString());
                    string pos_id = sdr["pos_id"].ToString();

                    /*     query = ("insert into opd (emp_ru_id,pos_id)" +
                    "values('" + emp_ru_id + "','" + pos_id + "')");
                         cmd = new SqlCommand(query, conn);
                         sda = new SqlDataAdapter(cmd);
                         dt = new DataTable();
                         sda.Fill(dt);*/

                    query = ("insert into opd (opd_name,opd_idcard,opd_birthday,opd_age,opd_telwork,opd_telmobile ,opd_telhome,opd_workplace,opd_telparent,opd_nameparent,opd_addressparent,opd_namedad,opd_namemom,opd_namehusband_and_wife,opd_address,emp_ru_id,pos_id)" +
                 "values('" + emp_ru_name + " ','" + emp_ru_idcard + " ','" + emp_ru_birthday + "','" + emp_ru_age + " '," +
                        "'" + emp_ru_telwork + " ','" + emp_ru_telmobile + " ','" + emp_ru_telhome + " ','" + workplace + "','" + emp_ru_telparent + " '," +
                        "'" + emp_ru_nameparent + "','" + em_ru_addressparent + " ','" + emp_ru_namedad + " '" +
                        ",'" + emp_ru_namemom + "','" + emp_ru_namehusband_and_wife + " ','" + emp_ru_address + " ','" + emp_ru_id + "','" + pos_id + "')");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    query = ("select opd_id from opd where emp_ru_id ='" + emp_ru_id + "'");
                    cmd = new SqlCommand(query, conn);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int id = Convert.ToInt32(sdr["opd_id"].ToString());
                        query = ("insert into privilege (privil_status,emp_ru_idcard,date,time,opd_id,emp_ru_id) values('ได้รับสิทธิการรักษา','" + emp_ru_idcard + "',SYSDATETIME(), SYSDATETIME(),'"+ id + "','"+ emp_ru_id + "');");
                        cmd = new SqlCommand(query, conn);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        query = ("select privil_id from privilege where emp_ru_idcard = '" + emp_ru_idcard + "'");
                        cmd = new SqlCommand(query, conn);
                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            int privil_id = Convert.ToInt32(sdr["privil_id"].ToString());
                            query = ("update opd set privil_id = '"+ privil_id + "' where opd_idcard = '"+ emp_ru_idcard + "'");
                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);


                          
                            query = ("insert into user_control (uct_user,uct_password,emp_ru_id,opd_id)values ('"+ emp_ru_idcard + "','"+ emp_ru_birthday + "','"+ emp_ru_id + "','"+ id + "');");


                            cmd = new SqlCommand(query, conn);
                            sda = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            sda.Fill(dt);




                            string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "../fonts/THSarabun.ttf";
                            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
                            iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(basefont, 24, iTextSharp.text.Font.NORMAL);
                            var el = new Chunk();
                            iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, el.Font.Size,
                                                            el.Font.Style, el.Font.Color);
                            el.Font = f2;

                            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("" + S2.Text + ".pdf", FileMode.Create));
                            doc.Open();
                            iTextSharp.text.pdf.PdfContentByte cb = wri.DirectContent;
                            iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                            bc.TextAlignment = Element.ALIGN_LEFT;
                            bc.Code = S1.Text;
                            bc.StartStopText = false;
                            bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                            bc.Extended = true;

                            iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                              iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                            cb.SetTextMatrix(5.5f, 3.0f);
                            img.ScaleToFit(150, 200);
                            img.SetAbsolutePosition(1.5f, 1);

                            PdfPTable table = new PdfPTable(3);
                            table.AddCell(new Phrase(70, "บัตรประจำตัวคนไข้", el.Font));
                            table.AddCell(new Phrase(10, "" + S2.Text + "", el.Font));
                            table.AddCell(img);
                            table.AddCell(new Phrase(70, "รหัสเข้าสู่ระบบ", el.Font));
                            table.AddCell(new Phrase(70, "รหัสชื่อผู้ใช้ " + S1.Text + "", el.Font));
                            table.AddCell(new Phrase(10, "รหัสผ่าน" + S3.Text + "", el.Font));
                            doc.Add(table);
                            doc.Close();
                            System.Diagnostics.Process.Start("" + S2.Text + ".pdf");

                            clinic_approve_step2 appr2 = new clinic_approve_step2();
                            appr2.Show();
                            clinic_approve approve = new clinic_approve();
                            approve.Close();
                            Visible = false;

                        }
                    }


                }
           
                
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
             
            }
         
        }

        private void tb1_MouseClick(object sender, MouseEventArgs e)
        {
            tb1.Clear();
        }
    }
}

