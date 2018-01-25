using HW_23._01._18.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_23._01._18.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.FirstName).HasMaxLength(30).IsRequired();
            Property(p => p.LastName).HasMaxLength(30).IsRequired();
            Property(p => p.BirthDay).IsRequired();
            Property(p => p.Phone).HasMaxLength(20).IsRequired();
        }
    }
}
