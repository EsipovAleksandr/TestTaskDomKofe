using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model
{
  public  class ClassManager:Manager
    {   
        public int InsertClass(Classe classe)
        {
            string sqlQuery = String.Format("Insert into Class (Number,Teacher_Id) Values('{0}','{1}');"
            + "Select @@Identity", classe.Numbers,classe.Teacher_Id);        
            return base.Insert(sqlQuery);
        }
        public int UpdateClasse(Classe classe)
        {
            string createQuery = String.Format("Insert into Class (Number,Teacher_Id) Values('{0}','{1}');"
                + "Select @@Identity", classe.Numbers, classe.Teacher_Id);
            string updateQuery = String.Format("Update Class SET Number='{0}' Teacher_Id='{1}' Where Id = {1};",
                classe.Numbers, classe.Teacher_Id, classe.Id);
            return base.Update(classe, createQuery, updateQuery);
        }
        public List<Classe> GetClasse()
        {
            List<Classe> result = new List<Classe>();
            string sqlQuery = String.Format("select * from Class");           
            Classe classe = null;
            SqlDataReader dataReader = base.Get(sqlQuery);
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    classe = new Classe();
                    classe.Id =Convert.ToInt32(dataReader["Id"]);
                    classe.Numbers = dataReader["Number"].ToString();
                    classe.Teacher_Id = Convert.ToInt32(dataReader["Teacher_Id"]);
                    result.Add(classe);
                }
            }
            return result;
        }     
    }

}
