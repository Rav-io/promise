using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double GetProductsPrice()
        {
            return (Product?.Price ?? 0) * Quantity;
        }
    }
}
