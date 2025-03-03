namespace Assignment6.model
{
    internal class Banks
    {
        Queue<Customer> CustomerList;
        public Banks()
        {
            CustomerList = new Queue<Customer>();
        }
        public int GetInQueue(Customer customer)
        {
            CustomerList.Enqueue(customer);
            return CustomerList.Count;
        }
        public void NextInQueue()
        {
            Customer customer = CustomerList.Peek();
            Console.WriteLine($"Customer next in queue : Id : {customer.CustomerId} \t Name : {customer.CustomerName} \t Token no. : {customer.TokenNo}");
        }
        public void OutFromQueue()
        {
            Customer customer = CustomerList.Dequeue();
            Console.WriteLine($"Process completed : Id : {customer.CustomerId} \t Name : {customer.CustomerName} \t Token no. : {customer.TokenNo}");
        }
    }
}
