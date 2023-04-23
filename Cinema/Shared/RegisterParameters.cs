using System.ComponentModel.DataAnnotations;

namespace Cinema.Shared
{
    public class RegisterParameters
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
