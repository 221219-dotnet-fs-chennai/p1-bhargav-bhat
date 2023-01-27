using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fluent_API.Entities;

public partial class TrainerDatabaseProjectContext : DbContext
{
    public TrainerDatabaseProjectContext()
    {
    }

    public TrainerDatabaseProjectContext(DbContextOptions<TrainerDatabaseProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalDetail> AdditionalDetails { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:bhargav-db-server.database.windows.net,1433;Initial Catalog=TrainerDatabaseProject;Persist Security Info=False;User ID=bhargav7342;Password=Bhargav@7342;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalDetail>(entity =>
        {
            entity.HasKey(e => e.Id4).HasName("PK__Addition__C49607F2F99D430E");

            entity.Property(e => e.Achievements).IsUnicode(false);
            entity.Property(e => e.Publications).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");
            entity.Property(e => e.VolunteeringExperiences)
                .IsUnicode(false)
                .HasColumnName("Volunteering_Experiences");

            entity.HasOne(d => d.Trainer).WithMany(p => p.AdditionalDetails)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Additiona__Train__114A936A");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id2).HasName("PK__Educatio__C49607F47CF41F12");

            entity.Property(e => e.CollegeUniversity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("College_University");
            entity.Property(e => e.Degree)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Educations)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Education__Train__0B91BA14");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id1).HasName("PK__Skills__C49607F511152754");

            entity.Property(e => e.SkillName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Skills)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Skills__Trainer___1BC821DD");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__8B0EB93113D52EA2");

            entity.ToTable("Trainer");

            entity.HasIndex(e => e.Email, "UQ__Trainer__A9D105348F61F1EF").IsUnique();

            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");
            entity.Property(e => e.AboutMe).IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id3).HasName("PK__WorkExpe__C49607F3C1AA77C2");

            entity.ToTable("WorkExperience");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.WorkExperiences)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__WorkExper__Train__0E6E26BF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
