using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class Product : NamedEntity
    {
        
        public int CategoryId
        {
            get;
            set;
        }
        [ForeignKey("CategoryId")]
        public Category Category
        {
            get;
            set;
        }
        public string ProductCode
        {
            get;
            set;
        }
        public decimal PurchaseAmount
        {
            get;
            set;
        }
        public decimal SaleAmount
        {
            get;
            set;
        }
        public string Color
        {
            get;
            set;
        }
        public string Caption
        {
            get;
            set;
        }
        public bool IsFeatured
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
    }
}
