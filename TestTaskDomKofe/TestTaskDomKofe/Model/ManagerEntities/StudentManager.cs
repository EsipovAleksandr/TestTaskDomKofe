using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
    public class StudentManager: Manager
    {
        public int InsertSubjects(Students students)
        {
            string sqlQuery = String.Format("Insert into Students (FIO,YearOfStudy,Address,Phone,Class_id) Values(N'{0}','{1}',N'{2}','{3}','{4}');"
           + "Select @@Identity", students.FIO, students.YearOfStudy.ToString("yyyy-MM-dd"), students.Address, students.Phone, students.Class_id);
            return base.Insert(sqlQuery);
        }  
        public int UpdateStudents(Students students)
        {
            string createQuery = String.Format("Insert into Students (FIO,YearOfStudy,Address,Phone,Class_id) Values(N'{0}','{1}',N'{2}','{3}','{4}');"
       + "Select @@Identity", students.FIO, students.YearOfStudy.ToString("yyyy-MM-dd"), students.Address, students.Phone, students.Class_id);
            string updateQuery = String.Format("Update Students SET FIO=N'{0}',YearOfStudy='{1}',Address=N'{2}',Phone='{3}',Class_id='{4}'  Where Id = {5};",
               students.FIO, students.YearOfStudy.ToString("yyyy-MM-dd"), students.Address, students.Phone, students.Class_id, students.Id);
            return base.Update(students, createQuery, updateQuery);
        }
        public List<Students> GetStudents()
        {
            List<Students> result = new List<Students>();
            string sqlQuery = String.Format("select * from Students");
            SqlDataReader dataReader = base.Get(sqlQuery);
            Students article = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Students();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.FIO = dataReader["FIO"].ToString();
                    article.YearOfStudy = Convert.ToDateTime(dataReader["YearOfStudy"].ToString());
                    article.Address = dataReader["Address"].ToString();
                    article.Phone = dataReader["Phone"].ToString();
                    article.Class_id = Convert.ToInt32(dataReader["Class_id"]);
                    result.Add(article);
                }
            }

            return result;

        }
        public List<Students> GetTeachers(int value)
        {
            List<Students> result = new List<Students>();
            string sqlQuery = String.Format("SELECT studens.Id,studens.FIO,studens.Address,studens.YearOfStudy ,studens.Phone,studens.Class_id  FROM Students studens, Class class,Teachers teachers WHERE studens.Class_id= class.Id and class.Teacher_Id = teachers.Id and teachers.Id='{0}'"
                + "Select @@Identity",value);
            SqlDataReader dataReader = base.Get(sqlQuery);
            Students article = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Students();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.FIO = dataReader["FIO"].ToString();
                    article.YearOfStudy = Convert.ToDateTime(dataReader["YearOfStudy"].ToString());
                    article.Address = dataReader["Address"].ToString();
                    article.Phone = dataReader["Phone"].ToString();
                    article.Class_id = Convert.ToInt32(dataReader["Class_id"]);
                    result.Add(article);
                }
            }
            return result;
        }
        public List<Students> GetSubjects(int value)
        {
            List<Students> result = new List<Students>();
            string sqlQuery = String.Format("SELECT studens.Id,studens.FIO,studens.Address,studens.YearOfStudy ,studens.Phone,studens.Class_id  FROM Students studens, Class class,Teachers teachers,Subjects subjects WHERE studens.Class_id= class.Id and class.Teacher_Id = teachers.Id and teachers.Subjects_id=subjects.Id and subjects.Id='{0}'"
                + "Select @@Identity", value);
            SqlDataReader dataReader = base.Get(sqlQuery);
            Students article = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Students();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.FIO = dataReader["FIO"].ToString();
                    article.YearOfStudy = Convert.ToDateTime(dataReader["YearOfStudy"].ToString());
                    article.Address = dataReader["Address"].ToString();
                    article.Phone = dataReader["Phone"].ToString();
                    article.Class_id = Convert.ToInt32(dataReader["Class_id"]);
                    result.Add(article);
                }
            }
            return result;
        }
    }
}
