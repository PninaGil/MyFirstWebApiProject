
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class UserEmailPassDTO
    {
        public int UserId { get; set; }

        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
