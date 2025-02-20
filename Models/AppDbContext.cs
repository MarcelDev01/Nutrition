using Microsoft.EntityFrameworkCore;
using Nutrition.Models.DataBase;

namespace Nutrition.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<BodyAssessment> BodyAssessments { get; set; }
        public DbSet<Trainning> Trainnings { get; set; }
        public DbSet<CategoryTrainning> CategoryTrainnings { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<TimeFood> TimeFoods { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}