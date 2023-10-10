using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(UsersDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
