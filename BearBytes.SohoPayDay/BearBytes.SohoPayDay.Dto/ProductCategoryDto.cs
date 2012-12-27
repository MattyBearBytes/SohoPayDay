using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;


namespace BearBytes.SohoPayDay.Dto
{
    public class ProductCategoryDto : BaseDto
    {
        /// <summary>
        /// Name of the Product Category
        /// </summary>
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        /// <summary>
        /// The Type of Product
        /// </summary>
        [Required]
        [Display(Name = "Type")]
        public string ProductType { get; set; }
    }
}
