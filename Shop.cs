using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Shop
    {
        private Dictionary<Product, int> products;
        public Shop()
        {
            products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }
        public void WriteAllProducts()
        {
            Console.WriteLine("Список продуктов: ");
            foreach (var product in products)
            {
                Console.WriteLine(product.Key.GetInfo() + "; Количество: " + product.Value);

            }
        }

        public void CreateProduct(string name, decimal price, int count)
        {
            products.Add(new Product(name, price), count);

        }
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;

        }

        public void Sell(string ProductName)
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                this.Sell(ToSell.ToString());
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }

    }
}
