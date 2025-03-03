namespace Assignment7.model
{
    internal class Products
    {
        List<Product> products;
        public Products()
        {
            products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
