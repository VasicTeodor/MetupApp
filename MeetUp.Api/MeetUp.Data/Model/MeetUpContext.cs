using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Data.Model
{
    public class MeetUpContext : DbContext
    {
        public MeetUpContext(DbContextOptions<MeetUpContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MeetUp> MeetUps { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMeetUps> UserMeetUps { get; set; }
    }
}
