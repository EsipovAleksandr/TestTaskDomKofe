using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model.Entities
{
   public class ExamModel
    {
        public int Id { set; get; }
        public string FIO { set; get; }
        public string SubjectName { set; get; }
        public int Assessment { set; get; }
        public int Subjects_id { get; set; }
        public int Students_id { get; set; }

    }
}
