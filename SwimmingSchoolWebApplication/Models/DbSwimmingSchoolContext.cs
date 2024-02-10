using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SwimmingSchoolWebApplication.Models;

public partial class DbSwimmingSchoolContext : DbContext
{
    public DbSwimmingSchoolContext()
    {
    }

    public DbSwimmingSchoolContext(DbContextOptions<DbSwimmingSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupSchedule> GroupSchedules { get; set; }

    public virtual DbSet<Pupil> Pupils { get; set; }

    public virtual DbSet<PupilsEvent> PupilsEvents { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-JCD2U32\\SQLEXPRESS; Database=DbSwimmingSchool; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Day>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameOfDay).HasMaxLength(30);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Decree).HasColumnType("xml");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupName).HasMaxLength(50);

            entity.HasOne(d => d.Trainer).WithMany(p => p.Groups)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_Trainers");
        });

        modelBuilder.Entity<GroupSchedule>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TimeOfTrainingStart).HasPrecision(0);

            entity.HasOne(d => d.Day).WithMany(p => p.GroupSchedules)
                .HasForeignKey(d => d.DayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupSchedules_Days");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupSchedules)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupSchedules_Groups");
        });

        modelBuilder.Entity<Pupil>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.ParentsPhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Group).WithMany(p => p.Pupils)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pupils_Groups");
        });

        modelBuilder.Entity<PupilsEvent>(entity =>
        {
            entity.HasKey(e => new { e.PupilsId, e.EventId }).HasName("PK_PupilsEvent_1");

            entity.ToTable("PupilsEvent");

            entity.Property(e => e.Info).HasMaxLength(50);

            entity.HasOne(d => d.Event).WithMany(p => p.PupilsEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PupilsEvent_Events");

            entity.HasOne(d => d.Pupils).WithMany(p => p.PupilsEvents)
                .HasForeignKey(d => d.PupilsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PupilsEvent_Pupils");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
