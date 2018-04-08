using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qbg.Data;

namespace Qbg.IRepos
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserWithRolesAsync(long id);
    }
}
