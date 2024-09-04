using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmailSandWithStBuilder;

public partial class StudentemailsysContext : DbContext
{
    public StudentemailsysContext()
    {
    }

    public StudentemailsysContext(DbContextOptions<StudentemailsysContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmailTamp> EmailTamps { get; set; }

    public virtual DbSet<StudentMaildetail> StudentMaildetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VISAL\\MSSQLSERVER02;Database=studentemailsys;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailTamp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmailTamp");

            entity.Property(e => e.EmailTampBody).HasMaxLength(250);
            entity.Property(e => e.EmailTampName).HasMaxLength(50);
            entity.Property(e => e.EmailTampTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentMaildetail>(entity =>
        {
            entity.ToTable("Student_maildetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
