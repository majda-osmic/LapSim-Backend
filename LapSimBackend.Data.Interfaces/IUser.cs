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
        UserRole Role { get; set; }
        string Token { get; set; }
    }


    public static class Role
    {
        public const string Admin = "Admin";
        public const string ProjectLeader = "ProjectLeader";
    }

    public class UserRole
    {
        public static readonly UserRole Admin = new UserRole(Role.Admin);
        public static readonly UserRole ProjectLeader = new UserRole(Role.ProjectLeader);


        //for serialization
        public string Value { get; }

        private UserRole(string role)
        {
            Value = role; 
        }

        public override string ToString() => Value;

        public static UserRole FromString(string role)
        {
            if (role?.ToLower().Equals(Role.Admin.ToLower()) ?? false)
                return UserRole.Admin;
            return UserRole.ProjectLeader;
        }
    }

}
