using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeHouse.Models
{
    public class OrderInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string IdOrders { get; set; }
        [ForeignKey("IdOrders")]
        [ValidateNever]
        public Orders Orders { get; set; }

        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        [ValidateNever]
        public Products Products { get; set; }

        public int Number { get; set; }
        public float Reduce { get; set; }
    }
}
