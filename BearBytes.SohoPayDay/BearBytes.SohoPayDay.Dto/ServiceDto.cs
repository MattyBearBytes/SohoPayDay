using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace BearBytes.SohoPayDay.Dto
{
    public class ServiceDto : BaseDto
    {
        /// <summary>
        /// Name of the Service
        /// </summary>
        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; }
    }
}
