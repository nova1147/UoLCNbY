// 代码生成时间: 2025-09-22 03:01:27
using System;
using System.Collections.Generic;
using System.Linq;

// Inventory Management System
namespace InventoryManagementSystem
{
    // Represents a product in the inventory
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }

    // Manages the inventory operations
    public class InventoryManager
    {
        private List<Product> inventory;

        public InventoryManager()
        {
            inventory = new List<Product>();
        }

        // Adds a product to the inventory
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            inventory.Add(product);
        }

        // Removes a product from the inventory
        public void RemoveProduct(int productId)
        {
            var productToRemove = inventory.FirstOrDefault(p => p.Id == productId);
            if (productToRemove == null) throw new ArgumentException("Product not found in inventory.");
            inventory.Remove(productToRemove);
        }

        // Updates the quantity of a product in the inventory
        public void UpdateProductQuantity(int productId, int newQuantity)
        {
            var productToUpdate = inventory.FirstOrDefault(p => p.Id == productId);
            if (productToUpdate == null) throw new ArgumentException("Product not found in inventory.");
            if (newQuantity < 0) throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity cannot be negative.");
            productToUpdate.Quantity = newQuantity;
        }

        // Lists all products in the inventory
        public List<Product> ListProducts()
        {
            return inventory.ToList();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InventoryManager manager = new InventoryManager();

                // Adding products
                manager.AddProduct(new Product(1, "Laptop", 10));
                manager.AddProduct(new Product(2, "Smartphone", 20));

                // Listing products
                var products = manager.ListProducts();
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Quantity: {product.Quantity}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}