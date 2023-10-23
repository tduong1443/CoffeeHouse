using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeHouse.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdProduct { get; set; }

        public string IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        [ValidateNever]
        public Category Category { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }
    }
}
