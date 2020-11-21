using ChemiChemicals.EndPoint.Core;
using ChemiChemicals.Repository.Helper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace ChemiChemical.Test
{
    public class TestDALHandler
    {
        public TestDALHandler()
        {
            //to be called before every unit test
            string _connectionString = ConfigurationManager.ConnectionStrings["TestConnectionSting"].ConnectionString;
            ConnectionStringBuilder builder = ConnectionStringBuilder.getInstance();
            builder.SetConnectionString(_connectionString);
        }

        [Fact]
        public async Task TestSelectAllProducts()
        {
            var products = await new DALHandler().GetAllProducts();
            Assert.NotEmpty(products);
            Assert.IsType<List<ChemiChemicals.EndPoint.Models.Product>>(products);
        }

        [Fact]
        public async Task TestSelectRecentChangedProducts()
        {
            var products = await new DALHandler().GetRecentlyChangedProducts();
            Assert.NotEmpty(products);
            Assert.IsType<List<ChemiChemicals.EndPoint.Models.Product>>(products);

        }

        [Fact]
        public async Task TestSelectProductById()
        {
            var products = await new DALHandler().GetProductById(Guid.Parse("FAB67A68-0F2D-485E-8197-03E13A1A244B"));
            Assert.NotNull(products);
            Assert.IsType<ChemiChemicals.EndPoint.Models.Product>(products);
        }

        [Fact]
        public async Task TestDeleteById()
        {
            var products = await new DALHandler().DeleteProductById(Guid.Parse("BAF6C858-DDFC-47AC-A25E-0C1236423131"));
            Assert.True(products);
        }

        [Fact]
        public async Task TestInsertProduct()
        {
            var newProd = new ChemiChemicals.EndPoint.Models.Product
            {
                ProductName = "test",
                SupplierName = "test",
                BinaryContent = "testing binary content",
                Url = "http://test.com"
            };
            var product = await new DALHandler().InsertProduct(newProd);
            Assert.NotNull(product);
            Assert.IsType<ChemiChemicals.EndPoint.Models.Product>(product);
        }

        [Fact]
        public async Task TestInsertProductNullName()
        {
            var newProd = new ChemiChemicals.EndPoint.Models.Product
            {
                SupplierName = "test",
                BinaryContent = "testing binary content",
                Url = "http://test.com"
            };
            var ex = await Assert.ThrowsAsync<SqlException>(async () => await new DALHandler().InsertProduct(newProd));
        }

        [Fact]
        public async Task TestUpdateProduct()
        {
            var updatingProduct = new ChemiChemicals.EndPoint.Models.Product
            {
                ProductName = "test update",
                SupplierName = "test update",
                BinaryContent = "testing update binary content",
                Url = "http://testupdate.com",
                ID = Guid.Parse("FAB67A68-0F2D-485E-8197-03E13A1A244B")
            };
            var product = await new DALHandler().UpdateProduct(updatingProduct);
            Assert.NotNull(product);
            Assert.IsType<ChemiChemicals.EndPoint.Models.Product>(product);

        }
    }
}
