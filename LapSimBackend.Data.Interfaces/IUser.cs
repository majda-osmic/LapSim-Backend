using System;
using System.Collections.Generic;
using System.Text;

namespace LapSimBackend.Data.Interfaces
{
    public interface IUser
    {
        string Username { get; set; }
    }

    public interface IAuthenticatedUser : IUser
    {
        Role Role { get; set; }
        string Token { get; set; }
    }

    public class Role
    {
        public static readonly Role Admin = new Role("Admin");
        public static readonly Role ProjectLeader = new Role("ProjectLeader");

        private readonly string _role;

        public string Value => _role.ToString();

        private Role(string role)
        {
            _role = role; 
        }

        public override string ToString() => _role;

        public static Role FromString(string role)
        {
            if (role?.ToLower().Equals("admin") ?? false)
                return Role.Admin;
            return Role.ProjectLeader;
        }
    }

}
