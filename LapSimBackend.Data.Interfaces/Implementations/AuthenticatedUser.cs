using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public Role Role { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
