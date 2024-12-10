using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    internal class Order
    {
        public List<OrderItem>? OrderItems { get; set; }

        public void AddOrderItem(Product product, int quantity)
        {
            OrderItems?.Add(new OrderItem(product, quantity));
        }

        public void RemoveOrderItem(int id)
        {
            OrderItems?.RemoveAt(id);
        }
    }
}
