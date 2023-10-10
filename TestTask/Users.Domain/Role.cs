using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain
{
    public class Role
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
