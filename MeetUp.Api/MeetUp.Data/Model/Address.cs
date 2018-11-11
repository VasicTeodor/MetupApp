using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetUp.Data.Model
{
    public class Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("MeetUp")]
        public int MeetUpId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Wrong length of street name property", MinimumLength = 1)]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
    }   
}
