using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COREAPI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductType { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public bool Active { get; set; }
        public string BarCode { get; set; }
        public bool OutofStock { get; set; }
        public int MinimumStockQty { get; set; }
        public string ProductDescription { get; set; }
        public string ProductSummary { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public int TotalAvailableQTY { get; set; }
    }
}
