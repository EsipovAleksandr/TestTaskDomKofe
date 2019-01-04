using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
   public class ExamManager: Manager
    {
        public int InsertExam(Exam exam)
        {
            string sqlQuery = String.Format("Insert into Exam (Subjects_id,Students_id,Assessment) Values('{0}','{1}','{2}');"
            + "Select @@Identity", exam.Subjects_id,exam.Students_id,exam.Assessment);
            return base.Insert(sqlQuery);
        }
        public int UpdateExam(Exam exam)
        {
            string createQuery = String.Format("Insert into Exam (Subjects_id,Students_id,Assessment) Values('{0}','{1}','{2}');"
                + "Select @@Identity", exam.Subjects_id, exam.Students_id, exam.Assessment);

            string updateQuery = String.Format("Update Exam SET Subjects_id='{0}',Students_id='{1}',Assessment='{2}' Where Id = {3};",
                exam.Subjects_id,exam.Students_id,exam.Assessment,exam.Id);

            return base.Update(exam, createQuery, updateQuery);
        }
        public List<ExamModel> GetExamModel()
        {
            List<ExamModel> result = new List<ExamModel>();
            string sqlQuery = String.Format("SELECT first.Id,first.Students_id,first.Subjects_id  ,second.FIO,third.SubjectName,first.Assessment FROM Exam first, Students second,Subjects third WHERE  first.Subjects_id= third.Id and first.Students_id = second.Id");
            SqlDataReader dataReader = base.Get(sqlQuery);
            ExamModel article = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new ExamModel();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.FIO = dataReader["FIO"].ToString();
                    article.SubjectName = dataReader["SubjectName"].ToString();
                    article.Assessment = Convert.ToInt32(dataReader["Assessment"]);
                    article.Subjects_id = Convert.ToInt32(dataReader["Subjects_id"]);
                    article.Students_id = Convert.ToInt32(dataReader["Students_id"]);
                    result.Add(article);
                }
            }
            return result;
        }
        public List<Exam> GetExam()
        {
            List<Exam> result = new List<Exam>();
            string sqlQuery = String.Format("select * from Exam");
            SqlDataReader dataReader = base.Get(sqlQuery);
            Exam article = null;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article = new Exam();
                    article.Id = Convert.ToInt32(dataReader["Id"]);
                    article.Subjects_id = Convert.ToInt32(dataReader["Subjects_id"]);
                    article.Students_id = Convert.ToInt32(dataReader["Students_id"]);
                    article.Assessment = Convert.ToInt32(dataReader["Assessment"]);
                    result.Add(article);
                }
            }
            return result;
        }
    }
}
