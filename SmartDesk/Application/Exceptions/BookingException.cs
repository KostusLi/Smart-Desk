using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class BookingException : Exception
    {
        public BookingException(string message) : base(message) { }

    }
}
