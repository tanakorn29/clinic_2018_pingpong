﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Windows.Forms;

using System.Data.SqlClient;


namespace Clinic2018
{
    public partial class clinic_calendar : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-J5O17QF\SQLEXPRESS; Initial Catalog = Clinic2018; MultipleActiveResultSets = true; User ID = sa; Password = 1234");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader sdr;
  
        public clinic_calendar()
        {
            InitializeComponent();

            string query = ("select employee_doctor.emp_doc_name , schedule_work_doctor.swd_day_work,schedule_work_doctor.swd_start_time,schedule_work_doctor.room_id,schedule_work_doctor.swd_note from schedule_work_doctor inner join employee_doctor on employee_doctor.emp_doc_id = schedule_work_doctor.emp_doc_id where schedule_work_doctor.swd_status_room = 1");
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();



                dataGridView1.Rows[n].Cells[0].Value = item["emp_doc_name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["swd_day_work"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["swd_start_time"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["room_id"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["swd_note"].ToString();
  


            }







        }



        private void clinic_calendar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.districts' table. You can move, or remove it, as needed.
         //   this.districtsTableAdapter.Fill(this.dataSet1.districts);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }



        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string query = ("insert into employee_doctor(emp_doc_name, emp_doc_idcard, emp_doc_birth, emp_doc_address, emp_doc_tel, emp_doc_email, emp_doc_occupation_id, emp_doc_specialist)values('" + txtname.Text + "', '" + txtidcard.Text + "', '" + dateTimePicker1.Text + "', '" + txtaddress.Text + "', '" + txttel.Text + "', '" + txtemail.Text + "', '" + txtooid.Text + "', '" + txtss.Text + "'); ");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                query = ("select emp_doc_id from employee_doctor where emp_doc_idcard = '" + txtidcard.Text + "'");
                cmd = new SqlCommand(query, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    int doc_id = Convert.ToInt32(sdr["emp_doc_id"].ToString());
                    query = ("Insert into user_control(uct_user, uct_password, emp_doc_id) values('" + txtidcard.Text + "', '" + dateTimePicker1.Text + "', '" + doc_id + "');  ");
                    cmd = new SqlCommand(query, conn);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                }


                string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "../fonts/THSarabun.ttf";
                BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);

                iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(basefont, 24, iTextSharp.text.Font.NORMAL);


                var el = new Chunk();
                iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, el.Font.Size,
                                                el.Font.Style, el.Font.Color);
                el.Font = f2;

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("" + txtname.Text + ".pdf", FileMode.Create));
                doc.Open();
                //    Paragraph pa = new Paragraph();




                /*

                     List list = new List(List.UNORDERED);
                     list.Add(new ListItem(new Phrase(10, "" + txtname.Text + "", el.Font)));
                     list.Add(""+txtidcard.Text+"");
                     */

                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                Picbox.Image = barcode.Draw(txtidcard.Text, 100);


                doc.NewPage();



                iTextSharp.text.pdf.PdfContentByte cb = wri.DirectContent;
                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                bc.TextAlignment = Element.ALIGN_LEFT;
                bc.Code = txtidcard.Text;
                bc.StartStopText = false;
                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                bc.Extended = true;

                iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                  iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);

                cb.SetTextMatrix(5.5f, 3.0f);
                img.ScaleToFit(150, 200);
                img.SetAbsolutePosition(1.5f, 1);
                //   cb.AddImage(img);
                PdfPTable table = new PdfPTable(3);
                table.AddCell(new Phrase(70, "บัตรเข้าออกงานของแพทย์", el.Font));
                table.AddCell(new Phrase(10, "" + txtname.Text + "", el.Font));
                table.AddCell(img);

                table.AddCell(new Phrase(70, "รหัสเข้าสู่ระบบ", el.Font));
                table.AddCell(new Phrase(70, "รหัสชื่อผู้ใช้ " + txtidcard.Text + "", el.Font));
                table.AddCell(new Phrase(10, "รหัสผ่าน" + dateTimePicker1.Text + "", el.Font));


                doc.Add(table);
                //    doc.Add(pa);
                //  doc.Add(list);
                doc.Close();
                System.Diagnostics.Process.Start("" + txtname.Text + ".pdf");

                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel);
            }
           

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

     

      

        private void docinputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_schedule sc = new clinic_schedule();
            sc.Show();
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clinic_timeschedule sc = new clinic_timeschedule();
            sc.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
