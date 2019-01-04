using System;
using System.Collections.Generic;

namespace TestTaskDomKofe.Model.Entities
{
    public class Students: Entity
    {
        public Students()
        {
            this.Exam = new HashSet<Exam>();
        }

   
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime YearOfStudy { get; set; }
        public int Class_id { get; set; }

        public virtual Classe Class { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
