using Qbg.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Qbg.Data;
using Qbg.IRepos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Qbg.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IGenericRepository<Role> roleRepository;
        private ISecurityService securityService;

        public UserService(IUserRepository userRepo, IGenericRepository<Role> roleRepo, ISecurityService securityService)
        {
            this.userRepository = userRepo;
            this.securityService = securityService;
            this.roleRepository = roleRepo;
        }

        public async void DeleteUserAsync(long id)
        {
            userRepository.DeleteAsync(await this.GetUserAsync(id));
        }

        public async Task<User> GetUserAsync(long id, bool includeRoles = false)
        {
            if (includeRoles)
            {
                return await userRepository.GetUserWithRolesAsync(id);
            }
            return await userRepository.GetAsync(id);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await userRepository.GetAll().FirstOrDefaultAsync(p => p.Username == username);
        }

        public IQueryable<User> GetUsersAsync()
        {
            return userRepository.GetAll();
        }

        public async Task<User> InsertUserAsync(User user)
        {
            user.Password = securityService.Hash(user.Password, "90a0b7426cff4fafb5b5223e51bcf6cc");
            return await userRepository.InsertAsync(user);
        }

        public async void AssignRoleAsync(User user, RoleEnum role)
        {
            if (user.UserRoles == null)
            {
                user.UserRoles = new List<UserRole>();
            }
            user.UserRoles.Add(new UserRole(user, await roleRepository.GetAsync((long)role) ?? new Role(role)));
        }

        public async Task<bool> IsValidAsync(string username, string password)
        {
            return (await this.GetUserAsync(username))?.Password == securityService.Hash(password, "90a0b7426cff4fafb5b5223e51bcf6cc");
        }

        public async Task<User> UpdateUserAsync(long id, User user)
        {
            var currentUser = await GetUserAsync(id);
            currentUser.Email = user.Email;
            currentUser.Password = securityService.Hash(user.Password, "90a0b7426cff4fafb5b5223e51bcf6cc");
            currentUser.Username = user.Username;
            currentUser.UserRoles = user.UserRoles;
            return await userRepository.UpdateAsync(user);
        }

    }
}
