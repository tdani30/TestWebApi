using SD.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Entities
{
    [Table("Candidate")]
   public  class Candidates : BaseEntity
    {
        public string FullName { get; set; }

        public long Mobile { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
