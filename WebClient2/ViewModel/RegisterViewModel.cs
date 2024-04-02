using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebClient2.ViewModel
{
    public class RegisterViewModel
    {

        public string Name { get; set; }

        [Required(ErrorMessage = "User cannot be blank")]
        [MaxLength(20, ErrorMessage = "Số kí tự dưới 20 kí hiệu")]
        [MinLength(6, ErrorMessage = "Số kí tự trên 6 kí hiệu")]
        [Remote(action: "UserNameIsExist", controller: "Home")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Code cannot be blank")]
        public string CodeValidate { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Mobile number is not valid.")]
        public string Phone { get; set; }

    }
}
