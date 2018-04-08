using Qbg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qbg.IServices
{
    public interface IUserService
    {
        IQueryable<User> GetUsersAsync();
        Task<User> GetUserAsync(long id, bool includeRoles = false);
        Task<User> InsertUserAsync(User user);
        Task<User> UpdateUserAsync(long id, User user);
        void DeleteUserAsync(long id);
        Task<User> GetUserAsync(string username);
        Task<bool> IsValidAsync(string username, string password);
        void AssignRoleAsync(User user, RoleEnum role);
    }
}
