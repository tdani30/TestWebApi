using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi.Domain.Model
{
    public class Candidate
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("FullName")]
        public string FullName { get; set; }

        [JsonPropertyName("Mobile")]
        public long Mobile { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
