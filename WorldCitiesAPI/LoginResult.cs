﻿using System.IdentityModel.Tokens.Jwt;

namespace WorldCitiesAPI
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}

