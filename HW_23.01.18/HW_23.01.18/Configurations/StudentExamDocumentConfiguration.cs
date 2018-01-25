using HW_23._01._18.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Configurations
{
    public class StudentExamDocumentConfiguration : EntityTypeConfiguration<StudentExamDocument>
    {
        public StudentExamDocumentConfiguration()
        {
            HasKey(p => new { p.ExamId, p.StudentId });
            Property(p => p.CountDocuments).IsRequired();
            HasRequired(p => p.Students).WithMany(p => p.StudentExamDocuments).HasForeignKey(p => p.StudentId);
            HasRequired(p => p.Exams).WithMany(p => p.StudentExamDocuments).HasForeignKey(p => p.ExamId);
        }
    }
}
