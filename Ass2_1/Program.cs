using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_1
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
                  Application.Run(new Form1()); 
            
           /* string lines = "First line.\r\nSecond line.\r\nThird line.";

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("test.txt");
            file.WriteLine(lines);

            file.Close();*/
            /* OrderDBManager odbm = new OrderDBManager();
             Order o = new Order();
             o.idOrder = 1;
             IList<OrderDetail> ol = odbm.getOrderDetails(o);*/

            /*  UserLogin ul = new UserLogin();
              User u1 = new User();
              u1.idUser = 1;
              u1.name = "diana";
              u1.pass = "client";
              u1.tip = "c";
              ul.AddUser(u1);
              User u2 = new User();
              u2.idUser = 2;
              u2.name = "anca";
              u2.pass = "admin";
              u2.tip = "a";
              ul.AddUser(u2);*/

        }
    }
}
