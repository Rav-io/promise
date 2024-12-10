using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public void AddOrderItem(Product product, int quantity)
        {
            if (product == null || quantity <= 0 || quantity > 999)
            {
                return;
            }

            var existingItem = OrderItems.Find(item => item.Product.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                OrderItems.Add(new OrderItem(product, quantity));
            }
        }

        public void RemoveOrderItem(int index)
        {
            if (index >= 0 && index < OrderItems.Count)
            {
                OrderItems.RemoveAt(index);
            }
        }

        public double CalculateOrderValue()
        {
            double total = OrderItems.Sum(item => item.GetProductsPrice());

            var allProducts = OrderItems
                .SelectMany(item => Enumerable.Repeat(item.Product.Price, item.Quantity))
                .OrderBy(price => price)
                .ToList();

            double discount = 0;

            if (allProducts.Count == 2)
            {
                discount = allProducts[0] * 0.10;
            }
            else if (allProducts.Count == 3)
            {
                discount = allProducts[0] * 0.20;
            }

            total -= discount;

            if (total > 5000)
            {
                total *= 0.95;
            }

            return total;
        }
    }
}
