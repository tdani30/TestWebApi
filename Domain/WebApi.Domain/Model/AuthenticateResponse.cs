using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Domain.Model
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Candidate user, string token)
        {
            Id = user.ID;
            FullName = user.FullName;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
    }
}
