using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetUp.Data.Model
{
    public class MeetUp
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Wrong length of title property", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9_ ]+", ErrorMessage = "Name can't have special characters")]
        public string Title { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public virtual List<UserMeetUps> Visitors { get; set; }
        [Required]
        public int MaxVisitors { get; set; }
        public int CurrentVisitorsCount { get; set; }
        [Required]
        public int CreatedById { get; set; }
        [Required]
        public Lecture Lecture { get; set; }

        public MeetUp() { }
        public MeetUp(string title, Address address, DateTime date, string from, string to, int maxVisitors, int createdBy)
        {
            Title = title;
            Address = address;
            Date = date;
            From = from;
            To = to;
            MaxVisitors = maxVisitors;
            CreatedById = createdBy;
            CurrentVisitorsCount = 0;
        }
    }
}
