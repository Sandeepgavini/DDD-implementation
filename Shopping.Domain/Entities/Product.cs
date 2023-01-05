namespace Shopping.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get;  set; }
        public double ProductPrice { get;  set; }
        public Customer Customer { get; set; }  
        public int CustomerId { get; set; }

        public Product() { }

        public Product(string productName, double productPrice)
        {
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public Product(string productName, double productPrice,Customer customer)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Customer = customer;
        }
    }
}
