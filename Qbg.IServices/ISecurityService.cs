using System;
using System.Collections.Generic;
using System.Text;

namespace Qbg.IServices
{
    public interface ISecurityService
    {
        string Hash(string text, string salt);
    }
}
