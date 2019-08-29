using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.DTOs
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticatedUser
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
