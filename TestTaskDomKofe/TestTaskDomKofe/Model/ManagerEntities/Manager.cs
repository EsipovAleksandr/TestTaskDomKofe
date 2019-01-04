using System;
using System.Data.SqlClient;
using TestTaskDomKofe.Model.Entities;
using TestTaskDomKofe.Model.ManagerEntities;

namespace TestTaskDomKofe.Model
{
    public class Manager: IManager
    {
        public int Insert(string sqlQuery)
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            int newclasseID = Convert.ToInt32((decimal)command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return newclasseID;
        }
        public bool Delete(string dbName, int Id)
        {
            bool result = false;
            string sqlQuery = String.Format("delete from {0} where Id = {1}", dbName, Id);
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
        public int Update(Entity entities, string createQuery, string updateQuery)
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();
            SqlCommand command = null;
            if (entities.Id != 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            int savedArticleID = 0;
            try
            {
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedArticleID = Convert.ToInt32(commandResult);
                }
                else
                {
                    savedArticleID = entities.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return savedArticleID;
        }
        public SqlDataReader Get(string sqlQuery)
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader dataReader = command.ExecuteReader();

            return dataReader;
        }
    }
}
