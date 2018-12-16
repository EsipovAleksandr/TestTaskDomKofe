using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model.Entities
{
   public class Exam
    {
        public int Id { get; set; }
        public int Subjects_id { get; set; }
        public int Students_id { get; set; }
        public int Assessment { get; set; }

        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
