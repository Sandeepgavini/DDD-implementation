namespace Shopping.Domain.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public CustomerDTO(int customerId, string customerName,string customerNumber)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerNumber = customerNumber;
        }
    }
}
