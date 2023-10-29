namespace CoffeeHouse.Models
{
    // Cart
    public class ShopCart
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Total
        {
            get { return Price * Quantity; }
        }
        public ShopCart() { }
        public ShopCart(Products products)
        {
            Id = products.IdProduct;
            Name = products.Name;
            Image = products.Image;
            Price = products.Price;
            Quantity = 1;
        }
    }
}
