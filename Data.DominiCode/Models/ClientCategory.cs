using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DominiCode.Models
{
    public class ClientCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(400, MinimumLength = 1, ErrorMessage = "Only accepts one or 400 characters")]
        public string CategoryName { get; set; }

        public bool Active { get; set; }
    }
}
