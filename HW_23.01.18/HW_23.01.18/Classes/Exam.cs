using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Classes
{
    public class Exam
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Course { get; set; }
        public string Mentor { get; set; }
        public DateTime DateExam { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
        public virtual ICollection<StudentExamDocument> StudentExamDocuments { get; set; }
    }
}
