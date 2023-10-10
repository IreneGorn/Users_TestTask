using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public Guid RoleId { get; set; }

        /*public virtual ICollection<Role> Roles { get; set; }
        public User()
        {
            Roles = new List<Role>();
        }*/
    }
}
