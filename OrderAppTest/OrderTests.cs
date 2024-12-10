using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAppTest
{
    public class OrderTests
    {
        [Fact]
        public void AddOrderItem_ShouldAddProductToOrder()
        {
            // Arrange
            var product = new Product("Laptop", 2500);
            var order = new Order();

            // Act
            order.AddOrderItem(product, 2);

            // Assert
            Assert.Single(order.OrderItems);
            Assert.Equal(2, order.OrderItems[0].Quantity);
        }

        [Fact]
        public void RemoveOrderItem_ShouldRemoveProductFromOrder()
        {
            // Arrange
            var product = new Product("Laptop", 2500);
            var order = new Order();
            order.AddOrderItem(product, 2);

            // Act
            order.RemoveOrderItem(0);

            // Assert
            Assert.Empty(order.OrderItems);
        }

        [Fact]
        public void CalculateOrderValue_ShouldReturnCorrectTotalPriceWithDiscount()
        {
            // Arrange
            var product1 = new Product("Laptop", 2500);
            var product2 = new Product("Klawiatura", 120);

            var order = new Order();
            order.AddOrderItem(product1, 2);
            order.AddOrderItem(product2, 1);

            // Act
            double total = order.CalculateOrderValue();

            // Assert
            Assert.Equal((5000 + 120*0.8)*0.95, total);
        }

        [Fact]
        public void CalculateOrderValue_ShouldReturnCorrectTotalPriceWithoutDiscount()
        {
            // Arrange
            var product = new Product("Laptop", 2500);

            var order = new Order();
            order.AddOrderItem(product, 1);

            // Act
            double total = order.CalculateOrderValue();

            // Assert
            Assert.Equal(2500, total);
        }
    }
}
