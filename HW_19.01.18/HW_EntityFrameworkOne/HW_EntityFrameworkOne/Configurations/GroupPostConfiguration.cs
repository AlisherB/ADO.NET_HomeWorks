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
    public class GroupPostConfiguration : EntityTypeConfiguration<GroupPost>
    {
        public GroupPostConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Post).HasMaxLength(200).IsRequired();
            Property(p => p.CreationDate).IsRequired();
        }
    }
}
