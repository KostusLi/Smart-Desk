using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message): base(message){ }
    }
}
