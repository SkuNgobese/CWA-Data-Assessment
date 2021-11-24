using PervasiveImporter__32_bit_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA_Assessment
{
    public static class Data
    {
        public static DataTable ImportPastelTable(string tableName, string fileLocation = "C:\\Users\\Innocent\\source\\repos\\CWA-Data-Assessment\\PastelData\\mike2009")
        {
            PSQLImport32 PSQL32 = new PSQLImport32();
            //var sql = PSQL32.sync_ImportSQL(fileLocation, Server: "", "select * from BICUsers");

            return PSQL32.sync_ImportTable(fileLocation, Server: "", tableName);            
        }

        public static DataTable ImportPastelTableWithSQLFilter(string SQLQuery, string fileLocation = "C:\\Users\\Innocent\\source\\repos\\CWA-Data-Assessment\\PastelData\\mike2009", string server = "")
        {
            try
            {
                PSQLImport32 PSQL32 = new PSQLImport32();

                return PSQL32.sync_ImportSQL(fileLocation, Server: server, SQLQuery);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public static string ExportTableToTXT(this DataTable datatable, char seperator = '|')
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    sb.Append(datatable.Columns[i]);
                    if (i < datatable.Columns.Count - 1)
                        sb.Append(seperator);
                }
                sb.AppendLine();

                foreach (DataRow dr in datatable.Rows)
                {
                    for (int i = 0; i < datatable.Columns.Count; i++)
                    {
                        sb.Append(dr[i].ToString());

                        if (i < datatable.Columns.Count - 1)
                            sb.Append(seperator);
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
