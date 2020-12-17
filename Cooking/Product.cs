namespace Cooking
{
    public class Product
    {
        [ImportantProperty("MyProductReason")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{this.ProductName} ({this.Quantity})";
        }
    }
}
