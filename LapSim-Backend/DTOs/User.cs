﻿using Newtonsoft.Json;


namespace LapSimBackend.DTOs
{
    public class User
    {
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticatedUser
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
