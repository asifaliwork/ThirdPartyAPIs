﻿namespace ThirdPartyAPIs.Models.Dummy
{
    public class Login
    {
        public string username { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public int expiresInMins { get; set; }
    }
}
