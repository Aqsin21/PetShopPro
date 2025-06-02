namespace PetShop.Models
{
    public class CartViewModel
    {
        public int Quanity { get; set; }

        public decimal Total { get; set; }

        public List<CartItemViewModel> Items { get; set; } = new();


    }

    public class CartItemViewModel
    {
       
        public required string ProductName { get; set; }
        public required string Decription { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
