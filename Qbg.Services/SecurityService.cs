using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Qbg.IServices;

namespace Qbg.Services
{
    public class SecurityService : ISecurityService
    {
        public string Hash(string text, string salt)
        {
            using (SHA512 shaHash = SHA512.Create())
            {
                byte[] result = shaHash.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(text, salt)));
                return Encoding.UTF8.GetString(result); ;
            }
        }
    }
}
