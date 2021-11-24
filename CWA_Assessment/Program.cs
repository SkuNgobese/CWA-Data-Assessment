using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PervasiveImporter__32_bit_;

namespace CWA_Assessment
{
    public static class Program
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
        }

        //public static void Import()
        //{

        //    //32 bit is used to create access to the  PervasiveImporter__32_bit_
        //    PSQLImport32 PSQL32 = new PSQLImport32();
        //    var dt = PSQL32.sync_ImportTable("C:\\Users\\Innocent\\source\\repos\\CWA-Data-Assessment\\PastelData\\mike2009", Server: "", "InternetBank");
        //    var sql = PSQL32.sync_ImportSQL("C:\\Users\\Innocent\\source\\repos\\CWA-Data-Assessment\\PastelData\\mike2009", Server: "", "select * from BICUsers");
        //    /**
        //     * Within this variable you can access Patel data in to forms
        //     * Quering a table or running a SQL qury against multiple tables
        //     * example of doing the connection :
        //     * PSQL32.sync_ImportSQL(Path to the Pastel data , Server this must stay as : 'Server = ""', Table name or SQL query)
        //     */
        //}
    }
}
