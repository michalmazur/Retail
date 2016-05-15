using System.Collections.Generic;

namespace Retail.Models
{
    public interface IRetailRepository
    {
        IEnumerable<Unit> GetAllUnits();
        IEnumerable<Store> GetAllStores();
        void AddStore(Store newStore);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product newProduct);
        Product GetProduct(int productId);
        Product GetProductByBarcode(string barcode);
        IEnumerable<Price> GetProductPrices(int productId);
        void AddProductPrice(Price newPrice);
        void DeleteProductPrice(int priceId);
        void DeleteProduct(int productId);
        bool SaveAll();
    }
}