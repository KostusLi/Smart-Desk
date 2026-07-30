using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public async Task<string> Hasher(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 12);
        }

        public async Task<bool> Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

    }
}
