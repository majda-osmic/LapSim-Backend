using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Utils.Exceptions
{
    public class UserAlreadyExistsException : AppException
    {
        public UserAlreadyExistsException(string userName) : base($"User '{userName}' already exists")
        {

        }
    }
}
