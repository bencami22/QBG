using System;
using System.Collections.Generic;
using System.Text;
using Qbg.Data;
using Qbg.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.MySqlEfRepos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<User> GetUserWithRolesAsync(long id)
        {
            return base.entities.Include(user => user.UserRoles).ThenInclude(userRole=>userRole.Role).SingleOrDefaultAsync(p=>p.Id==id);
        }
    }
}
