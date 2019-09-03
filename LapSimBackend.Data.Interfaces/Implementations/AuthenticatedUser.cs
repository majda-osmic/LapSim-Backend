using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces.Implementations
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public UserRole Role { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
