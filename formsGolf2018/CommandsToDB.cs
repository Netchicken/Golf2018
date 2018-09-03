using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formsGolf2018
{
    static class CommandsToDB
    {

        public static DataTable AllData()
        {

            //to use our DB we need 3 things
            //1 A connection string to a database
            string ConnectionString = formsGolf2018.Connection.ConnectionString;

            //2 we need to make a connection using the connection string
            SqlConnection Connection = new SqlConnection(ConnectionString);

            //3 We need to ask a question using a query
            string query = Queries.SelectAllQuery;

            //we need to make a command with our connection and our query
            SqlCommand Command = new SqlCommand(query, Connection);

            // we need a table to hold our data that comes back
            DataTable golftable = new DataTable();
            //we need to create columns to hold our data and name it
            golftable.Columns.Add("ID");
            golftable.Columns.Add("Firstname");
            golftable.Columns.Add("Surname");
            golftable.Columns.Add("Title");
            golftable.Columns.Add("Gender");
            golftable.Columns.Add("DOB");
            golftable.Columns.Add("Street");
            golftable.Columns.Add("Suburb");
            golftable.Columns.Add("City");
            golftable.Columns.Add("Available week days");
            golftable.Columns.Add("Handicap");

            Connection.Open();
            // need a reader to read in our data from teh database
            SqlDataReader reader = Command.ExecuteReader();
            //  we need to loop through all the data and pass it into the table
            while (reader.Read())
            {
                golftable.Rows.Add(
                    reader["ID"],
                    reader["Title"],
                    reader["Firstname"],
                    reader["Surname"],
                    reader["Gender"],
                    reader["DOB"],
                    reader["Street"],
                    reader["Suburb"],
                    reader["City"],
                    reader["Available week days"],
                    reader["Handicap"]);
            }
            Connection.Close();

            return golftable;
        }

        public static String CountMembers()
        {

            //returning a Scalar value = one data piece

            //to use our DB we need 3 things
            //1 A connection string to a database
            string ConnectionString = formsGolf2018.Connection.ConnectionString;


            //2 we need to make a connection using the connection string
            SqlConnection Connection = new SqlConnection(ConnectionString);

            //3 We need to ask a question using a query
            string query = Queries.CountMembersQuery;

            //we need to make a command with our connection and our query
            SqlCommand Command = new SqlCommand(query, Connection);

            Connection.Open();
            string response = Command.ExecuteScalar().ToString();
            Connection.Close();

            return response;
        }


    }
}
