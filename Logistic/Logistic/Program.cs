using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logistic.Models;

namespace Logistic
{
    static class Program
    {

        public static LogisticContext db;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            db = new LogisticContext();

            List<Okei> temp = Program.db.OkeiList.ToList();
            List<Customer> temp1 = Program.db.CustomersList.ToList();
            List<Fias> temp2 = Program.db.FiasList.ToList();
            List<GoodsInOrder> temp3 = Program.db.GoodsInOrderList.ToList();
            List<Okpo> temp4 = Program.db.OkpoList.ToList();
            List<Order> temp5 = Program.db.OrdersList.ToList();
            List<Treatie> temp6 = Program.db.TreatiesList.ToList();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
