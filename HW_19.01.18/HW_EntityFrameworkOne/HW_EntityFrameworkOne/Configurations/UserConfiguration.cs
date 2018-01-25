using HW_EntityFrameworkOne.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EntityFrameworkOne.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.FirstName).HasMaxLength(30).IsRequired();
            Property(p => p.LastName).HasMaxLength(30).IsRequired();
            Property(p => p.Phone).HasMaxLength(20).IsRequired();
            Property(p => p.Email).HasMaxLength(50).IsRequired();
            Property(p => p.BirthDate).IsOptional();
            HasMany(p => p.Posts).WithRequired(p => p.User).HasForeignKey(p => p.UserId);
        }
    }
}
