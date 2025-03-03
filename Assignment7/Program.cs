using Assignment7.model;
using Assignment7.repository;

namespace Assignment7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            Employee e1 = new Employee(1, "Sakthish J. Nadar", DateTime.Parse("1/16/2025"));
            Employee e2 = new Employee(2, "Om Auti", DateTime.Parse("1/16/2024"));
            Employee e3 = new Employee(3, "Shreekant", DateTime.Parse("1/16/2023"));
            e1.CalculateExperience();
            e2.CalculateExperience();
            e3.CalculateExperience();
            #endregion

            Console.WriteLine("\n \n");

            #region question2
            Product product1 = new Product(1,"washing machine","electronics",15000);
            Product product2 = new Product(2, "hair dryer", "electronics", 1200);
            Product product3 = new Product(3, "broom", "household", 100);
            Product product4 = new Product(4, "hand bag", "beauty", 500);
            Product product5 = new Product(5, "smart watch", "electronics", 500);
            Product product6 = new Product(6, "brush", "beauty", 50);
            Product product7 = new Product(7, "TV", "electronics", 15000);
            Products products = new Products();
            products.AddProduct(product1);
            products.AddProduct(product2);
            products.AddProduct(product3);
            products.AddProduct(product4);
            products.AddProduct(product5);
            products.AddProduct(product6);
            products.AddProduct(product7);
            GetFilteredProducts getFilteredProducts = new GetFilteredProducts();
            getFilteredProducts.FilterByCategoryAndPrice(products.GetProducts(),"electronics",1000);
            getFilteredProducts.MostExpensiveProduct(products.GetProducts());
            #endregion
        }
    }
}
