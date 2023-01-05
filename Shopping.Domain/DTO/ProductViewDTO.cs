namespace Shopping.Domain.DTO
{
    public class ProductViewDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }  

        public ProductViewDTO(int customerId, string customerName,int productId, string productName, double productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            CustomerId = customerId;
            CustomerName = customerName;
        }
    }
}
