using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Utils.Exceptions
{
    public class UserAlreadyExistsException : AppException
    {
        public UserAlreadyExistsException() : base("User with the same User Name already exists")
        {

        }
    }
}
