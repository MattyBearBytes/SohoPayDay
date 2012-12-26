using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace BearBytes.SohoPayDay.Dto
{
    public class ProductDto : BaseDto
    {
        /// <summary>
        /// Name of the Product
        /// </summary>
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
    }
}
