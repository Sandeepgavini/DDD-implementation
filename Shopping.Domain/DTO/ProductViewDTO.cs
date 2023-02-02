namespace Shopping.Domain.DTO
{
    public class ProductViewDTO
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }  
        public int ProductQuantity { get; set; }
        public ProductViewDTO( string productName, double productPrice,int productQuantity)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}
