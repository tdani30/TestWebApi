using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Domain.Model
{
    public class AuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
