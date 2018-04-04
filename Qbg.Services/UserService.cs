using Qbg.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Qbg.Data;
using Qbg.IRepos;
using System.Linq;

namespace Qbg.Services
{
    public class UserService : IUserService
    {
        private ISecurityService securityService;
        private IGenericRepository<User> userRepository;

        public UserService(IGenericRepository<User> userRepo, ISecurityService securityService)
        {
            this.userRepository = userRepo;
            this.securityService = securityService;
        }

        public void DeleteUser(long id)
        {
            userRepository.Delete(this.GetUser(id));
        }

        public User GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public User GetUser(string username)
        {
            return userRepository.GetAll().FirstOrDefault(p => p.Username == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User InsertUser(User user)
        {
            user.Password = securityService.Hash(user.Password, "90a0b7426cff4fafb5b5223e51bcf6cc");
            return userRepository.Insert(user);
        }

        public bool IsValid(string username, string password)
        {
            return this.GetUser(username)?.Password == securityService.Hash(password, "90a0b7426cff4fafb5b5223e51bcf6cc");
        }

        public User UpdateUser(long id, User user)
        {
            var currentUser=GetUser(id);
            currentUser.Email = user.Email;
            currentUser.Password = securityService.Hash(user.Password, "90a0b7426cff4fafb5b5223e51bcf6cc");
            currentUser.Username = user.Username;
            currentUser.UserRoles = user.UserRoles;
            return userRepository.Update(user);
        }
    }
}
