using System;

namespace ChemiChemicals.Repository.Entities
{
    public class Product
    {
        public Guid ID { set; get; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string Url { get; set; }
        public string BinaryContent { get; set; }
        public bool IsChanged { get; set; }
        public DateTime InsertionDate { get; set; }

    }
}
