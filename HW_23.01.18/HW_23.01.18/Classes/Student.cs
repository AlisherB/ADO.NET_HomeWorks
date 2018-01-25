using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Classes
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
        public virtual ICollection<StudentExamDocument> StudentExamDocuments { get; set; }
    }
}
