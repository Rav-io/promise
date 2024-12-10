using OrderApp.Models;

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product("Laptop", 2500),
                new Product("Klawiatura", 120),
                new Product("Mysz", 90),
                new Product("Monitor", 1000),
                new Product("Kaczka debuggująca", 66)
            };
        }
    }
}