using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BearBytes.SohoPayDay.Domain
{
    public class ProductDomain : BaseDomain
    {
        /// <summary>
        /// Name of the Product
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The Product Category
        /// </summary>
        public ProductCategoryDomain ProductCategory { get; set; }
    }
}
