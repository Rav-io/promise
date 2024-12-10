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
            var order = new Order();

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
                        AddProductToOrder(products, order);
                        break;
                    case "2":
                        RemoveProductFromOrder(order);
                        break;
                    case "3":
                        DisplayOrder(order);
                        break;
                    case "4":
                        Console.WriteLine("Dziękujemy za zakupy!");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }

        }

        static void AddProductToOrder(List<Product> products, Order order)
        {
            while (true)
            {
                Console.WriteLine("\nDostępne produkty:");
                for (int i = 0; i < products.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Name} : {products[i].Price} PLN");
                }

                Console.Write("Wybierz produkt (numer): ");
                if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 1 && productIndex <= products.Count)
                {
                    Console.Write("Podaj ilość: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0 && quantity <= 999)
                    {
                        order.AddOrderItem(products[productIndex - 1], quantity);
                        Console.WriteLine("Produkt dodany do zamówienia.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa ilość. Podaj liczbę większą niż 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy wybór produktu. Spróbuj ponownie.");
                }
            }
        }

        static void RemoveProductFromOrder(Order order)
        {
            if (order.OrderItems.Count == 0)
            {
                Console.WriteLine("Zamówienie jest puste.");
                return;
            }

            Console.WriteLine("\nTwoje zamówienie:");
            for (int i = 0; i < order.OrderItems.Count; ++i)
            {
                var item = order.OrderItems[i];
                Console.WriteLine($"{i + 1}. {item.Product?.Name} - {item.Quantity} szt.");
            }

            Console.Write("Wybierz produkt do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex >= 1 && itemIndex <= order.OrderItems.Count)
            {
                order.RemoveOrderItem(itemIndex - 1);
                Console.WriteLine("Produkt usunięty z zamówienia.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór.");
            }
        }

        static void DisplayOrder(Order order)
        {
            if (order.OrderItems.Count == 0)
            {
                Console.WriteLine("Zamówienie jest puste.");
                return;
            }
            double totalValue = order.CalculateOrderValue();
            Console.WriteLine($"Wartość zamówienia: {totalValue} PLN");
        }
    }
}