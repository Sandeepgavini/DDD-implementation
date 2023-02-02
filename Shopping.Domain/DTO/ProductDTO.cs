namespace Shopping.Domain.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }

        public ProductDTO(string productName,int productQuantity)
        {
            ProductName = productName;
            ProductQuantity = productQuantity;
        }
    }
}
