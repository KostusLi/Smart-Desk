using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPasswordHasher
    {
        public Task<string> Hasher(string password);
        public Task<bool> Verify(string password, string passwordHash);
    }
}
