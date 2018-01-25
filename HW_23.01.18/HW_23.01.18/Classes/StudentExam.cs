using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Classes
{
    public class StudentExam
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public DateTime ? TimePassed { get; set; }
        public int Grade { get; set; }
        public Student Students { get; set; }
        public Exam Exams { get; set; }
    }
}
