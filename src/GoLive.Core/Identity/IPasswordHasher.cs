using System;
using System.Collections.Generic;
using System.Text;

namespace GoLive.Core.Identity
{
    public interface IPasswordHasher
    {
        string HashPassword(Byte[] salt, string password);
    }
}
