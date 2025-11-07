using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Hw17.Models.Entities
{
    public class User
    {
        public User()
        {
            IsAdmin = false;
            IsActive = false;
        }
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
