using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EntityFrameworkOne.Classes
{
    public class UserPost
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public UserPost()
        {
            Comments = new List<Comment>();
        }
    }
}
