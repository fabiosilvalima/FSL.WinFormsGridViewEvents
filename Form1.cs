using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSL.WinFormsGridViewEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SeedDataGrid();
        }

        private void SeedDataGrid()
        {
            var dts = new DataSet();
            dts.Tables.Add(new DataTable("Table1"));
            dts.Tables[0].Columns.Add("Checked", typeof(bool));
            dts.Tables[0].Columns.Add("FirstName", typeof(string));
            dts.Tables[0].Columns.Add("LastName", typeof(string));

            for (var i = 0; i < 10; i++)
            {
                var dtr = dts.Tables[0].NewRow();
                dtr["Checked"] = false;
                dtr["FirstName"] = $"Fabio {i}";
                dtr["LastName"] = $"Silva Lima {i}";

                dts.Tables[0].Rows.Add(dtr);
            }

            dataGridView1.DataSource = dts.Tables[0];
        }

        private void ToCellUpper(int rowIndex, int cellIndex)
        {
            var cell = dataGridView1.Rows[rowIndex].Cells[cellIndex];
            if (cell.ValueType == typeof(string))
            {
                var value = cell.Value as string;
                if (!string.IsNullOrEmpty(value))
                {
                    cell.Value = value.ToUpper();
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ToCellUpper(e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ToCellUpper(e.RowIndex, e.ColumnIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var table = dataGridView1.DataSource as DataTable;
            var rows = table.Select("Checked = true");
        }
    }
}
