namespace CoffeeHouse.Models
{
    public class CartItem
    {
        public List<ShopCart> Item { get; set; }
        public float GrandTotal { get; set; }
    }
}
