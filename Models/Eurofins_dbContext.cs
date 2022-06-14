using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_Eg.Models
{
    public partial class Eurofins_dbContext : DbContext
    {
        public Eurofins_dbContext()
        {
        }

        public Eurofins_dbContext(DbContextOptions<Eurofins_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Eurofins_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK__Departme__D877D216559BE36A");

                entity.ToTable("Department");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Dname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dname");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("location");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("PK__Employee__D9509F6D5A17B9CD");

                entity.ToTable("Employee");

                entity.Property(e => e.Eid)
                    .ValueGeneratedNever()
                    .HasColumnName("eid");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city")
                    .HasDefaultValueSql("('Chennai')");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Doj)
                    .HasColumnType("date")
                    .HasColumnName("doj");

                entity.Property(e => e.Empname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empname");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK__Employee__deptid__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
