using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetUp.Data.Model
{
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Wrong length of name property", MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z ]+", ErrorMessage = "Name can't have special characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Wrong length of surname property", MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z ]+", ErrorMessage = "Surname can't have special characters")]
        public string Surname { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Wrong length of username property", MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9 ]+", ErrorMessage = "Username can't have special characters")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual List<UserMeetUps> MyMeetUps { get; set; }
    }
}
