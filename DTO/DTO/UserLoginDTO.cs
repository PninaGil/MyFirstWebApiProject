
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }

        [StringLength(20, ErrorMessage = "FirstName must contain 2-20 charachters.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [StringLength(20, ErrorMessage = "LastName must contain 2-20 charachters.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(15, ErrorMessage = "Password must contain 8-15 charachters.", MinimumLength = 8)]
        public string Password { get; set; } = null!;
    }
}
