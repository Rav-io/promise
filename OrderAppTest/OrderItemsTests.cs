using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAppTest
{
    public class OrderItemsTests
    {
        // w/o discounts
        [Fact]
        public void GetProductsPrice_ShouldReturnCorrectPrice()
        {
            // Arrange
            var product = new Product("Laptop", 2500);
            var orderItem = new OrderItem(product, 2);

            // Act
            double price = orderItem.GetProductsPrice();

            // Assert
            Assert.Equal(5000, price);
        }
    }
}
