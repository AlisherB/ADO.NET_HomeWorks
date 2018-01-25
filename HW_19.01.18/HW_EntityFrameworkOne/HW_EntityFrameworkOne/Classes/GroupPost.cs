using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EntityFrameworkOne.Classes
{
    public class GroupPost
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime CreationDate { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
