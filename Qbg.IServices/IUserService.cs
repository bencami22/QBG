using Qbg.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qbg.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        User InsertUser(User user);
        User UpdateUser(long id, User user);
        void DeleteUser(long id);
        User GetUser(string username);
        bool IsValid(string username, string password);
    }
}
