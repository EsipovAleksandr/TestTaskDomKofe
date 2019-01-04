using System;
using System.Collections.Generic;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Model.ManagerEntities
{
    interface IManager
    {
        int Insert(string sqlQuery);
    
        bool Delete(string dbName, int Id);
 
        int Update(Entity entities, string createQuery, string updateQuery);
       
    }
}
