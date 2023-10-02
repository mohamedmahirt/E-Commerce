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
        [Required]
        public int CategoryId
        {
            get;
            set;
        }
        [ForeignKey("CategoryId")]
        public virtual Category Category
        {
            get;
            set;
        }
        [Required(ErrorMessage = "ProductCode is required")]
        [StringLength(200, ErrorMessage = "ProductCode can't be longer than 100 characters")]
        public string ProductCode
        {
            get;
            set;
        }
        [Required]
        [Range(0, 99999.99)]
        public decimal PurchaseAmount
        {
            get;
            set;
        }
        [Required]
        [Range(0, 999999.99)]
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
        [DataType(DataType.Date)]
        public DateTime ModifiedDate
        {
            get;
            set;
        } = DateTime.Now;
    }
}
