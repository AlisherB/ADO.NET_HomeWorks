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
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.GroupName).HasMaxLength(50).IsRequired();
            Property(p => p.NumberOfStudents).IsRequired();
            HasMany(p => p.Users).WithMany(p => p.Groups)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("GroupId");
                    m.ToTable("UserGroup");
                });
            HasMany(p => p.Posts).WithRequired(p => p.Group).HasForeignKey(p => p.GroupId);
        }
    }
}
