using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiChemicals.EndPoint.Core
{
    public class DALHandler
    {
        public async Task<List<Models.Product>> GetAllProducts()
        {
            var productsFromSql = await new Repositry.Invokers.Product().GetAllProducts();
            var products = productsFromSql.Select(prod => Mapper.ModelMapping(prod)).ToList();
            return products;
        }

        public async Task<List<Models.Product>> GetRecentlyChangedProducts()
        {
            var productsFromSql = await new Repositry.Invokers.Product().GetRecentlyChangedProducts();
            var products = productsFromSql.Select(prod => Mapper.ModelMapping(prod)).ToList();
            return products;
        }

        public async Task<Models.Product> GetProductById(Guid id)
        {
            var productsFromSql = await new Repositry.Invokers.Product().GetProductById(id);
            var products = Mapper.ModelMapping(productsFromSql);
            return products;
        }

        public async Task<Models.Product> UpdateProduct(Models.Product updatedProduct)
        {
            var productForSql = Mapper.ModelMapping(updatedProduct);
            var productsFromSql = await new Repositry.Invokers.Product().UpdateProduct(productForSql);
            var products = Mapper.ModelMapping(productsFromSql);
            return products;
        }

        public async Task<Models.Product> InsertProduct(Models.Product newProduct)
        {
            var productForSql = Mapper.ModelMapping(newProduct);
            var productsFromSql = await new Repositry.Invokers.Product().InsertProduct(productForSql);
            var products = Mapper.ModelMapping(productsFromSql);
            return products;
        }

        public async Task<bool> DeleteProductById(Guid id)
        {
            return await new Repositry.Invokers.Product().DeleteProductById(id);
        }
    }
}
