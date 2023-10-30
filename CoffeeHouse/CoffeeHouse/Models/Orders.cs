using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoffeeHouse.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdOrders { get; set; }

        public int IdStaff { get; set; }
        [ForeignKey("IdStaff")]
        [ValidateNever]
        public Staff Staff { get; set; }

        public int IdCustomer{ get; set; }
        [ForeignKey("IdCustomer")]
        [ValidateNever]
        public Customer Customer{ get; set; }

        public DateTime OrderDate { get; set; }
        public string Note { get; set; }
    }
}
