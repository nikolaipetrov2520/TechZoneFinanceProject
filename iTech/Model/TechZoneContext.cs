using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBase.Model
{
    public partial class TechZoneContext : DbContext
    {
        public TechZoneContext()
        {
        }

        public TechZoneContext(DbContextOptions<TechZoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cash2> Cash2s { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TechZone;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Cash2>(entity =>
            {
                entity.ToTable("Cash2");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Money).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Cost>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Article)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Repair).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId)
                    .HasMaxLength(250)
                    .HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
