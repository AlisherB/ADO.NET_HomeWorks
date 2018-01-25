using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EntityFrameworkOne.Classes
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CreationDate { get; set; }
        public UserPost UserPost { get; set; }
        public int UserPostId { get; set; }
    }
}
