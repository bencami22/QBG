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
        Task<User> InsertUserAsync(string username, string email, string password);
        Task<User> UpdateUserAsync(long id, string email, string username, string password);
        void DeleteUserAsync(long id);
        Task<User> GetUserAsync(string username);
        Task<bool> IsValidAsync(string username, string password);
        void AssignRoleAsync(User user, RoleEnum role);
    }
}
