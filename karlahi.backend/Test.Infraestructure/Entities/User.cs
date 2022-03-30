using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Infraestructure.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}