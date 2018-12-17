using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
   public class ExamManager
    {
        public int InsertExam(Exam exam)
        {
            //Create the SQL Query for inserting an class
            string sqlQuery = String.Format("Insert into Exam (Subjects_id,Students_id,Assessment) Values('{0}','{1}','{2}');"
            + "Select @@Identity", exam.Subjects_id,exam.Students_id,exam.Assessment);

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

        public List<Exam> GetExam()
        {

            List<Exam> result = new List<Exam>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from Exam");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Exam article = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Exam();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.Subjects_id =Convert.ToInt32(dataReader["Subjects_id"]);
                    article.Students_id = Convert.ToInt32(dataReader["Students_id"]);
                    article.Assessment = Convert.ToInt32(dataReader["Assessment"]);
                    result.Add(article);
                }
            }

            return result;

        }
        public bool DeleteExam(int examID)
        {
            bool result = false;
            string sqlQuery = String.Format("delete from Exam where Id = {0}", examID);
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return result;
        }
        public int UpdateExam(Exam exam)
        {
            string createQuery = String.Format("Insert into Exam (Subjects_id,Students_id,Assessment) Values('{0}','{1}','{2}');"
                + "Select @@Identity", exam.Subjects_id, exam.Students_id, exam.Assessment);


            string updateQuery = String.Format("Update Exam SET Subjects_id='{0}',Students_id='{1}',Assessment='{2}' Where Id = {3};",
                exam.Subjects_id,exam.Students_id,exam.Assessment,exam.Id);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (exam.Id != 0)
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
                    savedArticleID = exam.Id;
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
