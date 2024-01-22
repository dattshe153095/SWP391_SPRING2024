using System.ComponentModel.DataAnnotations;

namespace WebClient.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username cannot be blank")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username cannot be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConnfirmPassword { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone cannot be blank")]
        public string Phone { get; set; }

    }
}
