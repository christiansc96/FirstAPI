using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.DominiCode.Models
{
    public class Clients
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(400, MinimumLength = 1, ErrorMessage = "Only accepts one or 400 characters")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "It is not a valid mail")]
        [StringLength(500, MinimumLength = 1 , ErrorMessage = "Only accepts one or 500 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(25, MinimumLength = 5, ErrorMessage ="Only accepts five or 25 characters")]
        [Phone(ErrorMessage = "Is not valid number")]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredDate { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ClientCategory ClientCategory { get; set; }
    }
}
