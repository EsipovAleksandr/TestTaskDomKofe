﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model.Entities
{
    public class Classe: Entity
    {
        public int Teacher_Id { set; get; }
        
        public string Numbers { set; get; }
    }
}
