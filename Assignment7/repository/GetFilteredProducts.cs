using Assignment7.model;

namespace Assignment7.repository
{
    internal class GetFilteredProducts
    {
        public void FilterByCategoryAndPrice(List<Product> products,string category, double price)
        {
            var filteredProducts =  products.Where(p => p.Category == category && p.Price > price);
            Console.WriteLine($"Filters => Category : {category} and Price > {price}");
            if (filteredProducts.Count() > 0)
            {
                foreach (Product product in filteredProducts)
                {
                    Console.WriteLine($"ProductID : {product.Id} and Product Name : {product.Name}");
                }
            }
            else
            {
                Console.WriteLine("No products with this filter");
            }
        }

        public void MostExpensiveProduct(List<Product> products)
        {
            var maxPrice = products.Max(p =>  p.Price);
            var expensiveProducts = products.Where(p => p.Price ==  maxPrice);
            Console.WriteLine("Expensive Products are : ");
            if(expensiveProducts.Count() > 0)
            {
                foreach (Product product in expensiveProducts)
                {
                    Console.WriteLine($"{product.Name} : {product.Price}Rs");
                }
            }
            else
            {
                Console.WriteLine("No products");
            }
        }
    }
}
