namespace Assignment7.model
{
    internal class Product
    {
        public int Id { get; }
        public string Name { get; }
        public string Category { get; }
        public double Price { get; }
        public Product(int id, string name, string category, double price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
