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
    public class UserPostConfiguration : EntityTypeConfiguration<UserPost>
    {
        public UserPostConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Post).HasMaxLength(200).IsRequired();
            Property(p => p.CreationDate).IsRequired();
            HasMany(p => p.Comments).WithRequired(p => p.UserPost).HasForeignKey(p => p.UserPostId);
        }
    }
}
