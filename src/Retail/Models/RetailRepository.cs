using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Models
{
    public class RetailRepository : IRetailRepository
    {
        private RetailContext context;

        public RetailRepository(RetailContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product newProduct)
        {
            newProduct.CreatedDate = DateTime.Now;
            newProduct.UpdatedDate = DateTime.Now;
            context.Add(newProduct);
        }

        public void AddProductPrice(Price newPrice)
        {
            newPrice.CreatedDate = DateTime.Now;
            newPrice.UpdatedDate = DateTime.Now;
            context.Add(newPrice);
        }

        public void AddStore(Store newStore)
        {
            newStore.CreatedDate = DateTime.Now;
            newStore.UpdatedDate = DateTime.Now;
            context.Add(newStore);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.OrderBy(s => s.Label).ToList();
        }

        public IEnumerable<Store> GetAllStores()
        {
            return context.Stores.OrderBy(s => s.Label).ToList();
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return context.Units.ToList();
        }

        public Product GetProductByBarcode(string barcode)
        {
            return context.Products.FirstOrDefault(s => s.Barcode == barcode);
        }

        public Product GetProduct(int id)
        {
            var product = context.Products.FirstOrDefault(s => s.Id == id);
            if (product == null)
            {
                throw new EntityNotFoundException();
            }
            return product;
        }

        public IEnumerable<Price> GetProductPrices(int productId)
        {
            var product = GetProduct(productId);
            var prices = context.Prices.Where(p => p.ProductId == productId);
            if (prices == null)
            {
                return new List<Price>();
            }

            foreach (var price in prices)
            {
                if (price.Bogo)
                {
                    price.Cost /= 2.0m;
                }
            }
            return prices;
        }

        public void DeleteProduct(int id)
        {
            var entity = context.Products.FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                return;
            }
            context.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteProductPrice(int priceId)
        {
            var entity = context.Prices.FirstOrDefault(p => p.Id == priceId);
            if (entity == null)
            {
                return;
            }
            context.Remove(entity);
            context.SaveChanges();
        }

        public bool SaveAll()
        {
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            throw new Exception("No changes");
        }
    }
}
