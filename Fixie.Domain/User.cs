using System;
using Fixie.Domain.Enumerators;

namespace Fixie.Domain
{
    public class User : IEntity
    {
        public User()
        {
            Gender = Gender.Unspecified;
        }

        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int ModifiedBy { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public Gender Gender { get; set; }
    }
}
