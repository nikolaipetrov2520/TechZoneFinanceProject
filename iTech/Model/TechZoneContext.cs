using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace iTech.Model
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
        public virtual DbSet<PosPaymant> PosPaymants { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=ITECH-PC\SQLEXPRESS19;Database=TechZone;Trusted_Connection=True;");
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

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incomes_Type");
            });

            modelBuilder.Entity<PosPaymant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OutSum).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
