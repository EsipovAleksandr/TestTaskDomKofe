using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
   public class SubjectsManager
    {
        public int InsertSubjects(Subjects subjects)
        {
            //Create the SQL Query for inserting an class
            string sqlQuery = String.Format("Insert into  Subjects (SubjectName) Values('{0}');"
        + "Select @@Identity", subjects.SubjectName);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Execute the command to SQL Server and return the newly created ID
            int newclasseID = Convert.ToInt32((decimal)command.ExecuteScalar());

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            // Set return value
            return newclasseID;
        }
        public List<Subjects> GetSubjects()
        {

            List<Subjects> result = new List<Subjects>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from Subjects");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Subjects article = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Subjects();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.SubjectName = dataReader["SubjectName"].ToString();
                    result.Add(article);
                }
            }

            return result;

        }
        public bool DeleteSubjects(int subjectsID)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from Subjects where Id = {0}", subjectsID);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }
        public int UpdateSubjects(Subjects subjects)
        {

            //Create the SQL Query for inserting an article
            string createQuery = String.Format("Insert into Subjects (SubjectsName) Values('{0}');"
                + "Select @@Identity", subjects.SubjectName);

            //Create the SQL Query for updating an article
            string updateQuery = String.Format("Update Subjects SET SubjectName='{0}' Where Id = {1};",
                subjects.SubjectName, subjects.Id);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (subjects.Id != 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            int savedArticleID = 0;
            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedArticleID = Convert.ToInt32(commandResult);
                }
                else
                {
                    //the update SQL query will not return the primary key but if doesn't throw exception 
                    //then we will take it from the already provided data
                    savedArticleID = subjects.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //there was a problem executing the script
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            return savedArticleID;
        }
    }
}
