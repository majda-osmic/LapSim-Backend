using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Utils.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }
    }
}
