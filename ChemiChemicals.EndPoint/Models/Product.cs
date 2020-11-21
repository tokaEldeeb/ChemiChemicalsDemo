using System;
using System.ComponentModel.DataAnnotations;

namespace ChemiChemicals.EndPoint.Models
{
    public class Product
    {
        public Guid ID { set; get; }
        [Required(ErrorMessage ="Product name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Supplier name is required")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
        public string BinaryContent { get; set; }
        public bool IsChanged { get; set; }
        public DateTime InsertionDate { get; set; }
    }
}
