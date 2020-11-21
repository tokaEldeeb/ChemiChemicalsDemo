using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiChemicals.Repositry.Invokers
{
    public class Product : ContextInitializer
    {
        public async Task<List<Repository.Entities.Product>> GetAllProducts()
        {
            var result = await _chemiContext.Products.FromSqlRaw("sp_select_all_products").AsNoTracking().ToListAsync();
            _chemiContext.Dispose();
            return result;
        }

        public async Task<List<Repository.Entities.Product>> GetRecentlyChangedProducts()
        {
            var result = await _chemiContext.Products.FromSqlRaw("sp_get_recently_updated_products").AsNoTracking().ToListAsync();
            _chemiContext.Dispose();
            return result;
        }

        public async Task<Repository.Entities.Product> GetProductById(Guid id)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@ID", id)
            };
            var result = await _chemiContext.Products.FromSqlRaw("sp_select_product_by_id @ID ", sqlParams.ToArray()).AsNoTracking().ToListAsync();
            _chemiContext.Dispose();
            return result.Single();
        }

        public async Task<Repository.Entities.Product> UpdateProduct(Repository.Entities.Product updatedProduct)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@ID", updatedProduct.ID),
                new SqlParameter("@ProductName", updatedProduct.ProductName),
                new SqlParameter("@SupplierName", updatedProduct.SupplierName),
                new SqlParameter("@Url", updatedProduct.Url),
                new SqlParameter("@BinaryContent", updatedProduct.BinaryContent),
            };
            var result = await _chemiContext.Products.FromSqlRaw("sp_update_product @ID , @ProductName , @SupplierName , @Url , @BinaryContent  ", sqlParams.ToArray()).AsNoTracking().ToListAsync();
            _chemiContext.Dispose();
            return result.Single();
        }

        public async Task<Repository.Entities.Product> InsertProduct(Repository.Entities.Product newProduct)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@ProductName", newProduct.ProductName),
                new SqlParameter("@SupplierName", newProduct.SupplierName),
                new SqlParameter("@Url", newProduct.Url),
                new SqlParameter("@BinaryContent", newProduct.BinaryContent),
            };
            var result = await _chemiContext.Products.FromSqlRaw("[sp_insert_product] @ProductName , @SupplierName , @Url , @BinaryContent  ",sqlParams.ToArray()).AsNoTracking().ToListAsync();
            _chemiContext.Dispose();
            return result.Single();
        }

        public async Task<bool> DeleteProductById(Guid id)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("@ID", id)
            };
            await _chemiContext.Database.ExecuteSqlRawAsync("sp_delete_product_by_id @ID ", sqlParams.ToArray());
            _chemiContext.Dispose();
            return true;
        }
    }
}
