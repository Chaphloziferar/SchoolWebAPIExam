using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolWebAPI.Db;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__FDF47986162D92D3");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("date")
                .HasColumnName("deleted_date");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__teacher__412EB0B6");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__6D24AA7A14D9E214");

            entity.Property(e => e.EnrollmentId)
                .ValueGeneratedNever()
                .HasColumnName("enrollment_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("date")
                .HasColumnName("deleted_date");
            entity.Property(e => e.EnrollmentDate)
                .HasColumnType("date")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Class).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__class__45F365D3");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__stude__44FF419A");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.HasKey(e => e.EvaluationId).HasName("PK__Evaluati__827C592D553EC5B3");

            entity.Property(e => e.EvaluationId)
                .ValueGeneratedNever()
                .HasColumnName("evaluation_id");
            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.EvaluationDate)
                .HasColumnType("date")
                .HasColumnName("evaluation_date");
            entity.Property(e => e.EvaluationType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("evaluation_type");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("score");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_evaluations_enrollments");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__3A8F732CEEB74197");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("grade_id");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("date")
                .HasColumnName("deleted_date");
            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.Grade1).HasColumnName("grade");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__enrollme__49C3F6B7");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069ADE8582F0");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("date")
                .HasColumnName("deleted_date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__03AE777E9E5E88B6");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("teacher_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("date")
                .HasColumnName("deleted_date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F056C9968");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("date")
                .HasColumnName("deleted_date");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_type");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
