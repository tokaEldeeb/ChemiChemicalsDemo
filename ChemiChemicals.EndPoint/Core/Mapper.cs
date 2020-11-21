using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiChemicals.EndPoint.Core
{
    public static class Mapper
    {
        public static ChemiChemicals.Repository.Entities.Product ModelMapping(ChemiChemicals.EndPoint.Models.Product product)
        {
            return new ChemiChemicals.Repository.Entities.Product { 
                ID = product.ID,
                ProductName = product.ProductName,
                SupplierName = product.SupplierName,
                BinaryContent = product.BinaryContent,
                Url =product.Url,
                InsertionDate = product.InsertionDate,
                IsChanged = product.IsChanged
            };
        }

        public static ChemiChemicals.EndPoint.Models.Product ModelMapping(ChemiChemicals.Repository.Entities.Product product)
        {
            return new ChemiChemicals.EndPoint.Models.Product
            {
                ID = product.ID,
                ProductName = product.ProductName,
                SupplierName = product.SupplierName,
                BinaryContent = product.BinaryContent,
                Url = product.Url,
                InsertionDate = product.InsertionDate,
                IsChanged = product.IsChanged
            };
        }
    }

}
