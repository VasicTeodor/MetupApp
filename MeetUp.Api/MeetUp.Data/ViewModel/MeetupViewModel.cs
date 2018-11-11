using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeetUp.Data.ViewModel
{
    public class MeetupViewModel
    {
        [Required]
        [StringLength(80, ErrorMessage = "Wrong length of title property", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+", ErrorMessage = "Name can't have special characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Wrong length of street name property", MinimumLength = 1)]
        public string Street { get; set; }
        [Required]
        public string HouseNmb { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public int MaxVisitors { get; set; }
        public int CreatorId { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Wrong length of lecturer name property", MinimumLength = 1)]
        public string Lecturer { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
