using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model.Entities
{
    public  class Subjects
    {
        public Subjects()
        {
            this.Exam = new HashSet<Exam>();
            this.Teachers = new HashSet<Teachers>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
