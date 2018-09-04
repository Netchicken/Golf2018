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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //this updates existing data in the database where the ID of the data equals the ID in the text box

            string UpdateQuery = Queries.UpdateQuery;

            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = Connection.ConnectionString;


            SqlCommand update = new SqlCommand(UpdateQuery, Con);
            //create the parameters and pass the data from the textboxes

            update.Parameters.AddWithValue("@ID", txtID.Text);
            update.Parameters.AddWithValue("@Title", txtTitle.Text);
            update.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
            update.Parameters.AddWithValue("@Surname", txtSurname.Text);
            update.Parameters.AddWithValue("@Street", txtStreet.Text);
            update.Parameters.AddWithValue("@Suburb", txtSuburb.Text);
            update.Parameters.AddWithValue("@City", txtCity.Text);
            update.Parameters.AddWithValue("@Gender", txtGender.Text);
            update.Parameters.AddWithValue("@DOB", txtDOB.Text);
            update.Parameters.AddWithValue("@Handicap", txtHandicap.Text);
            update.Parameters.AddWithValue("@Available", txtAvailable.Text);

            Con.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            Con.Close();

            //refresh dgv with the new data
            DGVGolf.DataSource = CommandsToDB.AllData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CommandsToDB.DeleteData(txtID.Text);

            //refresh dgv with the new data
            DGVGolf.DataSource = CommandsToDB.AllData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string NewEntry = Queries.InsertQuery;
            SqlConnection Con = new SqlConnection();
            string connectionString = Connection.ConnectionString;
            Con.ConnectionString = connectionString;
            using (SqlCommand newdata = new SqlCommand(NewEntry, Con))
            {

                newdata.Parameters.AddWithValue("@Title", txtTitle.Text);
                newdata.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                newdata.Parameters.AddWithValue("@Surname", txtSurname.Text);
                newdata.Parameters.AddWithValue("@Street", txtStreet.Text);
                newdata.Parameters.AddWithValue("@Suburb", txtSuburb.Text);
                newdata.Parameters.AddWithValue("@City", txtCity.Text);
                newdata.Parameters.AddWithValue("@Gender", txtGender.Text);
                newdata.Parameters.AddWithValue("@DOB", txtDOB.Text);
                newdata.Parameters.AddWithValue("@Handicap", txtHandicap.Text);
                newdata.Parameters.AddWithValue("@Available", txtAvailable.Text);

                Con.Open(); //open a connection to the database
                //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery();  //Run the Query
                //a happy message box
                MessageBox.Show("Data has been Inserted  !! ");
            }
            //refresh dgv with the new data
            DGVGolf.DataSource = CommandsToDB.AllData();

        }
    }
}
