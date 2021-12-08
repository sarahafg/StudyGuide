using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StudyGuideDbContext : DbContext
    {
        // get the connection string into constructor
        public StudyGuideDbContext(DbContextOptions<StudyGuideDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify Fluent API rules for your Entities

            modelBuilder.Entity<Question>(ConfigureQuestion);
            modelBuilder.Entity<Answer>(ConfigureAnswer);
            modelBuilder.Entity<Interaction>(ConfigureInteraction);
        }

        private void ConfigureQuestion(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Name).HasMaxLength(50);
            builder.Property(q => q.Questions).HasMaxLength(300);
            builder.Property(c => c.AddedOn).HasDefaultValueSql("getdate()");

        }
        private void ConfigureInteraction(EntityTypeBuilder<Interaction> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.QuestionId);
            builder.Property(i => i.AnswerId);
            builder.Property(i => i.IntType).HasMaxLength(1);
            builder.Property(i => i.IntDate).HasDefaultValueSql("getdate()");
            builder.Property(i => i.Comments).HasMaxLength(500);
            //builder.HasBaseType(Char)
        }

        private void ConfigureAnswer(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Comments).HasMaxLength(300);
            builder.Property(a => a.Answers).HasMaxLength(300);
        }


        public DbSet<Question> Questions { get; set; }

        public DbSet<Interaction> Interactions { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }
}
