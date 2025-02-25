﻿using GameStore.Models;

namespace GameStore.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);

        // I change void on public Product
        public Product GetProduct(int id);
        void UpdateProduct(Product product);

        void UpdateAll(Product[] products);

        void DeleteProduct(Product product);


    }
}
