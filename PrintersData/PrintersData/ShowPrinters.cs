﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintersData
{
    public partial class ShowPrinters : Form
    {
        public ShowPrinters()
        {
            InitializeComponent();
        }

        private void ShowPrinters_Load(object sender, EventArgs e)
        {
            var db = new PrintersDB();
            
            var Printers = db.PrinterMasterData.Select(p => new
            {
                Name = p.PrinterName,
                IP = p.IPAddress,
                Branch = p.Branches.BranchName,
                p.PrintID,
                p.PrinterModels.PrinterModel,
                p.Description
            });
            
            dataGridView1.DataSource = new BindingSource
            {
                DataSource = Printers.ToList()
            };
            dataGridView1.Refresh();           
        }

       
        private void ShowPrinters_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
            ListSortDirection direction;

            //If oldColumn is null, then the DataGridView is not sorted
            if (oldColumn != null)
            {
                //Sort the same column again, reversing the SortOrder
                if (oldColumn == newColumn && dataGridView1.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    //Sort a new column and remove the old SortGlyph
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            //Sort the selected column
            dataGridView1.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == 
                ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Put each of the columns into programmatic sort order
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}
