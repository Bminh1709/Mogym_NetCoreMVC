using Microsoft.EntityFrameworkCore;
using MOGYM.Models;

namespace MOGYM.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }


        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }

        #endregion
    }
}
