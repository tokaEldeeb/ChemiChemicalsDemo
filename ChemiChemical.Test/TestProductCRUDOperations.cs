using ChemiChemicals.Repository.Helper;
using ChemiChemicals.Repositry.Invokers;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace ChemiChemical.Test
{
    public class TestProductCRUDOperations
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["TestConnectionSting"].ConnectionString;
        public TestProductCRUDOperations()
        {
            //to be called before every unit test
            ConnectionStringBuilder builder = ConnectionStringBuilder.getInstance();
            builder.SetConnectionString(_connectionString);
        }

        [Fact]
        public async Task TestSelectAllProducts()
        {
            var products = await new Product().GetAllProducts();
            Assert.NotEmpty(products);
        }

        [Fact]
        public async Task TestSelectRecentChangedProducts()
        {
            var products = await new Product().GetRecentlyChangedProducts();
            Assert.NotEmpty(products);
        }

        [Fact]
        public async Task TestSelectProductById()
        {
            var products = await new Product().GetProductById(Guid.Parse("FAB67A68-0F2D-485E-8197-03E13A1A244B"));
            Assert.NotNull(products);
        }

        [Fact]
        public async Task TestDeleteById()
        {
            var products = await new Product().DeleteProductById(Guid.Parse("BAF6C858-DDFC-47AC-A25E-0C1236423131"));
            Assert.True(products);
        }

        [Fact]
        public async Task TestInsertProduct()
        {
            var newProd = new ChemiChemicals.Repository.Entities.Product
            {
                ProductName = "test",
                SupplierName = "test",
                BinaryContent = "testing binary content",
                Url = "http://test.com"
            };
            var product = await new Product().InsertProduct(newProd);
            Assert.NotNull(product);
        }

        [Fact]
        public async Task TestInsertProductNullName()
        {
            var newProd = new ChemiChemicals.Repository.Entities.Product
            {
                SupplierName = "test",
                BinaryContent = "testing binary content",
                Url = "http://test.com"
            };
           var ex =  await Assert.ThrowsAsync<SqlException>(async() => await new Product().InsertProduct(newProd));
        }

        [Fact]
        public async Task TestUpdateProduct()
        {
            var updatingProduct = new ChemiChemicals.Repository.Entities.Product
            {
                ProductName = "test update",
                SupplierName = "test update",
                BinaryContent = "testing update binary content",
                Url = "http://testupdate.com",
                ID = Guid.Parse("FAB67A68-0F2D-485E-8197-03E13A1A244B")
            };
            var product = await new Product().UpdateProduct(updatingProduct);
            Assert.NotNull(product);
        }
    }
}
