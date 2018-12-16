using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDomKofe.Model.Entities
{
   public class Teachers
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Subjects_id { get; set; }

        public virtual Subjects Subjects { get; set; }
    }
}
