using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model.Entities
{
   public class Students
    {
        public Students()
        {
            this.Exam = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int Class_id { get; set; }

        public virtual Classe Class { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
