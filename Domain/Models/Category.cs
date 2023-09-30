using System.Collections.Generic;

namespace Shopbridge_base.Domain.Models
{
    public class Category:NamedEntity
    {
        public string Caption
        {
            get;
            set;
        }
        public ICollection<Product> Products
        {
            get;
        }
    }
}
