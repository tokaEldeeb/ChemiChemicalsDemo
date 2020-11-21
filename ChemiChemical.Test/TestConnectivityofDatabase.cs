using ChemiChemicals.Repository;
using ChemiChemicals.Repositry.Invokers;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace ChemiChemical.Test
{
    public class TestConnectivityofDatabase
    {
        [Fact]
        public async Task TestIfNoConnectionSet()
        {
            //check it will throw error if no connection string was set before
            //searched for the throw exception from https://stackoverflow.com/questions/45017295/assert-an-exception-using-xunit
            await Assert.ThrowsAsync<Exception>(async () => await new Product().GetAllProducts());
        }
    }
}
