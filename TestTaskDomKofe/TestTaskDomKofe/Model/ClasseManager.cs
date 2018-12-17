using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model
{
  public  class ClassManager
    {
        public int InsertClass(Classe classe)
        {
            //Create the SQL Query for inserting an class
            string sqlQuery = String.Format("Insert into Class (Number) Values('{0}');"
            +"Select @@Identity", classe.Numbers);

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
        public List<Classe> GetClasse()
        {

            List<Classe> result = new List<Classe>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from Class");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            Classe article = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Classe();
                    article.Id =Convert.ToInt32(dataReader["Id"]);
                    article.Numbers = dataReader["Number"].ToString();
                    result.Add(article);
                }
            }

            return result;

        }
        public bool DeleteClasse(int classeID)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from Class where Id = {0}", classeID);

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
        public int UpdateClasse(Classe classe)
        {

            //Create the SQL Query for inserting an article
            string createQuery = String.Format("Insert into Class (Number) Values('{0}');"
                + "Select @@Identity", classe.Numbers);

            //Create the SQL Query for updating an article
            string updateQuery = String.Format("Update Class SET Number='{0}' Where Id = {1};",
                classe.Numbers, classe.Id);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (classe.Id != 0)
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
                    savedArticleID = classe.Id;
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
