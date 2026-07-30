using Domain.Entities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IJwtProvider
    {
        public Task<string> GenerateToken(User user);
    }
}
