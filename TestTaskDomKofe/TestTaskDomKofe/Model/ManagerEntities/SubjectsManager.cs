using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
   public class SubjectsManager: Manager
    {
        public int InsertSubjects(Subjects subjects)
        {
            string sqlQuery = String.Format("Insert into  Subjects (SubjectName) Values('{0}');"
        + "Select @@Identity", subjects.SubjectName);
            return base.Insert(sqlQuery);
        } 
        public int UpdateSubjects(Subjects subjects)
        {
            string createQuery = String.Format("Insert into Subjects (SubjectsName) Values('{0}');"
                + "Select @@Identity", subjects.SubjectName);
            string updateQuery = String.Format("Update Subjects SET SubjectName='{0}' Where Id = {1};",
                subjects.SubjectName, subjects.Id);
            return base.Update(subjects, createQuery, updateQuery);
        }
        public List<Subjects> GetSubjects()
        {
            List<Subjects> result = new List<Subjects>();
            string sqlQuery = String.Format("select * from Subjects");
            SqlDataReader dataReader = base.Get(sqlQuery);
            Subjects article = null;
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
    }
}
