using HW_23._01._18.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Configurations
{
    public class ExamConfiguration : EntityTypeConfiguration<Exam>
    {
        public ExamConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Subject).HasMaxLength(100).IsRequired();
            Property(p => p.Mentor).HasMaxLength(100).IsRequired();
            Property(p => p.Course).HasMaxLength(100).IsRequired();
            Property(p => p.DateExam).IsRequired();
        }
    }
}
