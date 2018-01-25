using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_EntityFrameworkOne.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ? BirthDate { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<UserPost> Posts { get; set; }
        public User()
        {
            Groups = new List<Group>();
            Posts = new List<UserPost>();
        }
    }
}
