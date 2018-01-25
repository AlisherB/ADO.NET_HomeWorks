using HW_23._01._18.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Configurations
{
    public class StudentExamConfiguration : EntityTypeConfiguration<StudentExam>
    {
        public StudentExamConfiguration()
        {
            HasKey(p => new { p.ExamId, p.StudentId });
            Property(p => p.TimePassed).IsOptional();
            Property(p => p.Grade).IsRequired();
            HasRequired(p => p.Students).WithMany(p => p.StudentExams).HasForeignKey(p => p.StudentId);
            HasRequired(p => p.Exams).WithMany(p => p.StudentExams).HasForeignKey(p => p.ExamId);
        }
    }
}
