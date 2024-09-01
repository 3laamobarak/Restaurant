using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }        
    }
}
