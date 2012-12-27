using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Dto
{
    public class InvoiceItemDto : BaseDto
    {
        /// <summary>
        /// Invoice the Item belongs to
        /// </summary>
        [Required]
        [Display(Name = "Invoice")]
        public InvoiceDto Invoice { get; set; }

        /// <summary>
        /// The Product that is the Order Item
        /// </summary>
        [Required]
        [Display(Name = "Product")]
        public ProductDto Product { get; set; }

        /// <summary>
        /// Quantity of the Order Item
        /// </summary>
        [Required]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Unit Price of the Order Item
        /// </summary>
        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Calculated Total Price of the Order Item
        /// </summary>
        [Required]
        [Display(Name = "Total Price")]
        public decimal TotalPrice
        {
            get { return Quantity * UnitPrice; }
        }
    }
}
