using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
  public  class TeachersManager
    {
        public int InsertSubjects(Teachers teachers)
        {      
            string sqlQuery = String.Format("Insert into Teachers (FIO,DateOfBirth,Address,Phone,Subjects_id) Values(N'{0}','{1}',N'{2}',N'{3}','{4}');"
           + "Select @@Identity",teachers.FIO, teachers.DateOfBirth.ToString("yyyy-MM-dd"), teachers.Address, teachers.Phone, teachers.Subjects_id);
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
        public List<Teachers> GetTeachers()
        {

            List<Teachers> result = new List<Teachers>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from Teachers");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Teachers article = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Teachers();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.FIO = dataReader["FIO"].ToString();
                    article.DateOfBirth = Convert.ToDateTime(dataReader["DateOfBirth"]);
                    article.Address = dataReader["Address"].ToString();
                    article.Phone = dataReader["Phone"].ToString();
                    article.Subjects_id =Convert.ToInt32(dataReader["Subjects_id"]);
                    result.Add(article);
                }
            }

            return result;

        }
        public bool DeleteTeachers(int teachersId)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from Teachers where Id = {0}", teachersId);

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
        public int UpdateTeachers(Teachers teachers)
        {

            //Create the SQL Query for inserting an article

            string createQuery = String.Format("Insert into Teachers (FIO,DateOfBirth,Address,Phone,Subjects_id) Values(N'{0}','{1}',N'{2}','{3}','{4}');"
       + "Select @@Identity", teachers.FIO, teachers.DateOfBirth.ToString("yyyy-MM-dd"), teachers.Address, teachers.Phone, teachers.Subjects_id);

            string updateQuery = String.Format("Update Teachers SET FIO=N'{0}',DateOfBirth='{1}',Address=N'{2}',Phone='{3}',Subjects_id='{4}'  Where Id = {5};",
               teachers.FIO, teachers.DateOfBirth.ToString("yyyy-MM-dd"), teachers.Address, teachers.Phone, teachers.Subjects_id, teachers.Id);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (teachers.Id != 0)
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
                    savedArticleID = teachers.Id;
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
