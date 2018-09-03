using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formsGolf2018
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAllData_Click(object sender, EventArgs e)
        {

            DGVGolf.DataSource = CommandsToDB.AllData();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            btnCount.Text = CommandsToDB.CountMembers();

        }

        private void DGVGolf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //show the data in the DGV in the text boxes
                string newvalue = DGVGolf.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //show the output on the header
                this.Text = "Row : " + e.RowIndex.ToString() + "  Col : " + e.ColumnIndex.ToString() + " Value = " + newvalue;
                //pass data to the text boxes
                txtID.Text = DGVGolf.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = DGVGolf.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFirstname.Text = DGVGolf.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSurname.Text = DGVGolf.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGender.Text = DGVGolf.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDOB.Text = DGVGolf.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtStreet.Text = DGVGolf.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSuburb.Text = DGVGolf.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCity.Text = DGVGolf.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAvailable.Text = DGVGolf.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtHandicap.Text = DGVGolf.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
            catch
            {
            }

        }
    }
}
