using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace BearBytes.SohoPayDay.Dto
{
    public class LookupDto : BaseDto
    {
        /// <summary>
        /// The Value of the Lookup
        /// </summary>
        [Required]
        public string Value { get; set; }
    }
}
