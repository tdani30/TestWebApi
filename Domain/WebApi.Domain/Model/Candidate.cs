using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Domain.Model
{
    public class Candidate
    {
        public string id { get; set; }

        public string FullName { get; set; }

        public long mobile { get; set; }

        public int age { get; set; }

        public string address { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
