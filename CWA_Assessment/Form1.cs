using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWA_Assessment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse pastel table to export",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "dat",
                Filter = "dat file (*.dat)|*.dat",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tableName = textBox2.Text.Trim();
            string tableLocation = textBox1.Text.Trim();
            string SQLFilter = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(tableLocation))
            {
                MessageBox.Show("Please select the table file to import.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Please specify the official table name to export.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(Path.GetExtension(tableLocation) != ".dat")
            {
                MessageBox.Show("Unexpected file extension. Please check your file.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tableLocation = Path.GetDirectoryName(tableLocation);
            DataTable dataTable;
            if (!string.IsNullOrEmpty(SQLFilter))
                dataTable = Data.ImportPastelTableWithSQLFilter($"SELECT * FROM {tableName} WHERE {SQLFilter}", tableLocation);
            else
                dataTable = Data.ImportPastelTable(tableName, tableLocation);
            
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + tableName + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"); //create the file
            string lines = Data.ExportTableToTXT(dataTable);
            sw.WriteLine(lines); //write data
            sw.Close();
            MessageBox.Show("Export completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
