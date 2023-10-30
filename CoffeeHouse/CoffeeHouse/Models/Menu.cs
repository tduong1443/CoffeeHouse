using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeHouse.Models
{
    public class Menu
    {
        public Menu()
        {
            Image = "~/images_icon/menu/list_menu/mn1.jpg";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        [ValidateNever]
        public Category Category { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }
    }
}
