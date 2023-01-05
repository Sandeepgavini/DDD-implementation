namespace Shopping.Domain.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public double TotatlBill { get; set; }
        public CustomerDTO(int customerId, string customerName,string customerNumber, double totatlBill=0)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerNumber = customerNumber;
            TotatlBill = totatlBill;
        }
    }
}
