using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemmemberMe { get; set; }
    }
}
