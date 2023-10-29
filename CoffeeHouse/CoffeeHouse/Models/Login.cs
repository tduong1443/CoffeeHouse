using System.ComponentModel.DataAnnotations;

namespace CoffeeHouse.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
    }
}
