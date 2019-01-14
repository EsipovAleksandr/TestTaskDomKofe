using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
    public  class TeachersManager: Manager
    {
        public int InsertSubjects(Teachers teachers)
        {   
            string sqlQuery = String.Format("Insert into Teachers (FIO,DateOfBirth,Address,Phone,Subjects_id) Values(N'{0}','{1}',N'{2}',N'{3}','{4}');"
           + "Select @@Identity",teachers.FIO, teachers.DateOfBirth.ToString("yyyy-MM-dd"), teachers.Address, teachers.Phone, teachers.Subjects_id);
            return base.Insert(sqlQuery);
        }
        public int UpdateTeachers(Teachers teachers)
        {
            string createQuery = String.Format("Insert into Teachers (FIO,DateOfBirth,Address,Phone,Subjects_id) Values(N'{0}','{1}',N'{2}','{3}','{4}');"
       + "Select @@Identity", teachers.FIO, teachers.DateOfBirth.ToString("yyyy-MM-dd"), teachers.Address, teachers.Phone, teachers.Subjects_id);

            string updateQuery = String.Format("Update Teachers SET FIO=N'{0}',DateOfBirth='{1}',Address=N'{2}',Phone='{3}',Subjects_id='{4}'  Where Id = {5};",
               teachers.FIO, teachers.DateOfBirth.ToString("yyyy-MM-dd"), teachers.Address, teachers.Phone, teachers.Subjects_id, teachers.Id);

            return base.Update(teachers, createQuery, updateQuery);
        }
        public List<Teachers> GetTeachers()
        {
            List<Teachers> result = new List<Teachers>();
            string sqlQuery = String.Format("SELECT first.Id,first.FIO,first.DateOfBirth,first.Address,first.Phone,first.Subjects_id,second.SubjectName from Teachers first, Subjects second where first.Subjects_id = second.Id");
            SqlDataReader dataReader = base.Get(sqlQuery);
            Teachers article = null;
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
                    article.Subjects_id = Convert.ToInt32(dataReader["Subjects_id"]);
                    article.SubjectName = dataReader["SubjectName"].ToString();
                    result.Add(article);
                }
            }
            return result;
        }
    }
}
