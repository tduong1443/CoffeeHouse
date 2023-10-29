using System.ComponentModel.DataAnnotations;

namespace CoffeeHouse.Models
{
    public class Register
    {

        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
