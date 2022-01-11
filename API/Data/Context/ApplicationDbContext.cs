using Data.Models.Security;
using Data.Models.Comments;
using Data.Models.CourseContent;
using Data.Models.Exams;
using Data.Models.Locations;
using Data.Models.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Data.Models.WorkFlow;

namespace Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public string UserId { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = academy; Integrated Security = True; ", b => b.MigrationsAssembly("Data"));
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (entity is Audit)
                {
                    var track = entity as Audit;
                    track.CreatedDate = DateTime.UtcNow.AddHours(2);
                    track.CreatedById = UserId;
                }
            }

            var modified = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is Audit)
                {
                    var track = entity as Audit;
                    Entry(track).Property(p => p.CreatedById).IsModified = false;
                    Entry(track).Property(p => p.CreatedDate).IsModified = false;
                    track.ChangedById = UserId;
                    track.ChangedDate = DateTime.UtcNow.AddHours(2);
                }
            }
            return base.SaveChanges();
        }

        #region Locations
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        #endregion

        #region CouseContent
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        #endregion

        #region Exams
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        #endregion

        #region Comments
        public virtual DbSet<Comment> Commeents { get; set; }
        #endregion

        #region Workflow
        public virtual DbSet<Workflow> Workflow { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<StageTarget> StageTarget { get; set; }
        public virtual DbSet<StageEntry> StageEntry { get; set; }
        #endregion
    }
}
