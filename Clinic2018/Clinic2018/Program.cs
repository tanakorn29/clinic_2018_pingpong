﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Clinic2018
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //    Application.Run(new clinic_login());
            // Application.Run(new clinc_nurse_service());
         //  Application.Run(new clinic_search());
            //Application.Run(new clinic_calendar());
            //Application.Run(new clinic_test_1()); 
      Application.Run(new clinic_login());
       //     Application.Run(new sent_room());
            //       Application.Run(new Form5());
            //     Application.Run(new clinic_calendar());
            //    Application.Run(new clinic_timeschedule());
            //     Application.Run(new clinic_timeschedule());

            // Application.Run(new clinic_schedule());
            //    Application.Run(new Show_text());
            //       Application.Run(new Form2());
            //Application.Run(new sent_room());

            //  Application.Run(new Form3());
            //   Application.Run(new Form4());
    //   Application.Run(new clinic_doctor_service());
          // Application.Run(new clinic_user_control());

        }
    }
}
