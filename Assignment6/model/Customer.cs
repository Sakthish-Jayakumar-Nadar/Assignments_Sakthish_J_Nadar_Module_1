namespace Assignment6.model
{
    internal class Customer
    {   
        int tokenNo;
        public int TokenNo { get { return tokenNo; } }
        int customerId;
        public int CustomerId { get { return customerId; } }
        string customerName;
        public string CustomerName { get { return customerName; } }
        public Customer(int customerId, string customerName)
        {
            this.customerId = customerId;
            this.customerName = customerName;
        }
        public void GetTokenNo(Banks banks) 
        {
            tokenNo = banks.GetInQueue(this);
            Console.WriteLine($"Customer Id : {customerId} \t Customer Name : {customerName} \t Token No. : {tokenNo}");
        }
    }
}
