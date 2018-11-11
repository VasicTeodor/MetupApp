using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetUp.Data.Model
{
    public class Lecture
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("MeetUp")]
        public int MeetUpId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Wrong length of lecturer name property", MinimumLength = 1)]
        public string Lecturer { get; set; }
        [Required]
        public string Topic { get; set; }

        public Lecture() { }
        public Lecture(string lecturer, string topic)
        {
            this.Lecturer = lecturer;
            this.Topic = topic;
        }
    }
}
