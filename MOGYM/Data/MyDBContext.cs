using Microsoft.EntityFrameworkCore;
using MOGYM.Models;

namespace MOGYM.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().UseTptMappingStrategy();
        }

        #region DbSetAdminModel
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<TraineeModel> Trainees { get; set; }
        public DbSet<TrainerModel> Trainers { get; set; }

        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<FeedbackModel> Feedbacks { get; set; }
        public DbSet<BranchModel> Branches { get; set; }
        public DbSet<WorkoutScheduleModel> WorkoutSchedules { get; set; }
        public DbSet<TimeTableModel> TimeTables { get; set; }

        #endregion
    }
}
