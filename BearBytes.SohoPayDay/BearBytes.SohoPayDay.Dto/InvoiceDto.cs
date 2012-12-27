using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Common;

namespace BearBytes.SohoPayDay.Dto
{
    public class InvoiceDto : BaseDto
    {
        //Will this be what we use to tell the difference between a quote and an invoice?
        public string InvoiceType { get; set; }

        /// <summary>
        /// Client the Invoice is for
        /// </summary>
        [Required]
        [Display(Name = "Client")]
        public ClientDto Client { get; set; }

        /// <summary>
        /// Date the Invoice is issued for
        /// </summary>
        [Required]
        [Display(Name = "Issue Date")]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Date the Invoice is issued for
        /// </summary>
        [Required]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

    }
}
