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

            while (true)
            {
                Console.WriteLine("\n---- Menu ----");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usuń produkt");
                Console.WriteLine("3. Wyświetl wartość zamówienia");
                Console.WriteLine("4. Wyjście");
                Console.Write("Wybierz opcję: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("AddProducts");
                        break;
                    case "2":
                        Console.WriteLine("remove");
                        break;
                    case "3":
                        Console.WriteLine("display");
                        break;
                    case "4":
                        Console.WriteLine("Dziękujemy za skorzystanie z aplikacji!");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }

        }

    }
}